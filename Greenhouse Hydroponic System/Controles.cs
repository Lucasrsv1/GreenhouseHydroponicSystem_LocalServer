using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public partial class Controles : Form {
		public Controles () {
			InitializeComponent();
			menu.SetParent(this);

			updating = true;
			nextLocalId = 1;
			controllers = new List<Ctrl>();
			orders = new List<Order>();
			myDelegate = new ControlesDelegate(AddController);
			new Thread(() => UpdateControllers(false)).Start();
			existingOrders = new List<int>();
		}

		public bool updating;
		public List<Order> orders;
		public List<Ctrl> controllers;
		public ControlesDelegate myDelegate;

		public delegate void ControlesDelegate (Controller ctrl);

		private int nextLocalId;
		private List<int> existingOrders;

		public void AddController (Controller ctrl) {
			flowLayoutPanel1.Controls.Add(ctrl);
		}

		public void UpdateControllers (bool one = false) {
			while (updating) {
				Console.WriteLine("Updating... [OK]");
				// Check plan limit to avoid making new SQL request
				if (controllers.Count < Geral.ControlesPlano()) {
					// Get new controllers
					Login.offline.Select("SELECT id, rele_pin, rele_nome, estado FROM reles WHERE em_uso ORDER BY rele_nome ASC");
					if (Login.offline.SelectResult != null) {
						foreach (string[] onRow in Login.offline.SelectResult.Skip(1)) {
							var exists = (from c in controllers
										  where c.Rele_Pin.ToString() == onRow[1]
										  select c).Count() > 0;

							if (!exists && controllers.Count < Geral.ControlesPlano()) { // Check plan for all new controllers
								int rele_id, rele_pin;
								int.TryParse(onRow[0], out rele_id);
								int.TryParse(onRow[1], out rele_pin);
								Status status = (onRow[3] == "False" || onRow[3] == "0") ? Status.Desligado : Status.Ligado;
								controllers.Add(new Ctrl(rele_id, rele_pin, onRow[2], status, this, false));
							}
						}
					}
				}

				// Get new orders
				existingOrders.Clear();
				Login.offline.Select("SELECT id, rele_pin, ordem FROM ordens_pendentes ORDER BY envio ASC");
				if (Login.offline.SelectResult != null) {
					foreach (string[] onRow in Login.offline.SelectResult.Skip(1)) {
						try {
							existingOrders.Add(int.Parse(onRow[0]));
						} catch { }

						bool exists = orders.Count == 255; // Only allow the first 255 orders.
						if (!exists) {
							foreach (Order o in orders) {
								if (o.Controller.Rele_Pin.ToString() == onRow[1]) {
									exists = true;
									break;
								}
							};
						}

						if (!exists) {
							int id;
							int.TryParse(onRow[0], out id);
							Status status = (onRow[2] == "False" || onRow[2] == "0") ? Status.Desligado : Status.Ligado;
							var ctrl = (from c in controllers
										where c.Rele_Pin.ToString() == onRow[1]
										select c).FirstOrDefault();

							if (nextLocalId == 256)
								nextLocalId = 1;

							orders.Add(new Order(id, nextLocalId, status, ctrl));
							nextLocalId++;
						}
					}
				}
				
				if (Login.conexaoIntance != null) {
					if (Login.conexaoIntance.Connected) {
						// Start new controllers
						for (int n = 0; n < controllers.Count; n++) {
							if (!controllers[n].Started) {
								if (Login.conexaoIntance.SendMessage(129, controllers[n].Rele_Pin, (int)controllers[n].Status, 0))
									Thread.Sleep(500);
							}
						}

						// Handle orders
						for (int o = 0; o < orders.Count; o++) {
							// Clear executed orders
							if (orders.Count > o ? orders[o].Cumprida : false) { // Multiple threads editing orders
								orders.RemoveAt(o);
							} else {
								// Send new orders
								bool send = true;
								if (!existingOrders.Contains(orders.Count > o ? orders[o].Id : -1)) {
									// Ordem cancelada fora desta aplicação
									if (orders.Count > o)
										orders[o].Canceled();

									send = false;
								} else if (orders.Count > o ? orders[o].Sent != null : false) {
									if (DateTime.Now.Subtract((DateTime)orders[o].Sent).Seconds < 10)
										send = false;
								}

								if (send && orders.Count > o) {
									if (Login.conexaoIntance.SendMessage(131, orders[o].Local_Id, orders[o].Controller.Rele_Pin, (int)orders[o].Ordem)) {
										if (orders.Count > o) {
											orders[o].Send();
											Thread.Sleep(500);
										}
									}
								}
							}
						}
					} else {
						// Check canceled orders
						for (int o = 0; o < orders.Count; o++) {
							if (orders[o].Cumprida) {
								orders.RemoveAt(o);
							} else {
								if (!existingOrders.Contains(orders[o].Id)) // Ordem cancelada fora desta aplicação
									orders[o].Canceled();
							}
						}
					}

					if (!one)
						Thread.Sleep(6000);
					else
						break;
				}
			}
		}

		private void Controles_FormClosing (object sender, FormClosingEventArgs e) {
			updating = false;
		}

		public void SuspendArduino () {
			foreach (Ctrl control in controllers)
				control.ConnectionLost();

			foreach (Order order in orders)
				order.ConnectionLost();
		}

		public void Controles_Shown (object sender = null, EventArgs e = null) {
			controllers.ForEach((Ctrl control) => {
				if (!flowLayoutPanel1.Controls.Contains(control.Design))
					control.AddDesign();
			});
		}
	}
}
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
			controllers = new List<Ctrl>();
			orders = new List<Order>();
			myDelegate = new ControlesDelegate(AddController);
			new Thread(new ThreadStart(UpdateControllers)).Start();
		}

		public bool updating;
		public List<Order> orders;
		public List<Ctrl> controllers;
		public ControlesDelegate myDelegate;

		public delegate void ControlesDelegate (Controller ctrl);

		public void AddController (Controller ctrl) {
			flowLayoutPanel1.Controls.Add(ctrl);
		}

		private void UpdateControllers () {
			while (updating) {
				// Check plan limit to avoid making new SQL request
				if (controllers.Count < Geral.ControlesPlano()) {
					// Get new controllers
					Login.offline.Select("SELECT rele_pin, rele_nome, estado FROM reles WHERE em_uso ORDER BY rele_nome ASC");
					foreach (string[] onRow in Login.offline.SelectResult.Skip(1)) {
						var exists = (from c in controllers
									  where c.Rele_Pin.ToString() == onRow[0]
									  select c).Count() > 0;

						if (!exists && controllers.Count < Geral.ControlesPlano()) { // Check plan for all new controllers
							int rele_pin;
							int.TryParse(onRow[0], out rele_pin);
							Status status = (onRow[2] == "False" || onRow[2] == "0") ? Status.Desligado : Status.Ligado;
							controllers.Add(new Ctrl(rele_pin, onRow[1], status, this, false));
						}
					}
				}

				// Get new orders
				Login.offline.Select("SELECT id, rele_pin, ordem FROM ordens_pendentes ORDER BY envio ASC");
				if (Login.offline.SelectResult != null) {
					foreach (string[] onRow in Login.offline.SelectResult.Skip(1)) {
						var exists = (from c in orders
									  where c.Id.ToString() == onRow[0]
									  select c).Count() > 0;
						if (!exists) {
							int id;
							int.TryParse(onRow[0], out id);
							Status status = (onRow[2] == "False" || onRow[2] == "0") ? Status.Desligado : Status.Ligado;
							var ctrl = (from c in controllers
										where c.Rele_Pin.ToString() == onRow[1]
										select c).FirstOrDefault();

							orders.Add(new Order(id, status, ctrl));
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
							if (orders[o].Cumprida) {
								orders.RemoveAt(o);
							} else {
								// Send new orders
								bool send = true;
								if (orders[o].Sent != null) {
									if (DateTime.Now.Subtract((DateTime)orders[o].Sent).Seconds < 10)
										send = false;
								}

								if (send) {
									if (Login.conexaoIntance.SendMessage(131, orders[o].Id, orders[o].Controller.Rele_Pin, (int)orders[o].Ordem)) {
										orders[o].Send();
										Thread.Sleep(500);
									}
								}
							}
						}
					}
				}

				Thread.Sleep(6000);
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
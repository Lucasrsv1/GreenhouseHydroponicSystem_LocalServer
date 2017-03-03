using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public struct Ctrl {
		public Ctrl (int rele_pin, string title, Status status, Controles form) {
			this.title = title;
			this.status = status;
			parent = form;

			Rele_Pin = rele_pin;
			Design = new Controller();
			Ordens = new List<int>();
			Title = title;
			Status = status;

			AddDesign();
		}

		public int Rele_Pin { get; set; }
		public List<int> Ordens { get; private set; }
		public Controller Design { get; set; }

		public string Title {
			get {
				return title;
			}
			set {
				title = value;
				Design.SetTitle(value);
			}
		}

		public Status Status {
			get {
				return status;
			}
			set {
				status = value;
				if (Ordens.Count == 0)
					Design.SetStatus(value);
			}
		}

		private string title;
		private Status status;
		private Controles parent;

		public void AddDesign () {
			if (!parent.Visible)
				return;

			if (!parent.IsHandleCreated)
				Thread.Sleep(150);

			try {
				parent.Invoke(parent.myDelegate, Design);
			} catch { }
		}

		public void AddToOrder (int order_id) {
			Ordens.Add(order_id);
		}

		public void RemoveFromOrder (int order_id) {
			Ordens.Remove(order_id);
		}

		public void UpdateDesign () {
			Design.SetStatus(Status);
		}
	}

	public struct Order {
		public Order (int id, Status ordem, Ctrl controller) {
			this.ordem = false;
			controller.Status = Status.Ordem;

			Id = id;
			Cumprida = false;
			Controller = controller;
			Sent = null;
			Ordem = ordem;

			Controller.AddToOrder(Id);
		}

		public int Id { get; set; }
		public bool Cumprida { get; private set; }
		public Ctrl Controller { get; set; }
		public DateTime? Sent { get; private set; }

		public Status Ordem {
			get {
				return (ordem) ? Status.Ligado : Status.Desligado;
			}
			set {
				ordem = value == Status.Ligado;
			}
		}

		private bool ordem;

		public void Send () {
			Controller.Design.canCancel = false;
			Sent = DateTime.Now;
		}

		public void Executed () {
			Controller.RemoveFromOrder(Id);
			Controller.UpdateDesign();
			Cumprida = true;
		}
	}

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

		private List<Ctrl> controllers;
		private List<Order> orders;

		public bool updating;
		public ControlesDelegate myDelegate;
		public delegate void ControlesDelegate (Controller ctrl);

		public void AddController (Controller ctrl) {
			flowLayoutPanel1.Controls.Add(ctrl);
		}

		private void UpdateControllers () {
			while (updating) {
				if (controllers.Count < Geral.ControlesPlano()) { // Check plan limit to avoid making new SQL reuqest
																  // Get new controllers
					Login.offline.Select("SELECT rele_pin, rele_nome, estado FROM reles WHERE em_uso ORDER BY rele_nome ASC");
					foreach (string[] onRow in Login.offline.SelectResult.Skip(1)) {
						var exists = (from c in controllers
									  where c.Rele_Pin.ToString() == onRow[0]
									  select c).Count() > 0;

						if (!exists && controllers.Count < Geral.ControlesPlano()) { // Check plan for all new controllers
							Console.WriteLine("Init >> " + onRow[1]);
							int rele_pin;
							int.TryParse(onRow[0], out rele_pin);
							Status status = (onRow[2] == "False" || onRow[2] == "0") ? Status.Desligado : Status.Ligado;
							controllers.Add(new Ctrl(rele_pin, onRow[1], status, this));
						}
					}
				}

				// Get new orders
				Login.offline.Select("SELECT id, rele_pin, ordem FROM ordens_pendentes ORDER BY envio ASC");
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

				if (Login.conexaoIntance != null) {
					if (Login.conexaoIntance.Connected) {
						// Start new controllers


						// Handle orders

					}
				}

				Thread.Sleep(6000);
			}
		}

		private void Controles_FormClosing (object sender, FormClosingEventArgs e) {
			updating = false;
		}

		public void Controles_Shown (object sender = null, EventArgs e = null) {
			controllers.ForEach((Ctrl control) => {
				if (!flowLayoutPanel1.Controls.Contains(control.Design))
					control.AddDesign();
			});
		}
	}
}
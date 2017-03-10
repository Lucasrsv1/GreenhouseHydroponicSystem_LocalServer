using System;

namespace Greenhouse_Hydroponic_System {
	public class Order {
		public Order (int id, int local_id, Status ordem, Ctrl controller) {
			this.ordem = false;
			originalStatus = controller.Status;
			controller.Status = Status.Ordem;
			controller.SetOrdemId(id);

			Id = id;
			Local_Id = local_id;
			Cumprida = false;
			Controller = controller;
			Sent = null;
			Ordem = ordem;

			Controller.AddToOrder(Id);
			Login.offline.Update("UPDATE ordens SET processada = FALSE WHERE id = " + Id);
		}

		public int Id { get; set; }
		public int Local_Id { get; set; }
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
		private Status originalStatus;

		public void Send () {
			Controller.Design.canCancel = false;
			Login.offline.Update("UPDATE ordens SET processada = TRUE WHERE id = " + Id);
			Sent = DateTime.Now;
		}

		public void ConnectionLost () {
			Controller.Design.canCancel = true;
			Login.offline.Update("UPDATE ordens SET processada = FALSE WHERE id = " + Id);
			Sent = null;
		}

		public void Executed () {
			Controller.RemoveFromOrder();
			Controller.UpdateDesign(Ordem);

			if (Login.offline.Update("UPDATE reles SET estado = " + (int)Ordem + " WHERE rele_pin = " + Controller.Rele_Pin) > 0) {
				Login.offline.Update("UPDATE ordens SET cumprida = TRUE, executada = CURRENT_TIMESTAMP WHERE id = " + Id);
			} else {
				Console.WriteLine("ERROR: " + Controller.Design.GetTitle() + " [UPDATE reles SET estado = " + (int)Ordem + " WHERE rele_pin = " + Controller.Rele_Pin + "]");
			}
			Cumprida = true;
		}

		public void Canceled () {
			Console.WriteLine("Canceled: " + Controller.Design.GetTitle());
			Sent = DateTime.Now;
			Controller.SetOrdemId(-1);
			Controller.RemoveFromOrder();
			Controller.UpdateDesign(originalStatus);
			Cumprida = true;
			Login.controlesIntance.UpdateControllers(true);
		}
	}
}
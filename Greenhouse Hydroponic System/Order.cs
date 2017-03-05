using System;

namespace Greenhouse_Hydroponic_System {
	public class Order {
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

		public void ConnectionLost () {
			Controller.Design.canCancel = true;
			Sent = null;
		}

		public void Executed () {
			Controller.RemoveFromOrder(Id);
			Controller.UpdateDesign(Ordem);
			Cumprida = true;

			if (Login.offline.Update("UPDATE reles SET estado = " + (int)Ordem + " WHERE rele_pin = " + Controller.Rele_Pin) > 0)
				Login.offline.Update("UPDATE ordens SET cumprida = TRUE, executada = CURRENT_TIMESTAMP WHERE id = " + Id);
		}
	}
}
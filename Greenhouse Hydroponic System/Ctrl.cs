using System.Collections.Generic;
using System.Threading;

namespace Greenhouse_Hydroponic_System {
	public class Ctrl {
		public Ctrl (int rele_id, int rele_pin, string title, Status status, Controles form, bool started) {
			this.title = title;
			this.status = status;
			parent = form;

			Rele_Pin = rele_pin;
			Started = started;
			Design = new Controller(rele_id);
			Ordem_Id = -1;
			Title = title;
			Status = status;

			AddDesign();
		}

		public int Rele_Pin { get; set; }
		public bool Started { get; set; }
		public int Ordem_Id { get; private set; }
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
				if (Ordem_Id <= 0)
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
			Ordem_Id = order_id;
		}

		public void RemoveFromOrder () {
			Ordem_Id = -1;
		}

		public void SetOrdemId (int id) {
			Design.SetOrdemId(id);
		}

		public void UpdateDesign (Status newStatus) {
			Status = newStatus;
		}

		public void ConnectionLost () {
			Started = false;
		}
	}
}
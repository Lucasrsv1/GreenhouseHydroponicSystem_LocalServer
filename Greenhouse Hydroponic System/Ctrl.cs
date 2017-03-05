using System.Collections.Generic;
using System.Threading;

namespace Greenhouse_Hydroponic_System {
	public class Ctrl {
		public Ctrl (int rele_pin, string title, Status status, Controles form, bool started) {
			this.title = title;
			this.status = status;
			parent = form;

			Rele_Pin = rele_pin;
			Started = started;
			Design = new Controller();
			Ordens = new List<int>();
			Title = title;
			Status = status;

			AddDesign();
		}

		public int Rele_Pin { get; set; }
		public bool Started { get; set; }
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

		public void UpdateDesign (Status newStatus) {
			Status = newStatus;
		}

		public void ConnectionLost () {
			Started = false;
		}
	}
}
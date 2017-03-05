using System;
using Greenhouse_Hydroponic_System.Properties;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public enum Status { Desligado, Ligado, Ordem }

	public partial class Controller : UserControl {
		public Controller () {
			InitializeComponent();
			status.Tag = null;
		}

		public bool canCancel;

		public void SetTitle (string text) {
			title.Text = text;
		}

		public void SetStatus (Status value) {
			switch (value) {
				case Status.Desligado:
					status.Image = Resources.Desligado;
					break;
				case Status.Ligado:
					status.Image = Resources.Ligado;
					break;
				case Status.Ordem:
					status.Image = Resources.Ordem;
					break;
			}

			canCancel = true;
			status.Tag = value;
		}

		private void status_Click (object sender, EventArgs e) {
			if (status.Tag != null) {
				Status current = (Status)status.Tag;
				switch (current) {
					case Status.Desligado:
						Console.WriteLine("Turn on " + title.Text);
						break;
					case Status.Ligado:
						Console.WriteLine("Turn off " + title.Text);
						break;
					case Status.Ordem:
						if (canCancel)
							Console.WriteLine("Cancel order for " + title.Text);
						else
							Console.WriteLine("Can't cancel the order for " + title.Text);
						break;
				}
			}
		}
	}
}

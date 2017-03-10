using System;
using Greenhouse_Hydroponic_System.Properties;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public enum Status { Desligado, Ligado, Ordem }

	public partial class Controller : UserControl {
		public Controller (int rele_id) {
			InitializeComponent();

			ordem_id = -1;
			status.Tag = null;
			this.rele_id = rele_id;
		}

		private int rele_id;
		private int ordem_id;

		public bool canCancel;

		public void SetOrdemId (int id) {
			ordem_id = id;
		}

		public void SetTitle (string text) {
			title.Text = text;
		}

		public string GetTitle () {
			return title.Text;
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
						if (Login.offline.InsertInto("INSERT INTO ordens (empresas_id, contas_id, reles_id, ordem) VALUES (" + Geral.EmpresaId() + ", " + Geral.ContaId() + ", " + rele_id + ", 1)") > 0)
							Login.controlesIntance.UpdateControllers(true);
						break;
					case Status.Ligado:
						Console.WriteLine("Turn off " + title.Text);
						if (Login.offline.InsertInto("INSERT INTO ordens (empresas_id, contas_id, reles_id, ordem) VALUES (" + Geral.EmpresaId() + ", " + Geral.ContaId() + ", " + rele_id + ", 0)") > 0)
							Login.controlesIntance.UpdateControllers(true);
						break;
					case Status.Ordem:
						if (canCancel) {
							Console.WriteLine("Cancel order for " + title.Text);
							if (Login.offline.DeleteFrom("DELETE FROM ordens WHERE id = " + ordem_id + " AND empresas_id = " + Geral.EmpresaId() + " AND reles_id = " + rele_id + " AND !cumprida") > 0) {
								foreach (Order order in Login.controlesIntance.orders) {
									if (order.Id == ordem_id) {
										order.Canceled();
										break;
									}
								};
							}
						} else {
							MessageBox.Show("Não foi possível cancelar a ordem para " + title.Text + ". A ordem já foi enviada ou executada.", "Falha ao cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						break;
				}
			}
		}
	}
}

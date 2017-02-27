using System;
using System.Drawing;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public partial class Menu : UserControl {
		public void SetParent (Form value) {
			parent = value;
			switch (parent.Text) {
				case "Informações Gerais":
					inicio.BackColor = Color.FromArgb(125, 125, 125);
					locked = 0;
					break;
				case "Controles":
					controles.BackColor = Color.FromArgb(125, 125, 125);
					locked = 1;
					break;
				case "Estatísticas":
					estatisticas.BackColor = Color.FromArgb(125, 125, 125);
					locked = 2;
					break;
				case "Conexão":
					conexao.BackColor = Color.FromArgb(125, 125, 125);
					locked = 3;
					break;
			}

		}

		private int locked;
		private Form parent;

		public Menu () {
			InitializeComponent();
		}

		private void BtnMouseEnter (object sender, EventArgs e) {
			Label s = (Label)sender;
			if (s.BackColor.R == 80)
				s.BackColor = Color.FromArgb(95, 95, 95);
		}

		private void BtnMouseLeave (object sender, EventArgs e) {
			Label s = (Label)sender;
			if (s.BackColor.R == 95)
				s.BackColor = Color.FromArgb(80, 80, 80);
		}

		private void inicio_Click (object sender, EventArgs e) {
			if (locked != 0)
				Login.LoadForm(Forms.Geral, ParentForm);
		}

		private void controles_Click (object sender, EventArgs e) {
			if (locked != 1)
				Login.LoadForm(Forms.Controles, ParentForm);
		}

		private void estatisticas_Click (object sender, EventArgs e) {
			if (locked != 2)
				Login.LoadForm(Forms.Estatisticas, ParentForm);
		}

		private void conexao_Click (object sender, EventArgs e) {
			if (locked != 3)
				Login.LoadForm(Forms.Conexao, ParentForm);
		}
	}
}

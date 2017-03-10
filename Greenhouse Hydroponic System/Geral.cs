using System.Diagnostics;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public partial class Geral : Form {
		public Geral () {
			InitializeComponent();
			menu.SetParent(this);
			help.Links.Add(help.LinkArea.Start, help.LinkArea.Length, "file:///" + Application.StartupPath.Replace("\\", "/") + "/help.html");

			if (conta != null)
				infoConta.Text = "Nome: " + conta[6] + " " + conta[7] + "\nUsuário: " + conta[2] + "\nTipo: " + conta[4] + "\nEmail: " + conta[8] + "\nTelefone(s): " + conta[9];

			if (empresa != null)
				infoEmpresa.Text = "Nome: " + empresa[2] + "\nCNPJ: " + empresa[3] + "\nInscrição Estadual: " + empresa[4] + "\nTelefone(s): " + empresa[11] + "\nResponsável: " + empresa[12] + "\nEmail: " + empresa[10] + "\nEndereço: " + empresa[5] + "; " + empresa[6] + ", " + empresa[7] + " - " + empresa[8];

			if (plano != null)
				infoPlano.Text = "Plano: " + plano[2] + "\nValor: R$" + plano[8] + "\nTipo: " + plano[9] + "\nContratado em: " + DateFormat(plano[6]) + "\nExpira em: " + DateFormat(plano[7]) + "\nQuantidade de Controles: " + plano[3] + "\nQuantidade de Estatísticas: " + plano[4] + "\nQuantidade de Servidores Locais: " + plano[5];
		}

		public static string[] conta;
		public static string[] empresa;
		public static string[] plano;

		public static int EstatisticasPlano () {
			int total = -1;
			if (plano.Length > 3)
				int.TryParse(plano[3], out total);
			return total;
		}

		public static int ControlesPlano () {
			int total = -1;
			if (plano.Length > 4)
				int.TryParse(plano[4], out total);
			return total;
		}

		public static int EmpresaId () {
			int id = -1;
			if (empresa.Length > 0)
				int.TryParse(empresa[0], out id);
			return id;
		}

		public static int ContaId () {
			int id = -1;
			if (conta.Length > 0)
				int.TryParse(conta[0], out id);
			return id;
		}

		private string DateFormat (string datetime) {
			return datetime.Substring(0, 10);
		}

		private void help_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e) {
			help.LinkVisited = true;
			Process.Start(e.Link.LinkData.ToString());
		}
	}
}
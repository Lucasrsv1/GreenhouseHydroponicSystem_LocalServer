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

		private string DateFormat (string datetime) {
			return datetime.Substring(0, 10);
		}

		private void help_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start(e.Link.LinkData.ToString());
		}
	}
}
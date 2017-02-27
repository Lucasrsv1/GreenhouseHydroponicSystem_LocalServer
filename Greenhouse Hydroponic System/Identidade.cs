using Greenhouse_Hydroponic_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public partial class Identidade : UserControl {
		public Identidade () {
			InitializeComponent();
			if (Geral.conta != null) {
				if (Geral.conta[4] == "Administrador")
					tipo.Image = Resources.administrador;
				else
					tipo.Image = Resources.operario;

				username.Text = Geral.conta[2];
			}
		}
	}
}

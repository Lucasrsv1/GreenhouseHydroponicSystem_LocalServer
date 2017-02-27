using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public partial class DatabaseConfig : Form {
		public DatabaseConfig () {
			InitializeComponent();

			username.Text = Login.offlineUser;
			password.Text = Login.offlinePassword;

			if (username.Text.Length > 0)
				username.ForeColor = Color.Black;

			if (password.Text.Length > 0)
				password.ForeColor = Color.Black;
		}

		private void textbox_Enter (object sender, EventArgs e) {
			TextBox textBox = (TextBox)sender;
			if (textBox.ForeColor == Color.Silver) {
				textBox.Text = "";
				textBox.ForeColor = Color.Black;
			}
		}

		private void textbox_Leave (object sender, EventArgs e) {
			TextBox textBox = (TextBox)sender;
			if (textBox.Text == "") {
				textBox.Text = textBox.Tag.ToString();
				textBox.ForeColor = Color.Silver;
			}
		}

		private void panel1_Click (object sender, EventArgs e) {
			username.Focus();
		}

		private void panel2_Click (object sender, EventArgs e) {
			password.Focus();
		}

		private void confirm_Click (object sender, EventArgs e) {
			Login.offlineUser = username.Text;
			Login.offlinePassword = password.Text;
			Close();
		}
	}
}
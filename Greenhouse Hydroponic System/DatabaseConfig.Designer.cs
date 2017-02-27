namespace Greenhouse_Hydroponic_System {
	partial class DatabaseConfig {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseConfig));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.confirm = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.password = new System.Windows.Forms.TextBox();
			this.username = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(391, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Configurar Conexão Local";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Usuário:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 25);
			this.label3.TabIndex = 2;
			this.label3.Text = "Senha:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// confirm
			// 
			this.confirm.Font = new System.Drawing.Font("Roboto Lt", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.confirm.Location = new System.Drawing.Point(170, 145);
			this.confirm.Name = "confirm";
			this.confirm.Size = new System.Drawing.Size(75, 28);
			this.confirm.TabIndex = 5;
			this.confirm.Text = "OK";
			this.confirm.UseVisualStyleBackColor = true;
			this.confirm.Click += new System.EventHandler(this.confirm_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Window;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.password);
			this.panel2.Location = new System.Drawing.Point(116, 98);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(284, 33);
			this.panel2.TabIndex = 9;
			this.panel2.Click += new System.EventHandler(this.panel2_Click);
			// 
			// password
			// 
			this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.password.Font = new System.Drawing.Font("Roboto Lt", 8F);
			this.password.ForeColor = System.Drawing.Color.Silver;
			this.password.Location = new System.Drawing.Point(8, 9);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(266, 13);
			this.password.TabIndex = 3;
			this.password.Tag = "Password";
			this.password.Text = "Password";
			this.password.UseSystemPasswordChar = true;
			this.password.Enter += new System.EventHandler(this.textbox_Enter);
			this.password.Leave += new System.EventHandler(this.textbox_Leave);
			// 
			// username
			// 
			this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.username.Font = new System.Drawing.Font("Roboto Lt", 12F);
			this.username.ForeColor = System.Drawing.Color.Silver;
			this.username.Location = new System.Drawing.Point(8, 7);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(266, 20);
			this.username.TabIndex = 2;
			this.username.Tag = "Username";
			this.username.Text = "Username";
			this.username.Enter += new System.EventHandler(this.textbox_Enter);
			this.username.Leave += new System.EventHandler(this.textbox_Leave);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.username);
			this.panel1.Location = new System.Drawing.Point(116, 53);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(284, 33);
			this.panel1.TabIndex = 8;
			this.panel1.Click += new System.EventHandler(this.panel1_Click);
			// 
			// DatabaseConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(412, 183);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.confirm);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "DatabaseConfig";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuração da Base de Dados Local";
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button confirm;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.Panel panel1;
	}
}
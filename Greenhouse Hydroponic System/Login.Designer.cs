namespace Greenhouse_Hydroponic_System {
	partial class Login {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.username = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.sign_in = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.label1.Font = new System.Drawing.Font("Sansation Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(100, 0);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(700, 70);
			this.label1.TabIndex = 0;
			this.label1.Text = "Greenhouse Hydroponic System";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Roboto Lt", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label2.Location = new System.Drawing.Point(150, 176);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(500, 40);
			this.label2.TabIndex = 1;
			this.label2.Text = "Por favor, entre na sua conta";
			// 
			// username
			// 
			this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.username.Font = new System.Drawing.Font("Roboto Lt", 12F);
			this.username.ForeColor = System.Drawing.Color.Silver;
			this.username.Location = new System.Drawing.Point(8, 7);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(204, 20);
			this.username.TabIndex = 2;
			this.username.Tag = "Username";
			this.username.Text = "Username";
			this.username.Enter += new System.EventHandler(this.textbox_Enter);
			this.username.Leave += new System.EventHandler(this.textbox_Leave);
			// 
			// password
			// 
			this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.password.Font = new System.Drawing.Font("Roboto Lt", 8F);
			this.password.ForeColor = System.Drawing.Color.Silver;
			this.password.Location = new System.Drawing.Point(8, 9);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(204, 13);
			this.password.TabIndex = 3;
			this.password.Tag = "Password";
			this.password.Text = "Password";
			this.password.UseSystemPasswordChar = true;
			this.password.Enter += new System.EventHandler(this.textbox_Enter);
			this.password.Leave += new System.EventHandler(this.textbox_Leave);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Roboto Lt", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label3.Location = new System.Drawing.Point(153, 216);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(497, 40);
			this.label3.TabIndex = 4;
			this.label3.Text = "Se não souber suas credenciais, entre em contato com o administrador da sua empre" +
    "sa.";
			// 
			// sign_in
			// 
			this.sign_in.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sign_in.Location = new System.Drawing.Point(535, 339);
			this.sign_in.Name = "sign_in";
			this.sign_in.Size = new System.Drawing.Size(115, 35);
			this.sign_in.TabIndex = 5;
			this.sign_in.Text = "Entrar";
			this.sign_in.UseVisualStyleBackColor = true;
			this.sign_in.Click += new System.EventHandler(this.sign_in_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.pictureBox1.Image = global::Greenhouse_Hydroponic_System.Properties.Resources.alface_mimosa_g;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 70);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.username);
			this.panel1.Location = new System.Drawing.Point(156, 281);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(220, 33);
			this.panel1.TabIndex = 7;
			this.panel1.Click += new System.EventHandler(this.panel1_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Window;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.password);
			this.panel2.Location = new System.Drawing.Point(430, 281);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(220, 33);
			this.panel2.TabIndex = 8;
			this.panel2.Click += new System.EventHandler(this.panel2_Click);
			// 
			// Login
			// 
			this.AcceptButton = this.sign_in;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 480);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.sign_in);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Login";
			this.RightToLeftLayout = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Greenhouse Hydroponic System";
			this.Load += new System.EventHandler(this.Login_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button sign_in;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}


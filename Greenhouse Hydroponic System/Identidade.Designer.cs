namespace Greenhouse_Hydroponic_System {
	partial class Identidade {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.username = new System.Windows.Forms.Label();
			this.tipo = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.tipo)).BeginInit();
			this.SuspendLayout();
			// 
			// username
			// 
			this.username.Font = new System.Drawing.Font("Sansation Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.username.ForeColor = System.Drawing.Color.White;
			this.username.Location = new System.Drawing.Point(0, 0);
			this.username.Margin = new System.Windows.Forms.Padding(0);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(230, 50);
			this.username.TabIndex = 0;
			this.username.Text = "Username";
			this.username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tipo
			// 
			this.tipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
			this.tipo.Image = global::Greenhouse_Hydroponic_System.Properties.Resources.administrador;
			this.tipo.Location = new System.Drawing.Point(240, 0);
			this.tipo.Margin = new System.Windows.Forms.Padding(0);
			this.tipo.Name = "tipo";
			this.tipo.Size = new System.Drawing.Size(50, 50);
			this.tipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.tipo.TabIndex = 1;
			this.tipo.TabStop = false;
			// 
			// Identidade
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.Controls.Add(this.tipo);
			this.Controls.Add(this.username);
			this.Name = "Identidade";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.Size = new System.Drawing.Size(290, 50);
			((System.ComponentModel.ISupportInitialize)(this.tipo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label username;
		private System.Windows.Forms.PictureBox tipo;
	}
}

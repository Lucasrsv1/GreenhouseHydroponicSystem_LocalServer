namespace Greenhouse_Hydroponic_System {
	partial class Menu {
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
			this.inicio = new System.Windows.Forms.Label();
			this.controles = new System.Windows.Forms.Label();
			this.estatisticas = new System.Windows.Forms.Label();
			this.conexao = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// inicio
			// 
			this.inicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.inicio.Font = new System.Drawing.Font("Sansation Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inicio.ForeColor = System.Drawing.Color.White;
			this.inicio.Location = new System.Drawing.Point(0, 0);
			this.inicio.Name = "inicio";
			this.inicio.Size = new System.Drawing.Size(120, 50);
			this.inicio.TabIndex = 0;
			this.inicio.Text = "Início";
			this.inicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.inicio.Click += new System.EventHandler(this.inicio_Click);
			this.inicio.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
			this.inicio.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
			// 
			// controles
			// 
			this.controles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.controles.Font = new System.Drawing.Font("Sansation Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.controles.ForeColor = System.Drawing.Color.White;
			this.controles.Location = new System.Drawing.Point(122, 0);
			this.controles.Name = "controles";
			this.controles.Size = new System.Drawing.Size(120, 50);
			this.controles.TabIndex = 1;
			this.controles.Text = "Controles";
			this.controles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.controles.Click += new System.EventHandler(this.controles_Click);
			this.controles.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
			this.controles.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
			// 
			// estatisticas
			// 
			this.estatisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.estatisticas.Font = new System.Drawing.Font("Sansation Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.estatisticas.ForeColor = System.Drawing.Color.White;
			this.estatisticas.Location = new System.Drawing.Point(244, 0);
			this.estatisticas.Name = "estatisticas";
			this.estatisticas.Size = new System.Drawing.Size(120, 50);
			this.estatisticas.TabIndex = 2;
			this.estatisticas.Text = "Estatísticas";
			this.estatisticas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.estatisticas.Click += new System.EventHandler(this.estatisticas_Click);
			this.estatisticas.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
			this.estatisticas.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
			// 
			// conexao
			// 
			this.conexao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.conexao.Font = new System.Drawing.Font("Sansation Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.conexao.ForeColor = System.Drawing.Color.White;
			this.conexao.Location = new System.Drawing.Point(366, 0);
			this.conexao.Name = "conexao";
			this.conexao.Size = new System.Drawing.Size(120, 50);
			this.conexao.TabIndex = 3;
			this.conexao.Text = "Arduino";
			this.conexao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.conexao.Click += new System.EventHandler(this.conexao_Click);
			this.conexao.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
			this.conexao.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
			// 
			// Menu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.Controls.Add(this.conexao);
			this.Controls.Add(this.estatisticas);
			this.Controls.Add(this.controles);
			this.Controls.Add(this.inicio);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.Name = "Menu";
			this.Size = new System.Drawing.Size(488, 50);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label inicio;
		private System.Windows.Forms.Label controles;
		private System.Windows.Forms.Label estatisticas;
		private System.Windows.Forms.Label conexao;
	}
}

namespace Greenhouse_Hydroponic_System {
	partial class Conexao {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Conexao));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.auto = new System.Windows.Forms.Button();
			this.salvar = new System.Windows.Forms.Button();
			this.leonardo = new System.Windows.Forms.Label();
			this.baudRate = new System.Windows.Forms.NumericUpDown();
			this.portName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.currentConfig = new System.Windows.Forms.Label();
			this.separator1 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.serialPort = new System.IO.Ports.SerialPort(this.components);
			this.menu = new Greenhouse_Hydroponic_System.Menu();
			this.identidade1 = new Greenhouse_Hydroponic_System.Identidade();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.baudRate)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 480);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 488F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.menu, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 50);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.identidade1, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(488, 0);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(312, 50);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.auto);
			this.panel1.Controls.Add(this.salvar);
			this.panel1.Controls.Add(this.leonardo);
			this.panel1.Controls.Add(this.baudRate);
			this.panel1.Controls.Add(this.portName);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.currentConfig);
			this.panel1.Controls.Add(this.separator1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 53);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(794, 424);
			this.panel1.TabIndex = 1;
			// 
			// auto
			// 
			this.auto.Font = new System.Drawing.Font("Roboto Lt", 12F);
			this.auto.Location = new System.Drawing.Point(244, 366);
			this.auto.Name = "auto";
			this.auto.Size = new System.Drawing.Size(160, 30);
			this.auto.TabIndex = 16;
			this.auto.Text = "Auto Identificar";
			this.auto.UseVisualStyleBackColor = true;
			this.auto.Click += new System.EventHandler(this.auto_Click);
			// 
			// salvar
			// 
			this.salvar.Font = new System.Drawing.Font("Roboto Lt", 12F);
			this.salvar.Location = new System.Drawing.Point(44, 366);
			this.salvar.Name = "salvar";
			this.salvar.Size = new System.Drawing.Size(191, 30);
			this.salvar.TabIndex = 15;
			this.salvar.Text = "Salvar Configuração";
			this.salvar.UseVisualStyleBackColor = true;
			this.salvar.Click += new System.EventHandler(this.salvar_Click);
			// 
			// leonardo
			// 
			this.leonardo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(100)))), ((int)(((byte)(86)))));
			this.leonardo.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.leonardo.ForeColor = System.Drawing.Color.White;
			this.leonardo.Location = new System.Drawing.Point(244, 323);
			this.leonardo.Name = "leonardo";
			this.leonardo.Size = new System.Drawing.Size(160, 30);
			this.leonardo.TabIndex = 14;
			this.leonardo.Text = "NÃO";
			this.leonardo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.leonardo.Click += new System.EventHandler(this.leonardo_Click);
			// 
			// baudRate
			// 
			this.baudRate.Font = new System.Drawing.Font("Roboto Lt", 14.25F);
			this.baudRate.Location = new System.Drawing.Point(244, 280);
			this.baudRate.Maximum = new decimal(new int[] {
            115200,
            0,
            0,
            0});
			this.baudRate.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.baudRate.Name = "baudRate";
			this.baudRate.Size = new System.Drawing.Size(160, 30);
			this.baudRate.TabIndex = 13;
			this.baudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.baudRate.Value = new decimal(new int[] {
            9600,
            0,
            0,
            0});
			// 
			// portName
			// 
			this.portName.Font = new System.Drawing.Font("Roboto Lt", 14.25F);
			this.portName.Location = new System.Drawing.Point(244, 239);
			this.portName.Name = "portName";
			this.portName.Size = new System.Drawing.Size(160, 30);
			this.portName.TabIndex = 12;
			this.portName.Text = "COM1";
			this.portName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(40, 327);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(165, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "Arduino Leonardo:";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(40, 282);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(195, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Taxa de Transmissão:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(40, 242);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(195, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Identificador da Porta:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
			this.label2.Location = new System.Drawing.Point(19, 226);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(758, 1);
			this.label2.TabIndex = 8;
			this.label2.Tag = "18";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Sansation Light", 18F);
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(17, 198);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(221, 27);
			this.label3.TabIndex = 7;
			this.label3.Text = "Configurar conexão";
			// 
			// currentConfig
			// 
			this.currentConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.currentConfig.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.currentConfig.ForeColor = System.Drawing.Color.White;
			this.currentConfig.Location = new System.Drawing.Point(40, 49);
			this.currentConfig.Name = "currentConfig";
			this.currentConfig.Size = new System.Drawing.Size(728, 143);
			this.currentConfig.TabIndex = 6;
			this.currentConfig.Text = "Estado: DESCONECTADO\r\nPorta: -\r\nTaxa de Transmissão: -\r\nArduino Leonardo: NÃO\r\nLe" +
    "itura Mais Recente: -\r\nComando Mais Recente: -";
			// 
			// separator1
			// 
			this.separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
			this.separator1.Location = new System.Drawing.Point(11, 37);
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(758, 1);
			this.separator1.TabIndex = 5;
			this.separator1.Tag = "18";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Sansation Light", 18F);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(392, 27);
			this.label1.TabIndex = 0;
			this.label1.Text = "Atual conexão com a placa Arduino";
			// 
			// menu
			// 
			this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.menu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Margin = new System.Windows.Forms.Padding(0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(488, 50);
			this.menu.TabIndex = 0;
			// 
			// identidade1
			// 
			this.identidade1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.identidade1.Location = new System.Drawing.Point(22, 0);
			this.identidade1.Margin = new System.Windows.Forms.Padding(0);
			this.identidade1.Name = "identidade1";
			this.identidade1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.identidade1.Size = new System.Drawing.Size(290, 50);
			this.identidade1.TabIndex = 0;
			// 
			// Conexao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(800, 480);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(816, 519);
			this.Name = "Conexao";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Conexão com o Arduino";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.baudRate)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private Menu menu;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private Identidade identidade1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label separator1;
		private System.Windows.Forms.Label currentConfig;
		private System.Windows.Forms.TextBox portName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public System.IO.Ports.SerialPort serialPort;
		private System.Windows.Forms.Button salvar;
		private System.Windows.Forms.Label leonardo;
		private System.Windows.Forms.NumericUpDown baudRate;
		private System.Windows.Forms.Button auto;
	}
}
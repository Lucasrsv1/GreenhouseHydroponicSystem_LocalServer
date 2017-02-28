namespace Greenhouse_Hydroponic_System {
	partial class Controller {
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
			this.title = new System.Windows.Forms.Label();
			this.separator = new System.Windows.Forms.Label();
			this.status = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.status)).BeginInit();
			this.SuspendLayout();
			// 
			// title
			// 
			this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.title.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.title.Location = new System.Drawing.Point(0, 0);
			this.title.Margin = new System.Windows.Forms.Padding(0);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(238, 50);
			this.title.TabIndex = 0;
			this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// separator
			// 
			this.separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.separator.Location = new System.Drawing.Point(0, 50);
			this.separator.Margin = new System.Windows.Forms.Padding(0);
			this.separator.Name = "separator";
			this.separator.Size = new System.Drawing.Size(240, 1);
			this.separator.TabIndex = 1;
			// 
			// status
			// 
			this.status.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.status.Location = new System.Drawing.Point(5, 56);
			this.status.Margin = new System.Windows.Forms.Padding(0);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(228, 138);
			this.status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.status.TabIndex = 2;
			this.status.TabStop = false;
			this.status.Click += new System.EventHandler(this.status_Click);
			// 
			// Controller
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.status);
			this.Controls.Add(this.separator);
			this.Controls.Add(this.title);
			this.Margin = new System.Windows.Forms.Padding(14, 8, 0, 0);
			this.Name = "Controller";
			this.Size = new System.Drawing.Size(238, 198);
			((System.ComponentModel.ISupportInitialize)(this.status)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label title;
		private System.Windows.Forms.Label separator;
		private System.Windows.Forms.PictureBox status;
	}
}

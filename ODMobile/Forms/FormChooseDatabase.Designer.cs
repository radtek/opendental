﻿namespace OpenDentMobile {
	partial class FormChooseDatabase {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu1;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.label1 = new System.Windows.Forms.Label();
			this.listDb = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(41,15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149,18);
			this.label1.Text = "Select Database";
			// 
			// listDb
			// 
			this.listDb.Location = new System.Drawing.Point(41,36);
			this.listDb.Name = "listDb";
			this.listDb.Size = new System.Drawing.Size(149,170);
			this.listDb.TabIndex = 2;
			this.listDb.SelectedIndexChanged += new System.EventHandler(this.listDb_SelectedIndexChanged);
			// 
			// FormChooseDatabase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F,96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240,268);
			this.Controls.Add(this.listDb);
			this.Controls.Add(this.label1);
			this.Menu = this.mainMenu1;
			this.Name = "FormChooseDatabase";
			this.Text = "FormChooseDatabase";
			this.Load += new System.EventHandler(this.FormChooseDatabase_Load);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormChooseDatabase_Closing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listDb;
	}
}
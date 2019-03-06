namespace LevelEditor
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.loadButton = new System.Windows.Forms.Button();
            this.createMapButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heightText = new System.Windows.Forms.TextBox();
            this.widthText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 12);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(220, 45);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load Map";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // createMapButton
            // 
            this.createMapButton.Location = new System.Drawing.Point(6, 72);
            this.createMapButton.Name = "createMapButton";
            this.createMapButton.Size = new System.Drawing.Size(208, 45);
            this.createMapButton.TabIndex = 1;
            this.createMapButton.Text = "Create Map";
            this.createMapButton.UseVisualStyleBackColor = true;
            this.createMapButton.Click += new System.EventHandler(this.createMapButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.heightText);
            this.groupBox1.Controls.Add(this.widthText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.createMapButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 123);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create New Map";
            // 
            // heightText
            // 
            this.heightText.Location = new System.Drawing.Point(91, 46);
            this.heightText.Name = "heightText";
            this.heightText.Size = new System.Drawing.Size(123, 20);
            this.heightText.TabIndex = 5;
            // 
            // widthText
            // 
            this.widthText.Location = new System.Drawing.Point(91, 23);
            this.widthText.Name = "widthText";
            this.widthText.Size = new System.Drawing.Size(123, 20);
            this.widthText.TabIndex = 4;
            //this.widthText.TextChanged += new System.EventHandler(this.widthText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height (in tiles)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width (in tiles)";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 196);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loadButton);
            this.Name = "Form1";
            this.Text = "Level Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button loadButton;
		private System.Windows.Forms.Button createMapButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox heightText;
		private System.Windows.Forms.TextBox widthText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.IO.FileSystemWatcher fileSystemWatcher1;
	}
}


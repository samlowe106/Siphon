namespace LevelEditor
{
	partial class LevelEditor
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
			this.colors = new System.Windows.Forms.GroupBox();
			this.blackButton = new System.Windows.Forms.Button();
			this.blueButton = new System.Windows.Forms.Button();
			this.redButton = new System.Windows.Forms.Button();
			this.brownButton = new System.Windows.Forms.Button();
			this.greyButton = new System.Windows.Forms.Button();
			this.greenButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.sample = new System.Windows.Forms.PictureBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.loadButton = new System.Windows.Forms.Button();
			this.Map = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.colors.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sample)).BeginInit();
			this.Map.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// colors
			// 
			this.colors.Controls.Add(this.blackButton);
			this.colors.Controls.Add(this.blueButton);
			this.colors.Controls.Add(this.redButton);
			this.colors.Controls.Add(this.brownButton);
			this.colors.Controls.Add(this.greyButton);
			this.colors.Controls.Add(this.greenButton);
			this.colors.Location = new System.Drawing.Point(12, 12);
			this.colors.Name = "colors";
			this.colors.Size = new System.Drawing.Size(85, 131);
			this.colors.TabIndex = 0;
			this.colors.TabStop = false;
			this.colors.Text = "The Selector";
			// 
			// blackButton
			// 
			this.blackButton.BackColor = System.Drawing.Color.Black;
			this.blackButton.Location = new System.Drawing.Point(45, 95);
			this.blackButton.Name = "blackButton";
			this.blackButton.Size = new System.Drawing.Size(30, 30);
			this.blackButton.TabIndex = 5;
			this.blackButton.Text = " ";
			this.blackButton.UseVisualStyleBackColor = false;
			this.blackButton.Click += new System.EventHandler(this.blackButton_Click);
			// 
			// blueButton
			// 
			this.blueButton.BackColor = System.Drawing.Color.Aqua;
			this.blueButton.Location = new System.Drawing.Point(9, 95);
			this.blueButton.Name = "blueButton";
			this.blueButton.Size = new System.Drawing.Size(30, 30);
			this.blueButton.TabIndex = 4;
			this.blueButton.Text = " ";
			this.blueButton.UseVisualStyleBackColor = false;
			this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
			// 
			// redButton
			// 
			this.redButton.BackColor = System.Drawing.Color.Red;
			this.redButton.Location = new System.Drawing.Point(45, 59);
			this.redButton.Name = "redButton";
			this.redButton.Size = new System.Drawing.Size(30, 30);
			this.redButton.TabIndex = 3;
			this.redButton.Text = " ";
			this.redButton.UseVisualStyleBackColor = false;
			this.redButton.Click += new System.EventHandler(this.redButton_Click);
			// 
			// brownButton
			// 
			this.brownButton.BackColor = System.Drawing.Color.Brown;
			this.brownButton.Location = new System.Drawing.Point(9, 59);
			this.brownButton.Name = "brownButton";
			this.brownButton.Size = new System.Drawing.Size(30, 30);
			this.brownButton.TabIndex = 2;
			this.brownButton.Text = " ";
			this.brownButton.UseVisualStyleBackColor = false;
			this.brownButton.Click += new System.EventHandler(this.brownButton_Click);
			// 
			// greyButton
			// 
			this.greyButton.BackColor = System.Drawing.Color.Silver;
			this.greyButton.Location = new System.Drawing.Point(45, 23);
			this.greyButton.Name = "greyButton";
			this.greyButton.Size = new System.Drawing.Size(30, 30);
			this.greyButton.TabIndex = 1;
			this.greyButton.Text = " ";
			this.greyButton.UseVisualStyleBackColor = false;
			this.greyButton.Click += new System.EventHandler(this.greyButton_Click);
			// 
			// greenButton
			// 
			this.greenButton.BackColor = System.Drawing.Color.Lime;
			this.greenButton.Location = new System.Drawing.Point(9, 23);
			this.greenButton.Name = "greenButton";
			this.greenButton.Size = new System.Drawing.Size(30, 30);
			this.greenButton.TabIndex = 0;
			this.greenButton.Text = " ";
			this.greenButton.UseVisualStyleBackColor = false;
			this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.sample);
			this.groupBox1.Location = new System.Drawing.Point(12, 149);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(85, 88);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Current Tile";
			// 
			// sample
			// 
			this.sample.BackColor = System.Drawing.Color.Red;
			this.sample.Location = new System.Drawing.Point(20, 25);
			this.sample.Name = "sample";
			this.sample.Size = new System.Drawing.Size(45, 45);
			this.sample.TabIndex = 0;
			this.sample.TabStop = false;
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(12, 272);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(85, 52);
			this.saveButton.TabIndex = 2;
			this.saveButton.Text = "Save File";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// loadButton
			// 
			this.loadButton.Location = new System.Drawing.Point(12, 360);
			this.loadButton.Name = "loadButton";
			this.loadButton.Size = new System.Drawing.Size(85, 52);
			this.loadButton.TabIndex = 3;
			this.loadButton.Text = "Load File";
			this.loadButton.UseVisualStyleBackColor = true;
			this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
			// 
			// Map
			// 
			this.Map.Controls.Add(this.pictureBox2);
			this.Map.Location = new System.Drawing.Point(120, 12);
			this.Map.Name = "Map";
			this.Map.Size = new System.Drawing.Size(387, 400);
			this.Map.TabIndex = 4;
			this.Map.TabStop = false;
			this.Map.Text = "Map";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(6, 19);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(375, 375);
			this.pictureBox2.TabIndex = 0;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Visible = false;
			// 
			// LevelEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(519, 424);
			this.Controls.Add(this.Map);
			this.Controls.Add(this.loadButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.colors);
			this.Name = "LevelEditor";
			this.Text = "Level Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelEditor_FormClosing);
			this.colors.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sample)).EndInit();
			this.Map.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox colors;
		private System.Windows.Forms.Button blackButton;
		private System.Windows.Forms.Button blueButton;
		private System.Windows.Forms.Button redButton;
		private System.Windows.Forms.Button brownButton;
		private System.Windows.Forms.Button greyButton;
		private System.Windows.Forms.Button greenButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox sample;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button loadButton;
		private System.Windows.Forms.GroupBox Map;
		private System.Windows.Forms.PictureBox pictureBox2;
	}
}
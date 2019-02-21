namespace HW7
{
    partial class FormMap
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOrange = new System.Windows.Forms.Button();
            this.buttonGray = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonYellow = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxTile = new System.Windows.Forms.GroupBox();
            this.pictureBoxCurrentTile = new System.Windows.Forms.PictureBox();
            this.groupBoxMap = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentTile)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonOrange);
            this.groupBox1.Controls.Add(this.buttonGray);
            this.groupBox1.Controls.Add(this.buttonGreen);
            this.groupBox1.Controls.Add(this.buttonYellow);
            this.groupBox1.Controls.Add(this.buttonBlue);
            this.groupBox1.Controls.Add(this.buttonRed);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 188);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tile Selector";
            // 
            // buttonOrange
            // 
            this.buttonOrange.BackColor = System.Drawing.Color.Orange;
            this.buttonOrange.Location = new System.Drawing.Point(82, 119);
            this.buttonOrange.Name = "buttonOrange";
            this.buttonOrange.Size = new System.Drawing.Size(40, 40);
            this.buttonOrange.TabIndex = 11;
            this.buttonOrange.UseVisualStyleBackColor = false;
            this.buttonOrange.Click += new System.EventHandler(this.buttonOrange_Click);
            // 
            // buttonGray
            // 
            this.buttonGray.BackColor = System.Drawing.Color.Gray;
            this.buttonGray.Location = new System.Drawing.Point(17, 119);
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.Size = new System.Drawing.Size(40, 40);
            this.buttonGray.TabIndex = 10;
            this.buttonGray.UseVisualStyleBackColor = false;
            this.buttonGray.Click += new System.EventHandler(this.buttonGray_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonGreen.Location = new System.Drawing.Point(82, 69);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(40, 40);
            this.buttonGreen.TabIndex = 9;
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonYellow
            // 
            this.buttonYellow.BackColor = System.Drawing.Color.Yellow;
            this.buttonYellow.Location = new System.Drawing.Point(17, 69);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(40, 40);
            this.buttonYellow.TabIndex = 8;
            this.buttonYellow.UseVisualStyleBackColor = false;
            this.buttonYellow.Click += new System.EventHandler(this.buttonYellow_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.DarkTurquoise;
            this.buttonBlue.Location = new System.Drawing.Point(82, 19);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(40, 40);
            this.buttonBlue.TabIndex = 7;
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonBlue_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.Firebrick;
            this.buttonRed.Location = new System.Drawing.Point(17, 19);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(40, 40);
            this.buttonRed.TabIndex = 0;
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 439);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(136, 71);
            this.buttonLoad.TabIndex = 8;
            this.buttonLoad.Text = "Load File";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 332);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(136, 71);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save File";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxTile
            // 
            this.groupBoxTile.Controls.Add(this.pictureBoxCurrentTile);
            this.groupBoxTile.Location = new System.Drawing.Point(12, 204);
            this.groupBoxTile.Name = "groupBoxTile";
            this.groupBoxTile.Size = new System.Drawing.Size(136, 120);
            this.groupBoxTile.TabIndex = 10;
            this.groupBoxTile.TabStop = false;
            this.groupBoxTile.Text = "Current Tile";
            // 
            // pictureBoxCurrentTile
            // 
            this.pictureBoxCurrentTile.Location = new System.Drawing.Point(29, 24);
            this.pictureBoxCurrentTile.Name = "pictureBoxCurrentTile";
            this.pictureBoxCurrentTile.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxCurrentTile.TabIndex = 0;
            this.pictureBoxCurrentTile.TabStop = false;
            // 
            // groupBoxMap
            // 
            this.groupBoxMap.Location = new System.Drawing.Point(210, 12);
            this.groupBoxMap.Name = "groupBoxMap";
            this.groupBoxMap.Size = new System.Drawing.Size(500, 500);
            this.groupBoxMap.TabIndex = 11;
            this.groupBoxMap.TabStop = false;
            this.groupBoxMap.Text = "Current Map";
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 538);
            this.Controls.Add(this.groupBoxMap);
            this.Controls.Add(this.groupBoxTile);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMap_FormClosing);
            this.Load += new System.EventHandler(this.FormMap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxTile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentTile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOrange;
        private System.Windows.Forms.Button buttonGray;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxTile;
        private System.Windows.Forms.PictureBox pictureBoxCurrentTile;
        private System.Windows.Forms.GroupBox groupBoxMap;
    }
}
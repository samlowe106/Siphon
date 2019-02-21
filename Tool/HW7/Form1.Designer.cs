namespace HW7
{
    partial class FormCreate
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBoxTextBoxes = new System.Windows.Forms.GroupBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBoxTextBoxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(316, 92);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load Map";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // groupBoxTextBoxes
            // 
            this.groupBoxTextBoxes.Controls.Add(this.textBoxHeight);
            this.groupBoxTextBoxes.Controls.Add(this.textBoxWidth);
            this.groupBoxTextBoxes.Controls.Add(this.label2);
            this.groupBoxTextBoxes.Controls.Add(this.label1);
            this.groupBoxTextBoxes.Location = new System.Drawing.Point(12, 121);
            this.groupBoxTextBoxes.Name = "groupBoxTextBoxes";
            this.groupBoxTextBoxes.Size = new System.Drawing.Size(316, 155);
            this.groupBoxTextBoxes.TabIndex = 1;
            this.groupBoxTextBoxes.TabStop = false;
            this.groupBoxTextBoxes.Text = "Create New Map";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(148, 112);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxHeight.TabIndex = 3;
            this.textBoxHeight.Text = "20";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(148, 17);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxWidth.TabIndex = 2;
            this.textBoxWidth.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height (In tiles)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width (In tiles)";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(12, 282);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(316, 81);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Create Map";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // FormCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 375);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBoxTextBoxes);
            this.Controls.Add(this.buttonLoad);
            this.Name = "FormCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level Editor";
            this.groupBoxTextBoxes.ResumeLayout(false);
            this.groupBoxTextBoxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxTextBoxes;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}


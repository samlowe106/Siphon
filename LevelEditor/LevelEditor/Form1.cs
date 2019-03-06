using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LevelEditor
{
	public partial class Form1 : Form
	{
		// constructor
		public Form1()
		{
			InitializeComponent();
		}

		// makes a blank level editor
		private void createMapButton_Click(object sender, EventArgs e)
		{
			bool error = false;
			string message1 = "";
			string message2 = "";
			int width;
			int height;

			// checks for errors
			if (int.TryParse(widthText.Text, out width))
			{
				if (width < 10)
				{
					error = true;
					message1 = "\n - Width too small. Minimum is 10.";
				}
				else if (int.Parse(widthText.Text) > 30)
				{
					error = true;
					message1 = "\n - Width too big. Maximum is 30.";
				}
			}
			else { message1 = "\n - Width not an interger."; error = true; }
			if (int.TryParse(heightText.Text, out height))
			{
				if (height < 10)
				{
					error = true;
					message2 = "\n - Height too small. Minimum is 10.";
				}
				else if (height > 30)
				{
					error = true;
					message2 = "\n - Height too big. Maximum is 30.";
				}
			}
			else { message2 = "\n - Height not an interger."; error = true; }
			if (error) { MessageBox.Show("Errors: " + message1 + message2); }

            else
            {
                LevelEditor editor = new LevelEditor(int.Parse(heightText.Text), int.Parse(widthText.Text));
                editor.Show();
            }

		}

		// Loads a map from .level files
		private void loadButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Title = "Open a level file";
			open.Filter = "Level Files (*.level)|*.level";
			if (open.ShowDialog() == DialogResult.OK)
			{
				LevelEditor editor = new LevelEditor(open.FileName);
				editor.Show();
			}
		}
    }
}

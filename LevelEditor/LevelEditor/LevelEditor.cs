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
	public partial class LevelEditor : Form
	{
		// fields
		private PictureBox[,] boxs;
		private Color selected;
		private bool isClicking;
		private int height;
		private int width;
		private string title;
        private Dictionary<Color, int> pairs;
        private Dictionary<int, Color> reversePairs;

		// constructor
		public LevelEditor(int height, int width)
		{
			InitializeComponent();

            pairs = new Dictionary<Color, int>();
            pairs.Add(Color.Green, 0);
            pairs.Add(Color.Blue, 1);
            pairs.Add(Color.Red, 2);

            reversePairs = new Dictionary<int, Color>();
            reversePairs.Add(0, Color.Green);
            reversePairs.Add(1, Color.Blue);
            reversePairs.Add(2, Color.Red);

            title = "";
			this.height = height;
			this.width = width;

			selected = Color.Red;
			boxs = new PictureBox[height, width];

            makeMap();
		}

		// overidden constructor used for loading maps
		public LevelEditor(string filePath)
		{
			InitializeComponent();
			selected = Color.Red;

            pairs = new Dictionary<Color, int>();
            pairs.Add(Color.Green, 0);
            pairs.Add(Color.Blue, 1);
            pairs.Add(Color.Red, 2);

            reversePairs = new Dictionary<int, Color>();
            reversePairs.Add(0, Color.Green);
            reversePairs.Add(1, Color.Blue);
            reversePairs.Add(2, Color.Red);

            load(filePath);
		}

		// loads the file
		private void loadButton_Click(object sender, EventArgs e)
		{
			clear();

			OpenFileDialog open = new OpenFileDialog();
			open.Title = "Open a level file";
			open.Filter = "Level Files (*.level)|*.level";

			if (open.ShowDialog() == DialogResult.OK)
				load(open.FileName);
		}

		// loads a map
		private void load(string filePath)
		{
			Stream inStream = File.OpenRead(filePath);
			BinaryReader input = new BinaryReader(inStream);

			height = input.ReadInt32();
			width = input.ReadInt32();
			boxs = new PictureBox[height, width];

			makeMap();

			for (int r = 0; r < height; r++)
			{
				for (int c = 0; c < width; c++)
				{
					boxs[r, c].BackColor = reversePairs[input.ReadInt32()];
				}
			}

			string[] temp = filePath.Split('\\');
			title = temp[(temp.Length - 1)];

			this.Text = "Level Editor - " + title;
			input.Close();
			MessageBox.Show("File loaded successfully");
		}

		// closes all the previous picture boxs
		private void clear()
		{
			try
			{
				foreach (PictureBox box in boxs)
				{
					box.Visible = false;
					box.Enabled = false;
				}
			}
			finally { }
		}

		// Loads the picture boxs and resizes them 
        private void makeMap()
        {
            int sideLength = 375 / height;
            Map.Size = new Size((sideLength * width + 12), 400);
            Size = new Size((sideLength * width + 160), 463);

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    boxs[r, c] = new PictureBox();
                    boxs[r, c].Size = new Size(sideLength, sideLength);
                    boxs[r, c].Location = new Point(6 + (c * sideLength), 19 + (r * sideLength));
                    boxs[r, c].BackColor = Color.Silver;
					boxs[r, c].MouseDown += Pixel_Click_Down;
					boxs[r, c].MouseEnter += Pixel_Hover;
					boxs[r, c].MouseUp += Pixel_Click_Up;

					Map.Controls.Add(boxs[r, c]);
                }
            }
        }

		// Is called when the mouse is clicked down
		private void Pixel_Click_Down(object sender, EventArgs e)
		{
			((PictureBox)sender).Capture = false;
			((PictureBox)sender).BackColor = selected;
			isClicking = true;
			if (!this.Text.Contains("*"))
				this.Text += " *";
		}

		// Is called when entering a picture box
		private void Pixel_Hover(object sender, EventArgs e)
		{
			if (isClicking)
				((PictureBox)sender).BackColor = selected;
		}

		// Is called when the mouse is clicked up
		private void Pixel_Click_Up(object sender, EventArgs e)
		{
			isClicking = false;
		}
		
		// Saves the map
		private void saveButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "Level File (*.level)|*.level";
			save.Title = "Save a level file";
			if (save.ShowDialog() == DialogResult.OK)
			{
				Stream stream = File.OpenWrite(save.FileName);
				BinaryWriter output = new BinaryWriter(stream);

				output.Write(height);
				output.Write(width);

				for (int r = 0; r < height; r++)
				{
					for (int c = 0; c < width; c++)
					{
                        output.Write(pairs[boxs[r, c].BackColor]);
					}
				}

				string[] temp = save.FileName.Split('\\');
				title = temp[(temp.Length - 1)];

				this.Text = "Level Editor - " + title;

				output.Close();
				MessageBox.Show("File saved successfully");
			}
		}

		// warns the user if they try to close with unsaved progress
		private void LevelEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.Text.Contains("*"))
			{
				DialogResult result = MessageBox.Show("There are saved changes. Are you sure you want to close?", "Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == DialogResult.No)
					e.Cancel = true;
			}
		}

		// Is called when the colored buttons used in the pallet are clicked
		private void greenButton_Click(object sender, EventArgs e) { selected = Color.Green; sample.BackColor = selected; }
        private void greyButton_Click(object sender, EventArgs e) { selected = Color.Silver; sample.BackColor = selected; }
        private void brownButton_Click(object sender, EventArgs e) { selected = Color.Brown; sample.BackColor = selected; }
        private void redButton_Click(object sender, EventArgs e) { selected = Color.Red; sample.BackColor = selected; }
        private void blueButton_Click(object sender, EventArgs e) { selected = Color.Blue; sample.BackColor = selected; }
        private void blackButton_Click(object sender, EventArgs e) { selected = Color.Black; sample.BackColor = selected; }
	}
}

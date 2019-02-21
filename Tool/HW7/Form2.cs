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

namespace HW7
{
    
    public partial class FormMap : System.Windows.Forms.Form
    {
        //Variables
        int heightMap;
        int widthMap;
        bool changes = false;
        StreamReader reader;
        StreamWriter writer;
        PictureBox[,] picBox;

        public FormMap(int height,int width)        
        {
            this.heightMap = height;
            this.widthMap = width;
            InitializeComponent();
        }
        public FormMap()
        {
            LoadMap();
        }

        //When These Buttons are clciked, the current color tile will change.
        private void buttonRed_Click(object sender, EventArgs e)
        {
            pictureBoxCurrentTile.BackColor = Color.Firebrick;
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            pictureBoxCurrentTile.BackColor = Color.DarkTurquoise;
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            pictureBoxCurrentTile.BackColor = Color.ForestGreen;

        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            pictureBoxCurrentTile.BackColor = Color.Yellow;

        }

        private void buttonGray_Click(object sender, EventArgs e)
        {
            pictureBoxCurrentTile.BackColor = Color.Gray;

        }

        private void buttonOrange_Click(object sender, EventArgs e)
        {
            pictureBoxCurrentTile.BackColor = Color.Orange;

        }

        

        
        private void FormMap_Load(object sender, EventArgs e)
        {
            int picBoxHeight = 500 / heightMap;
            groupBoxMap.Size = new Size((30 * widthMap) + 60, 530);
            this.Size = new Size(458 + (30 * widthMap), 630);
            picBox = new PictureBox[widthMap, heightMap];
            //Loop Populating Maps
            
            for (int i = 0; i < widthMap; i++)
            {
                for (int j = 0; j < heightMap; j++){
                    picBox[i, j] = new PictureBox();
                    picBox[i, j].BackColor = Color.Orange;
                    picBox[i, j].Size = new Size(30, picBoxHeight);
                    picBox[i, j].Location = new Point(30 + (30 * i), 30 + (picBoxHeight * j));
                    picBox[i, j].Visible = true;
                    picBox[i, j].Click += PictureBoxClick;
                    groupBoxMap.Controls.Add(picBox[i, j]);                    
                
                }
                
                
            }
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = pictureBoxCurrentTile.BackColor;
            changes = true;
            this.Text = "Level Editor*";
        }

        private void FormMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(changes == true)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes, are you sure would you like to quit?", "Unsaved Changes", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    
                }
                else if(result == DialogResult.No)
                {

                    e.Cancel = true;
                }
            }
        }
        private void Save()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    writer = new StreamWriter(saveDialog.FileName);
                    writer.WriteLine(widthMap);
                    writer.WriteLine(heightMap);
                    for (int i = 0; i < widthMap; i++)
                    {
                        for (int j = 0; j < heightMap; j++)
                        {                           

                            writer.WriteLine(picBox[i, j].BackColor.ToArgb());
                        }
                    }
                    MessageBox.Show("File saved successfully");
                    changes = false;
                    this.Text = "Level Editor";



                }
                else
                {

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                writer.Close();
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void LoadMap()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    groupBoxMap.Controls.Clear();
                    reader = new StreamReader(openFileDialog.FileName);
                    int widthLoad = Int32.Parse(reader.ReadLine());
                    int heightLoad = Int32.Parse(reader.ReadLine());
                    int picBoxHeight = 500 / heightLoad;
                    groupBoxMap.Size = new Size((30 * widthLoad) + 60, 530);
                    this.Size = new Size(458 + (30 * widthLoad), 630);
                    picBox = new PictureBox[widthLoad, heightLoad];


                    for (int i = 0; i < widthLoad; i++)
                    {
                        for (int j = 0; j < heightLoad; j++)
                        {
                            picBox[i, j] = new PictureBox();
                            picBox[i, j].BackColor = Color.FromArgb(Int32.Parse(reader.ReadLine()));
                            picBox[i, j].Size = new Size(30, picBoxHeight);
                            picBox[i, j].Location = new Point(30 + (30 * i), 30 + (picBoxHeight * j));
                            picBox[i, j].Visible = true;
                            picBox[i, j].Click += PictureBoxClick;
                            groupBoxMap.Controls.Add(picBox[i, j]);

                        }


                    }
                    this.Text = "Level Editor- " + openFileDialog.FileName; 
                    MessageBox.Show("File loaded successfully");
                }
                            
            
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
                
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadMap();
        }

        public void FormLoadMap()
        {
            LoadMap();
            this.ShowDialog();

        }
    }
}

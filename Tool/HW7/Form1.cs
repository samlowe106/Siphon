using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW7
{
    public partial class FormCreate : System.Windows.Forms.Form
    {
        public FormCreate()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            int height;
            int width;
            bool allGood = true;
            string errors = "Errors:" + Environment.NewLine;

            try
            {

                height = int.Parse(textBoxHeight.Text);
                width = int.Parse(textBoxWidth.Text);
                
                if (height > 30)
                {
                    errors += "-Height is to large. Max is 30" + Environment.NewLine;
                    allGood = false;

                }
                else if(height < 10)
                {
                    errors += "-Height is to small. Minimum is 10" + Environment.NewLine;
                    allGood = false;
                }

                if (width > 30){
                    errors += "-Width is to large. Max is 30" + Environment.NewLine;
                    allGood = false;
                }
                else if(width < 10)
                {
                    errors += "-Width is to small. Minimum is 10" + Environment.NewLine;
                    allGood = false;
                }

                if(allGood == true)
                {
                    FormMap formMap = new FormMap(height, width);
                    formMap.ShowDialog();
                }
                else
                {
                    MessageBox.Show(errors);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("-" + errors + ex.Message);
            }

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            FormMap formMap = new FormMap(20, 20);
            
            formMap.FormLoadMap();
            
            
        }
    }
}

using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSpark_WindowsFIA
{
    public partial class Form2 : MetroSetForm
    {

        public Form2()
        {
            InitializeComponent();
            this.textBox1.Focus();
            this.label1.Text = MainForm.UserControlLabel;
            this.textBox1.Text = MainForm.txtResult;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.txtResult = this.textBox1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            //MainForm.txtResult = this.textBox1.Text;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MainForm.txtResult = this.textBox1.Text;
                this.Close();

            }
        }
    }
}

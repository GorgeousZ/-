using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int Red = random.Next(256);
            int Green = random.Next(256);
            int Blue = random.Next(256);
            Blue = (Red + Green > 400) ? Red + Green - 400 : Blue;
            Blue = (Blue > 255) ? 255 : Blue;
            button1.ForeColor = Color.FromArgb(Red, Green, Blue);
        }
    }
}

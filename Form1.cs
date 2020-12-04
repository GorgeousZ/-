using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LittleGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int number = 0;
        Random G_random = new Random();
        int G_int_random;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            int point_x = 30;
            int point_y = 10;
            for (int i = 1; i < 101; i++)
            {
                Button button = new Button();
                Random random = new Random();
                int Red = random.Next(256);
                int Green = random.Next(256);
                int Blue = random.Next(256);
                Blue = (Red + Green > 400) ? Red + Green - 400 : Blue;
                Blue = (Blue > 255) ? 255 : Blue;
                button.ForeColor = Color.FromArgb(Red, Green, Blue);
                button.Name = i.ToString();
                button.Text = i.ToString();
                button.Width = 80;
                button.Height = 80;
                button.Location = new Point(point_x, point_y);
                point_x += 80;
                if (i % 10 == 0)
                {
                    point_x = 30;
                    point_y += 80;
                }
                Controls.Add(button);
                button.Click += new EventHandler(button_Click);
            }
            G_int_random = G_random.Next(1, 100);
            //Task.Factory.StartNew(delegate
            //{
            //    int Number = 0;
            //    while (true)
            //    {
            //        Number++;
            //        Thread.Sleep(1000);
            //    }
            //});
        }
        void button_Click(object sender, EventArgs e)
        {
            Control P_control = sender as Control;
            if (int.Parse(P_control.Name)<G_int_random)
            {
                P_control.Text = "小";
                P_control.BackColor = Color.SkyBlue;
                P_control.Enabled = false;
            }
            if (int.Parse(P_control.Name)==G_int_random)
            {
                MessageBox.Show(string.Format(
                    "恭喜你，猜对了，用时{0}秒",number.ToString()),"搞定");
                this.Close();
            }
            if (int.Parse(P_control.Name)>G_int_random)
            {
                P_control.Text = "大";
                P_control.BackColor = Color.PaleVioletRed;
                P_control.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            number++;
            
        }
    }
}

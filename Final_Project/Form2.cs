using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            string PathLogoUTE = System.IO.Directory.GetCurrentDirectory() + @"\LogoUTE.jpg";
            string PathLogoFHQ = System.IO.Directory.GetCurrentDirectory() + @"\LogoFHQ.png";
            string PathRobotics = System.IO.Directory.GetCurrentDirectory() + @"\Robotics.jpg";
            Bitmap LogoUTE = new Bitmap(PathLogoUTE);
            Bitmap LogoFHQ = new Bitmap(PathLogoFHQ);
            Bitmap Robotics = new Bitmap(PathRobotics);
            InitializeComponent();
            pictureBox1.Image = LogoFHQ;
            pictureBox2.Image = LogoUTE;
            pictureBox3.Image = Robotics;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Mở form1
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}

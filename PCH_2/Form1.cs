using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCH_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PCH_Classi.SaccoCaratteri cc = new PCH_Classi.SaccoCaratteri();


            string[,] a = new string[,]
            {
                { "*", "L", "*" },
                { "*", "/", "*" },
                { "*", "*", "F" }
            };








            cc.CaricaMatrice(a);
        }
    }
}

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
            PCH_Classi.Resolver cc = new PCH_Classi.Resolver();

            cc.AggiungiParola("3,C + 4,A + 5 + 6 + 4,A + 7 + 8,N + 9 + 6 + 2");
            cc.AggiungiParola("4,A + 6 + 6 + 2 + 8,N + 2 + 4,A");
            cc.AggiungiParola("1 + 2 + 4 + 3 + 9 + 8 + 14 + 4");
            cc.AggiungiParola("4 + 13 + 9 + 5 + 3 + 4 + 15 + 9 + 8 + 6 + 12");
            cc.AggiungiParola("12+3+3+4+5+2+12+8+9");
            cc.AggiungiParola("1+2+4+13+2+8+4");



            cc.AffinaParole();

            foreach (string s in cc.RitornaParoleAffinate())
                listBox1.Items.Add(s);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCH_2.PCH_Classi
{
    class Parola
    {
        private List<Carattere> caratteri;

        public Parola(List<Carattere> caratteri)
        {
            this.caratteri = caratteri;
        }

        
        //void cose()
        //{
        //    const string path = @"parole\length_" + (cercami.Length < 16 ? cercami.Length.ToString() : "altro") + ".txt";

        //    using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
        //    {
        //        string str = sr.ReadLine();
        //        while (str != "#fine")
        //        {
        //            ControllaParola(cercami, str);
        //            str = sr.ReadLine();
        //        }
        //    }
        //}

        //private void ControllaParola(string data, string dafile)
        //{
        //    bool vaben = true;

        //    for (int v = 0; v < data.Length; v++)
        //    {
        //        if (data[v] == '*')
        //        {

        //        }
        //        else
        //        {
        //            vaben = (data[v] == dafile[v]) ? vaben : false;
        //        }
        //    }

        //    if (vaben)
        //        listBox1.Items.Add(dafile);
        //}
    }
}

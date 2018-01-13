using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCH_2.PCH_Classi
{
    class Parola
    {
        public static bool AvvenutaModifica { get; set; } = false;
        public static int LunghezzaEsclusa = 3;

        //

        private List<Carattere> caratteri;

        public Parola(List<Carattere> caratteri)
        {
            this.caratteri = caratteri;
        }

        public string RitornaAttuale()
        {
            string str = "";

            foreach (Carattere c in caratteri)
                str = str + ((c.Definitivo == '?') ? "_" : c.Definitivo.ToString());

            return str;
        }

        public void AffinaCaratteri()
        {
            string ricerca = "";
            foreach (Carattere c in caratteri)
                ricerca = ricerca + ((c.Definitivo == '?') ? "*" : c.Definitivo.ToString());

            List<char>[] temp = new List<char>[caratteri.Count];
            for (int v = 0; v < temp.Length; v++)
                temp[v] = new List<char>();

            ControlladaFile();

            for (int v = 0; v < caratteri.Count; v++)
                caratteri[v].InviaCaratteriPossibili(temp[v]);

            // Funzioni

            void ControlladaFile()
            {
                string path = @"parole\length_" + (ricerca.Length < 16 ? ricerca.Length.ToString() : "altro") + ".txt";

                using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
                {
                    string str = sr.ReadLine();
                    while (str != "#fine")
                    {
                        ControllaParola(ricerca, str.ToUpper());
                        str = sr.ReadLine();
                    }
                }
            }

            void ControllaParola(string data, string dafile)
            {
                bool vaben = true;

                for (int v = 0; v < data.Length; v++)
                {
                    if (data[v] != '*')
                    {
                        vaben = (data[v] == dafile[v]) ? vaben : false;
                    }
                }

                if (vaben)
                {
                    for (int v = 0; v < dafile.Length; v++)
                    {
                        temp[v].Add(dafile[v]);
                    }
                }
            }
        }


        
    }
}

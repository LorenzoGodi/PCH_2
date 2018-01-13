using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCH_2.PCH_Classi
{
    class SaccoCaratteri
    {
        private List<Carattere> caratteri;
        private List<Parola> parole;

        public SaccoCaratteri()
        {
            caratteri = new List<Carattere>();
            parole = new List<Parola>();
        }

        public void AggiungiCarattere(Carattere car)
        {
            Carattere trova = caratteri.Find(x => x.Id == car.Id);
            if (trova == null)
                caratteri.Add(car);
        }

        public void CaricaMatrice(string[,] matrix)
        {
            // Caratteri
            for(int v = 0; v < matrix.GetLength(0); v++)
            {
                for(int w = 0; w < matrix.GetLength(1); w++)
                {
                    List<char> p = new List<char>();
                    if(Resolver.STR_Numeri.Contains(matrix[v, w][0]))
                    {
                        if(matrix[v, w].Length > 2)
                        {
                            // Numero definito
                            int num = Int32.Parse(matrix[v, w].Split(',')[0]);
                            char let = matrix[v, w].Split(',')[1][0];

                            AggiungiCarattere(new Carattere($"rig {v} - col {w}", let, num));
                        }
                        else
                        {
                            // Numero indefinito
                            int num = Int32.Parse(matrix[v, w]);

                            AggiungiCarattere(new Carattere($"rig {v} - col {w}", num));
                        }
                    }
                    else
                    {
                        switch (matrix[v, w][0])
                        {
                            case '*':
                                // Indefinito
                                AggiungiCarattere(new Carattere($"rig {v} - col {w}"));
                                break;
                            case '/':
                                // Casella nera

                                break;
                            default:
                                // Lettera
                                AggiungiCarattere(new Carattere($"rig {v} - col {w}", matrix[v, w][0]));
                                break;
                        }
                    }
                }
            }

            // Parole
            for (int v = 0; v < matrix.GetLength(0); v++)
            {
                for (int w = 0; w < matrix.GetLength(1); w++)
                {
                    if (IsInizioParolaOrizzontale(v, w))
                        parole.Add(new Parola(RitornaParolaOrizzontale(v, w)));
                    if (IsInizioParolaVerticale(v, w))
                        parole.Add(new Parola(RitornaParolaVerticale(v, w)));
                }
            }


            bool IsInizioParolaVerticale(int v, int w)
            {
                if(!(matrix[v, w].Length < 2 && matrix[v, w][0] == '/'))
                {
                    if (v == 0 || matrix[v - 1, w][0] == '/')
                        return true;
                }
                return false;
            }

            bool IsInizioParolaOrizzontale(int v, int w)
            {
                if (!(matrix[v, w].Length < 2 && matrix[v, w][0] == '/'))
                {
                    if (w == 0 || matrix[v, w - 1][0] == '/')
                        return true;
                }
                return false;
            }

            List<Carattere> RitornaParolaVerticale(int v, int w)
            {
                List<Carattere> temp = new List<Carattere>();
                int _v = v;
                do
                {
                    temp.Add(caratteri.Find(x => x.Id == $"rig {_v} - col {w}"));
                    _v++;
                }
                while (_v < matrix.GetLength(0) && matrix[_v, w][0] != '/');

                return temp;
            }

            List<Carattere> RitornaParolaOrizzontale(int v, int w)
            {
                List<Carattere> temp = new List<Carattere>();
                int _w = w;
                do
                {
                    temp.Add(caratteri.Find(x => x.Id == $"rig {v} - col {_w}"));
                    _w++;
                }
                while (_w < matrix.GetLength(1) && matrix[v, _w][0] != '/');

                return temp;
            }
        }
    }
}

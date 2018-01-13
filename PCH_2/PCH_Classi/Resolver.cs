using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCH_2.PCH_Classi
{
    class Resolver
    {
        public const string STR_Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string STR_Numeri = "1234567890";
        //public static char[] CHR_Alfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        //

        private List<Carattere> caratteri;
        private List<Parola> parole;

        public Resolver()
        {
            caratteri = new List<Carattere>();
            parole = new List<Parola>();
        }

        private void aggiungiCarattere(Carattere car)
        {
            Carattere trova = caratteri.Find(x => x.Id == car.Id);
            if (trova == null)
                caratteri.Add(car);
        }

        public void AggiungiParola(string par, char separatore = '+')
        {
            par = par.ToUpper().Replace(" ", "");
            string[] lettere = par.Split(separatore);

            foreach(string str in lettere)
            {
                if (str.Length > 2)
                {
                    // Numero definito
                    int num = Int32.Parse(str.Split(',')[0]);
                    char let = str.Split(',')[1][0];

                    aggiungiCarattere(new Carattere(num, let));
                }
                else
                {
                    // Numero indefinito
                    int num = Int32.Parse(str);

                    aggiungiCarattere(new Carattere(num));
                }
            }

            //

            List<Carattere> temp = new List<Carattere>();
            foreach(string str in lettere)
            {
                temp.Add(caratteri.Find(x => x.Id.ToString() == str.Split(',')[0]));
            }

            parole.Add(new Parola(temp));
        }

        public void AffinaParole()
        {
            Parola.AvvenutaModifica = false;

            foreach (Parola p in parole)
                p.AffinaCaratteri();

            if (Parola.AvvenutaModifica)
                AffinaParole();
        }

        public List<string> RitornaParoleAffinate()
        {
            List<string> temp = new List<string>();

            foreach (Parola p in parole)
                temp.Add(p.RitornaAttuale());

            return temp;
        }
    }
}

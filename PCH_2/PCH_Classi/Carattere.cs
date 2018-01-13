using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCH_2.PCH_Classi
{
    class Carattere
    {
        public int Id { get; private set; }
        public List<char> CaratteriPossibili { get; private set; }
        public char Definitivo { get; private set; } = '?';

        public Carattere(int id)
        {
            Id = id;
            CaratteriPossibili = new List<char>();

            foreach (char ch in Resolver.STR_Alfabeto)
                CaratteriPossibili.Add(ch);

            verifica();
        }
        
        public Carattere(int id, char definitivo)
        {
            Id = id;
            CaratteriPossibili = new List<char>();

            CaratteriPossibili.Add(definitivo);

            verifica();
        }

        private void verifica()
        {
            if (CaratteriPossibili.Count == 1)
                Definitivo = CaratteriPossibili[0];
        }

        public void InviaCaratteriPossibili(List<char> caratteri)
        {
            List<char> temp = new List<char>();

            foreach (char ch in CaratteriPossibili)
                if (caratteri.Contains(ch))
                    temp.Add(ch);

            if (CaratteriPossibili.Count != temp.Count)
                Parola.AvvenutaModifica = true;

            CaratteriPossibili = temp;
            verifica();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCH_2.PCH_Classi
{
    class Carattere
    {
        public string Id { get; private set; }
        public int Numero { get; private set; } = -1;
        public List<char> CaratteriPossibili { get; private set; }
        public char Definitivo { get; private set; } = '?';

        public Carattere(string id)
        {
            Id = id;
            CaratteriPossibili = new List<char>();

            foreach (char ch in Resolver.STR_Alfabeto)
                CaratteriPossibili.Add(ch);

            verifica();
        }

        public Carattere(string id, char[] possibili)
        {
            Id = id;
            CaratteriPossibili = new List<char>();

            foreach (char ch in possibili)
                CaratteriPossibili.Add(ch);

            verifica();
        }

        public Carattere(string id, char definitivo)
        {
            Id = id;
            CaratteriPossibili = new List<char>();

            CaratteriPossibili.Add(definitivo);

            verifica();
        }

        public Carattere(string id, int numero)
        {
            Id = id;
            Numero = numero;
            CaratteriPossibili = new List<char>();

            foreach (char ch in Resolver.CHR_Alfabeto)
                CaratteriPossibili.Add(ch);

            verifica();
        }

        public Carattere(string id, char definitivo, int numero)
        {
            Id = id;
            Numero = numero;
            CaratteriPossibili = new List<char>();

            CaratteriPossibili.Add(definitivo);

            verifica();
        }

        public void InviaPossibiliNuovi(char[] chr)
        {
            List<char> temp = new List<char>();
            foreach (char ch in CaratteriPossibili)
                if (chr.Contains(ch))
                    temp.Add(ch);
            CaratteriPossibili = temp;

            verifica();
        }

        private void verifica()
        {
            if (CaratteriPossibili.Count == 1)
                Definitivo = CaratteriPossibili[0];
        }
    }
}

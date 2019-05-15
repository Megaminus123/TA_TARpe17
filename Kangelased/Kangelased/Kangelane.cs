using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangelased
{
    class Kangelane
    {
        private string _Nimi;
        private string _Asukoht;
        public Kangelane(string Nimi,string Asukoht)
        {
            this.Nimi = Nimi;
            this.Asukoht = Asukoht;
        }

        public string Asukoht { get => _Asukoht; set => _Asukoht = value; }
        public string Nimi { get => _Nimi; set => _Nimi = value; }

        public int Päästa(int Ohustatuid)
        {
            return (int)Math.Round(Ohustatuid * .95);
        }
        public override string ToString()
        {
            return Nimi + " hoiab " + Asukoht + " turvalisena.";
        }
    }
}

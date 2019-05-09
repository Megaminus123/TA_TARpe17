using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangelased
{
    class SuperKangelane:Kangelane
    {
        private double _Osavus;
        public SuperKangelane(string Nimi,string Asukoht):base(Nimi,Asukoht)
        {
            Random r = new Random();
            _Osavus = r.Next(1,5)+r.NextDouble();
        }
        public int Päästa(int Ohustatuid)
        {
            return (int)Math.Round(Ohustatuid * (95 + _Osavus) / 100);
        }
        public override string ToString()
        {
            return base.ToString()+" ja ta on selles "+_Osavus + " protsenti osavam kui teised.";
        }
    }
}

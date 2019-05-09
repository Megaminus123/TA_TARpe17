using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangelased
{
    class Program
    {
        static List<Kangelane> Kangelased = new List<Kangelane>();
            static void LaeKangelased(string Failinimi)
            {
            string[] failiAndmed = System.IO.File.ReadAllLines(Failinimi);
            for (int i = 0; i < failiAndmed.Length; i++)
            {
                string[] nimiKoht = failiAndmed[i].Split(new char[] { '/' });
                string nimi = nimiKoht[0].Trim();
                string asukoht = nimiKoht[1].Trim();
                if (nimi.EndsWith("*"))
                {
                    Kangelased.Add(new SuperKangelane(nimi.Trim(new char[] { '*' }), asukoht));
                }
                else
                {
                    Kangelased.Add(new Kangelane(nimi, asukoht));
                }
            }
            }

        static void Main(string[] args)
        {
            LaeKangelased("Kangelased.txt");
            foreach (Kangelane tegelane in Kangelased)
            {
                Console.WriteLine(tegelane);
                Console.WriteLine("Ohus on 1000 inimest. Päästeti " + tegelane.Päästa(1000));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_1_Näide
{
    //4.Meetod – LaeEuroAlus() –vähendab vaba kaubaruumi 2 kuupmeetrit
    interface IKaubaLaadimine
    {
        void LaeEuroAlus();
    }
    //1.Auto – väljad: mark, kohti
    class Auto
    {
        //meetodid - YtleMark()
        protected string _Mark;
        protected int _Kohti;
        protected int _Vabukohti;

        //2.Autodearv(klassimuutuja)
        private static int _Autodearv = 0;

        public Auto(int Kohti, string Mark)
        {
            _Mark = Mark;
            _Kohti = Kohti;
            _Vabukohti = _Kohti;
            _Autodearv++;
        }
        public virtual void YtleMark()
        {
            Console.WriteLine($"Auto mark on: {_Mark}.");
        }

        //VabuKohti(omadus)
        public int Vabukohti 
        {
            get 
            {
                return _Vabukohti;
            }

            set 
            {
                if (value >=0 && value <= _Kohti)
                {
                    _Vabukohti = value;
                }
                else
                {
                    Console.WriteLine($"VIGA! Lubamatu väärtus {value}.\n"+ 
                        $"Vabu kohti tohib olla vahemkus 0 - {_Kohti}.");
                }
            }
        }

        //SiseneAutosse(arv) - vähendab vabu kohti
        public void SiseneAutose(int Reisijaid)
        {
            Vabukohti -= Reisijaid;
        }



    }
    class Kaubik : Auto, IKaubaLaadimine
    {
        //3.Kaubik – väli kaubaruum
        protected int _Kaubaruum;
        protected int _VabuKaubaruum;

        public Kaubik(int Kohti, string Mark, int Kaubaruum) : base(Kohti, Mark)
        {
            _Kaubaruum = Kaubaruum;
            _VabuKaubaruum = _Kaubaruum;
        }

        //YtleMark() – teavitab lisaks kaubaruumi suuruse
        public override void YtleMark()
        {
            base.YtleMark();
            Console.WriteLine($"Autos on kaubaruumi {_Kaubaruum} ruutmeetrid.");
        }

        public void LaeEuroAlus()
        {
            VabaKaubaruum -= 2;
        }

        //5.SiseneAutosse(arv) – reisijaid ei lasta sisse
        new public void SiseneAutose(int Reisijaid)
        {
            Console.WriteLine("Reisijaid kaubikusse ei lubata.");
        }

        //VabaKaubaruum(omadus)
        public int VabaKaubaruum
        {
            get => _VabuKaubaruum;

            set 
            {
                if (value >= 0 && value <= _Kaubaruum)
                {
                    _VabuKaubaruum = value;
                }
                else
                {
                    Console.WriteLine($"VIGA!");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Auto klassi test
            Auto auto = new Auto(7,"toyota");
            auto.YtleMark();
            auto.Vabukohti = 6;
            auto.SiseneAutose(7);
            auto.SiseneAutose(6);
            auto.SiseneAutose(-1);
            Console.WriteLine("Auto on täis.");
            auto.SiseneAutose(1);

            //Kaubiku klassi Test
            Kaubik kaubik = new Kaubik(4,"toyota",15);
            kaubik.YtleMark();
            kaubik.VabaKaubaruum = 0;
            kaubik.LaeEuroAlus();
            kaubik.Vabukohti = 4;
            kaubik.SiseneAutose(2);
        }
    }
}

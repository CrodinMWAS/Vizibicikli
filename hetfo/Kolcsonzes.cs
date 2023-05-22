using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hetfo
{
    internal class Kolcsonzes
    {
        string nev;
        char jazon;
        int eOra;
        int ePerc;
        int vOra;
        int vPerc;

        public Kolcsonzes(string csvSor)
        {
            string[] mezo = csvSor.Split(";");
            this.nev = mezo[0];
            this.jazon = Convert.ToChar(mezo[1]);
            this.eOra = Convert.ToInt32(mezo[2]);
            this.ePerc = Convert.ToInt32(mezo[3]);
            this.vOra = Convert.ToInt32(mezo[4]);
            this.vPerc = Convert.ToInt32(mezo[5]);
        }

        public int IdoHossz()
        {
            return VOra * 60 + VPerc - EOra * 60 - EPerc;
        }

        public Kolcsonzes(string nev, char jazon, int eOra, int ePerc, int vOra, int vPerc)
        {
            this.nev = nev;
            this.jazon = jazon;
            this.eOra = eOra;
            this.ePerc = ePerc;
            this.vOra = vOra;
            this.vPerc = vPerc;
        }

        public string Nev { get => nev;}
        public char Jazon { get => jazon;}
        public int EOra { get => eOra;}
        public int EPerc { get => ePerc;}
        public int VOra { get => vOra;}
        public int VPerc { get => vPerc;}
    }
}

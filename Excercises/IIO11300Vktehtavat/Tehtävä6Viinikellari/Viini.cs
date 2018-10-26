using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä6Viinikellari
{
    class Viini
    {
        public string nimi { get; set; }
        public string maa { get; set; }
        public string arvio { get; set; }

        public Viini(string nm, string m, string arv)
        {
            this.nimi = nm;
            this.maa = m;
            this.arvio = arv;
        }
        public override string ToString()
        {
            return nimi + ", " + maa + ", " + arvio;
        }

    }


}

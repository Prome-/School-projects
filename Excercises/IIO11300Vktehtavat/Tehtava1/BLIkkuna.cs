using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    class IkkunaVE0 // luokan nimen ei tarvitse täsmätä tiedoston nimeä
        // vaihtoehto 0
    {
        // tehdään public, ÄLÄ KÄYTÄ! Edustaa "huonoa" ohjelmointitapaa
        public double leveys, korkeus;
        public double LaskePintaAla()
        {
            return leveys * korkeus;
        }


    }
    public class Ikkuna
    {
        //properties
        //property = ominaisuus
        //parempi tapa on avata "hallitusti" olio ominaisuuksien kautta
        private double leveys;

        public double Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }

        private double korkeus;

        public double Korkeus
        {
            get { return korkeus; }
            set { korkeus = value; }
        }

        //read-only tyyppinen property
        public double PintaAla
        {
            get
            {
                return korkeus * leveys;
            }
        }
        //methods
        public double LaskePintaAla()
        {
            // return leveys * korkeus;
            return LaskeIPintaala();
        }
        private double LaskeIPintaala()
        {
            return leveys * korkeus;

        }

    }
}

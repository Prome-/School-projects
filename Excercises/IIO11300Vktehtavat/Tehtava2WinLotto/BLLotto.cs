using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    class Lotto
    {
        private string lottoType;

        public string LottoType
        {
            get { return lottoType; }
            set { lottoType = value; }
        }

        private int drawIndex;

        public int DrawIndex
        {
            get { return drawIndex; }
            set { drawIndex = value; }
        }

        public int[] draw(string type)
        {
            if (type == "Suomi")
            {
                Console.WriteLine("Suomi valittu");
                int[] array = new int[7];
                Random rand = new Random();
                for (int i = 0;i<7;i++)
                {
                    
                    array[i] = rand.Next(1, 39);
                }
                return array;
            }
            else if (type == "VikingLotto") {
                Console.WriteLine("Viking valittu");
                int[] array = new int[6];
                Random rand = new Random();
                for (int i = 0; i < 6; i++)
                {
                    
                    array[i] = rand.Next(1, 48);
                }
                return array;
            }
            else
            {
                Console.WriteLine("else/euro valittu");
                int[] array = new int[7];
                Random rand = new Random();
                for (int i = 0; i < 5; i++)
                {
                    
                    array[i] = rand.Next(1, 50);
                }
                array[5] = rand.Next(1, 18);
                array[6] = rand.Next(1, 18);
                return array;
            }
        }
    }
}

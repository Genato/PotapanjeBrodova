using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class SlučajniPucač : IPucač
    {
        public SlučajniPucač(Mreža mreža, int duljinaBroda)
        {
                this.mreža = mreža;
                this.duljinaBroda = duljinaBroda;
        }

        public SlučajniPucač(Mreža mreža, List<int> brodovi)
        {
            this.mreža = mreža;
            najdužiBrod = brodovi.Max();
        }

        Polje TraziNajboljePolje()
        {
            foreach (IEnumerable<IEnumerable<Polje>> nizPolja in mreža.DajNizoveSlobodnihPolja(najdužiBrod))
            {
                foreach (Polje polje in nizPolja)
                {
                    if (!mapa.ContainsKey(polje))
                    {
                        mapa.Add(polje, 0);
                    }
                    else
                    {
                        mapa[polje] += 1;
                    }
                }
            }
            var poslozeniRijecnik = mapa.OrderBy(x => x.Value);

            int max = poslozeniRijecnik.First().Value;
            foreach (KeyValuePair<Polje, int> izborPolja in poslozeniRijecnik)
            {
                if (izborPolja.Value != max)
                    mapa.Remove(izborPolja.Key);
            }
            List<Polje> keyList = new List<Polje>(mapa.Keys);
            return keyList[slucajniBroj.Next(keyList.Count())];
        }

        public Polje Gađaj()
        {
            throw new NotImplementedException();
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            throw new NotImplementedException();
        }

        Mreža mreža;
        int duljinaBroda;
        private Dictionary<Polje, int> mapa;
        private int najdužiBrod;
        private Random slucajniBroj = new Random();

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

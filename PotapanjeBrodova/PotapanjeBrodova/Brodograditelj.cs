using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Brodograditelj
    {
        public Flota SloziFlotu(Mreža mreža, IEnumerable<int> duljinaBrodova)
        {
            Flota flota = new Flota();
            TerminatorPolja termi = new TerminatorPolja(mreža);
            int pokusaj = 0;
            for (; pokusaj < brojPokusaja;pokusaj++)
            {
                bool uspjesnoPostavljeniBrodovi = true;
                foreach (int i in duljinaBrodova)
                {
                    var nizovi = mreža.DajNizoveSlobodnihPolja(i);
                    if (nizovi.Count() == 0)
                    {
                        uspjesnoPostavljeniBrodovi = false;
                        break;
                    }
                    int index = slucajniBrojevi.Next(nizovi.Count());
                    var niz = nizovi.ElementAt(index);
                    flota.DodajBrod(niz);
                    termi.UkloniPolja(niz);
                }
                if (uspjesnoPostavljeniBrodovi == true)
                {
                    break;
                }            
            }
            return pokusaj < brojPokusaja ? flota : null;
        }

        private int brojPokusaja = 15;
        private Random slucajniBrojevi = new Random();
    }
}

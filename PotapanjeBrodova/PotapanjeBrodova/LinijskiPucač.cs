using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class LinijskiPucač : IPucač
    {
        public LinijskiPucač(Mreža mreža, IEnumerable<Polje> pogođenaPolja, int duljineBrodova)
        {
            this.mreža = mreža;
            this.pogođenaPolja = pogođenaPolja;
            this.duljineBrodova = duljineBrodova;
        }

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                throw new NotImplementedException();
            }
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
        IEnumerable<Polje> pogođenaPolja;
        int duljineBrodova;

    }
}

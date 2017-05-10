using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
     public class KružniPucač : IPucač
    {
        public KružniPucač(Mreža mreža, Polje prvoPogođenoPolje, int duljineBrodova)
        {
            this.mreža = mreža;
            this.prvoPogođenoPolje = prvoPogođenoPolje;
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
        Polje prvoPogođenoPolje;
        int duljineBrodova;
    }
}

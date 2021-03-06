﻿using System;
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

        private IEnumerable<Polje> DajKandidate()
        {
            List<Polje> kandidati = new List<Polje>();

            foreach (Smjer smjer in Enum.GetValues(typeof(Smjer)))
            {
                var lista = mreža.DajNizSlobodnihPolja(prvoPogođenoPolje, smjer);
            }

            return kandidati;
        }

        Mreža mreža;
        Polje prvoPogođenoPolje;
        int duljineBrodova;
    }
}

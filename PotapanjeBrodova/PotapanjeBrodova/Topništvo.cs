using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PotapanjeBrodova
{
    public enum TaktikaGađanja
    {
        Nasumično,
        Kružno,
        Linijsko
    }

    public class Topništvo
    {
        public Topništvo(int redaka, int stupaca, IEnumerable<int> duljineBrodova)
        {
            this.mreža = new Mreža(redaka, stupaca);
            this.duljineBrodova = new List<int>(duljineBrodova);
            TaktikaGađanja = TaktikaGađanja.Nasumično;
            pucač = new SlučajniPucač(mreža, duljineBrodova.First());
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            if (rezultat == RezultatGađanja.Promašaj)
                return;

            //pucač.ObradiGađanje(rezultat);

            if (rezultat == RezultatGađanja.Pogodak)
            {
                switch (TaktikaGađanja)
                {
                    case TaktikaGađanja.Nasumično:
                        PromjeniTaktikuUKružno();
                        return;
                    case TaktikaGađanja.Kružno:
                        PromjeniTaktikuULinijsko();
                        return;
                    case TaktikaGađanja.Linijsko:
                        return;
                    default:
                        Debug.Assert(false);
                        return;
                }
            }

            Debug.Assert(rezultat == RezultatGađanja.Potopljen);

            PromjeniTaktikuUNasumično();
        }

        private void PromjeniTaktikuUKružno()
        {
            TaktikaGađanja = TaktikaGađanja.Kružno;
            Polje prvoPogođenoPolje = pucač.PogođenaPolja.First();
            pucač = new KružniPucač(mreža, prvoPogođenoPolje, duljineBrodova.First());
        }

        private void PromjeniTaktikuULinijsko()
        {
            TaktikaGađanja = TaktikaGađanja.Linijsko;
            var prvoPogođenoPolje = pucač.PogođenaPolja;
            pucač = new LinijskiPucač(mreža, prvoPogođenoPolje, duljineBrodova.First());
        }

        private void PromjeniTaktikuUNasumično()
        {
            TaktikaGađanja = TaktikaGađanja.Nasumično;
            pucač = new SlučajniPucač(mreža, duljineBrodova.First());
        }

        public TaktikaGađanja TaktikaGađanja { get; private set; }

        public Polje Gađaj()
        {
             return pucač.Gađaj();
        }

        Mreža mreža;
        List<int> duljineBrodova;
        IPucač pucač;
    }
}

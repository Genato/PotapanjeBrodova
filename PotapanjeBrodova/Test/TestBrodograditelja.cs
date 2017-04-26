using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class TestBrodograditelja
    {
        [TestMethod]
        public void Brodograditelj_SloziFlotuVeacaFlotuSBrodovimaZadaneDuljine()
        {
            Brodograditelj b = new Brodograditelj();
            Mreža mreža = new Mreža(10, 10);
            IEnumerable<int> duljinaBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Flota f = b.SloziFlotu(mreža, duljinaBrodova);
            Assert.AreEqual(duljinaBrodova.Count(), f.BrojBrodova);
        }
        [TestMethod]
        public void Brodograditelj_SloziFlotuVracaNullJerNeMozeSlozitiSveBrodoveUMrezu()
        {
            Brodograditelj b = new Brodograditelj();
            Mreža mreza = new Mreža(5, 5);
            IEnumerable<int> duljinaBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Assert.AreEqual(null, b.SloziFlotu(mreza, duljinaBrodova));
        }
    }
}
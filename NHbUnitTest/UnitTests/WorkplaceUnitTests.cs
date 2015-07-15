using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHbApp.Domain;

namespace NHbUnitTest.UnitTests
{
    [TestClass]
    public class WorkplaceUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_utworzyć_miejsca_pracy_bez_nazwy()
        {
            //given
            var nazwa = "";
            var stanowisko = "SZEF WYDZIAŁU";
            var miejscowosc = "WARSZAWA";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var jestAktualne = true; 
            //when
            var mp = new Workplace(nazwa,stanowisko,miejscowosc,ulica,nrDomu,nrLokalu,kodPocztowy,jestAktualne);
            //then
            Assert.IsNull(mp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_utworzyć_miejsca_pracy_bez_nazwy_miejscowości()
        {
            //given
            var nazwa = "KG ŻW";
            var stanowisko = "SZEF WYDZIAŁU";
            var miejscowosc = "";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var jestAktualne = true; 
            //when
            var mp = new Workplace(nazwa, stanowisko, miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualne);
            //then
            Assert.IsNull(mp);
        }
    }
}

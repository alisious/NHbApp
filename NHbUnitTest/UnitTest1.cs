using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHbApp.Domain;
using NHibernate.Event;

namespace NHbUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Person _person;
        
        [TestInitialize]
        public void Initialize()
        {
            _person = new Person("KORPUSIK","JACEK");
        }


        [TestMethod]
        public void można_utworzyć_osobę_z_nazwiskiem_i_imieniem()
        {
            //given
            var nazwisko = "KORPUSIK";
            var imie = "JACEK";
            //when
            var p = new Person(nazwisko, imie);
            //then
            Assert.IsNotNull(p);
            Assert.AreEqual(nazwisko,p.Familyname);
            Assert.AreEqual(imie,p.Firstname);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_utworzyć_osoby_bez_nazwiska()
        {
            //given
            var nazwisko = "";
            var imie = "JACEK";
            //when
            var p = new Person(nazwisko, imie);
            //then
            Assert.IsNull(p);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_utworzyć_osoby_bez_imienia()
        {
            //given
            var nazwisko = "KORPUSIK";
            var imie = "";
            //when
            var p = new Person(nazwisko, imie);
            //then
            Assert.IsNull(p);

        }

        [TestMethod]
        public void osobie_można_przypisać_adres()
        {
            //given
            var p = _person;
            var miejscowosc = "WARSZAWA";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var jestAktualny = true;
            
            //when
            p.CreateAddress(miejscowosc, ulica, nrDomu,nrLokalu,kodPocztowy,jestAktualny);
            //then
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Addresses.Count,1);
        }

        [TestMethod]
        public void osoba_nie_może_mieć_takich_samych_adresów()
        {
            //given
            var p = _person;
            var miejscowosc = "WARSZAWA";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var jestAktualny = true;

            //when
            p.CreateAddress(miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualny);
            var r  = p.CreateAddress(miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualny);
            //then
            Assert.IsNotNull(p);
            Assert.IsFalse(r);
            Assert.AreEqual(p.Addresses.Count, 1);
        }
    }
}

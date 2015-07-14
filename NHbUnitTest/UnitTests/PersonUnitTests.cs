using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHbApp.Domain;
using NHibernate.Event;

namespace NHbUnitTest.UnitTests
{
    [TestClass]
    public class PersonUnitTests
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
            p.AddAddress(miejscowosc, ulica, nrDomu,nrLokalu,kodPocztowy,jestAktualny);
            //then
            Assert.IsNotNull(p);
            Assert.AreEqual(p.GetAddresses().Count,1);
        }

        [TestMethod]
        public void osobie_można_przypisać_różne_adresy()
        {
            //given
            var p = _person;
            var miejscowosc1 = "WARSZAWA";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var miejscowosc2 = "KRAKÓW";
            var jestAktualny = true;

            //when
            p.AddAddress(miejscowosc1, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualny);
            p.AddAddress(miejscowosc2, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualny);
            //then
            Assert.IsNotNull(p);
            Assert.AreEqual(p.GetAddresses().Count, 2);
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
            p.AddAddress(miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualny);
            var r  = p.AddAddress(miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualny);
            //then
            Assert.IsNotNull(p);
            Assert.IsFalse(r);
            Assert.AreEqual(p.GetAddresses().Count, 1);
        }

        [TestMethod]
        public void można_usunąć_adres_z_listy()
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
            p.AddAddress(miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualny);
            var r = p.RemoveAddress(miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy);
            //then
            Assert.IsNotNull(p);
            Assert.IsTrue(r);
            Assert.AreEqual(p.GetAddresses().Count, 0);
        }
    }
}

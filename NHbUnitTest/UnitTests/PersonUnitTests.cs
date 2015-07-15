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
            _person = new Person("KORPUSIK","JACEK","73020916558","1973-02-09","JAN");
        }


       
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void osoba_musi_mieć_nazwisko()
        {
            //given
            var nazwisko = "";
            var imie = "JACEK";
            var pesel = "73020916558";
            var dataUrodzenia = "1973-02-09";
            var imieOjca = "JAN";
            //when
            var p = new Person(nazwisko, imie,pesel,dataUrodzenia,imieOjca);
            //then
            Assert.IsNull(p);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void osoba_musi_mieć_imienię()
        {
            //given
            var nazwisko = "KORPUSIK";
            var imie = "";
            var pesel = "73020916558";
            var dataUrodzenia = "1973-02-09";
            var imieOjca = "JAN";
            //when
            var p = new Person(nazwisko, imie, pesel, dataUrodzenia, imieOjca);
            //then
            Assert.IsNull(p);

        }

        [TestMethod]
        public void jeśli_osoba_ma_PESEL_nie_musi_mieć_daty_urodzenia_i_imienia_ojca()
        {
            //given
            var nazwisko = "KORPUSIK";
            var imie = "JACEK";
            var pesel = "73020916558";
            var dataUrodzenia = "";
            var imieOjca = "";

            //when
            var p = new Person(nazwisko, imie,pesel,dataUrodzenia,imieOjca);
            //then
            Assert.IsNotNull(p);
            Assert.AreEqual(nazwisko, p.Familyname);
            Assert.AreEqual(imie, p.Firstname);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]       
        public void jeśli_osoba_nie_ma_PESELa_musi_mieć_datę_urodzenia_i_imię_ojca()
        {
            //given
            var nazwisko = "KORPUSIK";
            var imie = "JACEK";
            var pesel = "";
            var dataUrodzenia = "";
            var imieOjca = "";

            //when
            var p = new Person(nazwisko, imie, pesel, dataUrodzenia, imieOjca);
            //then
            Assert.IsNull(p);
            
        }

        [TestMethod]
        public void jeśli_osoba_ma_datę_urodzenia_i_imię_ojca_nie_musi_mieć_PESELa()
        {
            //given
            var nazwisko = "KORPUSIK";
            var imie = "JACEK";
            var pesel = "";
            var dataUrodzenia = "1973-02-09";
            var imieOjca = "JAN";

            //when
            var p = new Person(nazwisko, imie, pesel, dataUrodzenia, imieOjca);
            //then
            Assert.IsNotNull(p);

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

        [TestMethod]
        public void osobie_można_przypisać_miejsce_pracy()
        {
            //given
            var p = _person;
            var nazwa = "KG ŻW";
            var stanowisko = "SZEF WYDZIAŁU";
            var miejscowosc = "WARSZAWA";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var jestAktualne = true;

            //when
            var r = p.AddWorkplace(nazwa,stanowisko,miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualne);
            //then
            Assert.IsNotNull(p);
            Assert.IsTrue(r);
            Assert.AreEqual(p.GetWorkplaces().Count, 1);
        }

        [TestMethod]
        public void osoba_nie_może_mieć_takich_samych_miejsc_pracy()
        {
            //given
            var p = _person;
            
            var nazwa = "KG ŻW";
            var stanowisko = "SZEF WYDZIAŁU";
            var miejscowosc = "WARSZAWA";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var jestAktualne = true;
            
            //when
            var r1 = p.AddWorkplace(nazwa, stanowisko, miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualne);
            var r2 = p.AddWorkplace(nazwa, stanowisko, miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualne);

            //then
            Assert.IsNotNull(p);
            Assert.IsTrue(r1);
            Assert.IsFalse(r2);
            Assert.AreEqual(1,p.GetWorkplaces().Count);
        }

        [TestMethod]
        public void osobie_można_przypisać_różne_miejsca_pracy()
        {
            //given
            var p = _person;
            var nazwa1 = "KG ŻW";
            var stanowisko = "SZEF WYDZIAŁU";
            var miejscowosc1 = "WARSZAWA";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var jestAktualne = true;

            var nazwa2 = "MOŻW";
            var miejscowosc2 = "WARSZAWA";

            var r1 = p.AddWorkplace(nazwa1, stanowisko, miejscowosc1, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualne);
            var r2 = p.AddWorkplace(nazwa2, stanowisko, miejscowosc2, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualne);

            //then
            Assert.IsNotNull(p);
            Assert.IsTrue(r1);
            Assert.IsTrue(r2);
            Assert.AreEqual(2, p.GetWorkplaces().Count);
        }

        [TestMethod]
        public void można_usunąć_miejsce_pracy_z_listy()
        {
            //given
            var p = _person;
            var nazwa = "KG ŻW";
            var stanowisko = "SZEF WYDZIAŁU";
            var miejscowosc = "WARSZAWA";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var jestAktualne = true;
            
            p.AddWorkplace(nazwa, stanowisko, miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy, jestAktualne);
            var r = p.RemoveWorkplace(nazwa, stanowisko, miejscowosc, ulica, nrDomu, nrLokalu, kodPocztowy);
            //then
            Assert.IsNotNull(p);
            Assert.IsTrue(r);
            Assert.AreEqual(p.GetWorkplaces().Count, 0);
        }

    }
}

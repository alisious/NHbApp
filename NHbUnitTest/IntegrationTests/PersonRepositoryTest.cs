using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHbApp.Domain;
using NHbApp.Infrastructure;

namespace NHbUnitTest.IntegrationTests
{
    [TestClass]
    public class PersonRepositoryTest
    {
        private Person _person;

        [TestInitialize]
        public void Initialize()
        {
            _person = new Person("KORPUSIK", "JACEK", "", "", "73020916558", "1973-02-09", "DZIAŁDOWO", "JAN", "MIROSŁAWA", "IZDEBSKA");
        }
        
        [TestMethod]
        public void można_zapisać_nową_osobę()
        {
            //given
            var p = _person;
            p.AddAddress("WARSZAWA", "ODKRYTA", "10", "", "01-163");
            p.AddAddress("WARSZAWA", "ODKRYTA", "11", "", "01-163");
            p.AddWorkplace("KG ŻW","SZEF WYDZIAŁU","WARSZAWA", "ODKRYTA", "10", "", "01-163");
            p.AddWorkplace("MOŻW", "SPECJALISTA", "WARSZAWA", "ODKRYTA", "10", "", "01-163");
            var rep = new PersonRepository(null);
            //when
            rep.Add(p);
            Person fromDb = null;
            using (var session = NHibernateHelpers.OpenSession())
            {
                fromDb = session.Get<Person>(p.Id);
            }
            //then
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(p, fromDb);
            Assert.AreEqual(p.Id, fromDb.Id);
            
        }

        [TestMethod]
        public void można_zapisać_zmianę_danych_osoby()
        {
            
            //given
            var p = _person;
            p.AddAddress("WARSZAWA", "ODKRYTA", "10", "", "01-163");
            p.AddAddress("WARSZAWA", "ODKRYTA", "11", "", "01-163");
            p.AddWorkplace("KG ŻW", "SZEF WYDZIAŁU", "WARSZAWA", "ODKRYTA", "10", "", "01-163");
            p.AddWorkplace("MOŻW", "SPECJALISTA", "WARSZAWA", "ODKRYTA", "10", "", "01-163");
            using (var session = NHibernateHelpers.OpenSession())
            using (var tr = session.BeginTransaction())
            {
                session.Save(p);
                tr.Commit();
            }

            Person fromDb1 = null;
            using (var session = NHibernateHelpers.OpenSession())
            {
                fromDb1 = session.Get<Person>(p.Id);
            }

            fromDb1.RemoveAddress("WARSZAWA", "ODKRYTA", "10", "", "01-163");
            
            var rep = new PersonRepository(null);
            //when
           // rep.Update(fromDb1);
            //then
           // Assert.IsNotNull(fromDb);
           // Assert.AreNotSame(p, fromDb);
           // Assert.AreEqual(p.Id, fromDb.Id);
            Assert.AreEqual(2, p.GetAddresses().Count);
            Assert.AreEqual(2, p.GetWorkplaces().Count);

        }

        [TestMethod]
        public void można_pobrać_osobę_po_Id()
        {
            //given
            var p = _person;
            p.AddAddress("WARSZAWA", "ODKRYTA", "10", "", "01-163");
            p.AddAddress("WARSZAWA", "ODKRYTA", "11", "", "01-163");
            p.AddWorkplace("KG ŻW", "SZEF WYDZIAŁU", "WARSZAWA", "ODKRYTA", "10", "", "01-163");
            p.AddWorkplace("MOŻW", "SPECJALISTA", "WARSZAWA", "ODKRYTA", "10", "", "01-163");
            using (var session = NHibernateHelpers.OpenSession())
            using (var tr = session.BeginTransaction())
            {
               session.Save(p);
                tr.Commit();
            }
            
            var rep = new PersonRepository(null);
            //when
            var fromDb = rep.GetById(p.Id);
            //then
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(p, fromDb);
            Assert.AreEqual(p.Id, fromDb.Id);
            Assert.AreEqual(2,p.GetAddresses().Count);
            Assert.AreEqual(2, p.GetWorkplaces().Count);

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHbApp.Domain;
using NHbApp.Infrastructure;

namespace NHbUnitTest.IntegrationTests
{
    [TestClass]
    public class PersonRepositoryTest
    {
        [TestMethod]
        public void można_utrwalić_osobę()
        {
            //given
            var nazwisko = "KORPUSIK";
            var imie = "JACEK";
            var p = new Person(nazwisko,imie);
            p.AddAddress("WARSZAWA", "ODKRYTA", "10", "", "01-163");
            p.AddAddress("WARSZAWA", "ODKRYTA", "11", "", "01-163");
            var rep = new PersonRepository();
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
    }
}

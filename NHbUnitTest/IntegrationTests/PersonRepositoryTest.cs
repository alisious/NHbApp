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
            _person = new Person("KORPUSIK", "JACEK", "73020916558", "1973-02-09", "JAN");
        }
        
        [TestMethod]
        public void można_utrwalić_osobę()
        {
            //given
            var p = _person;
            p.AddAddress("WARSZAWA", "ODKRYTA", "10", "", "01-163");
            p.AddAddress("WARSZAWA", "ODKRYTA", "11", "", "01-163");
            p.AddWorkplace("KG ŻW","SZEF WYDZIAŁU","WARSZAWA", "ODKRYTA", "10", "", "01-163");
            p.AddWorkplace("MOŻW", "SPECJALISTA", "WARSZAWA", "ODKRYTA", "10", "", "01-163");
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

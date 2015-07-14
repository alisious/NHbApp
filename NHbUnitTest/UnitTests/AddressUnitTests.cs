using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHbApp.Domain;

namespace NHbUnitTest.UnitTests
{
    [TestClass]
    public class AddressUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void adres_musi_mieć_miejscowość()
        {
            //given
            var miejscowosc = "";
            var ulica = "DŁUGA";
            var nrDomu = "10";
            var nrLokalu = "";
            var kodPocztowy = "01-163";
            var jestAktualny = true; 
            //when
            var a = new Address(miejscowosc,ulica,nrDomu,nrLokalu,kodPocztowy,jestAktualny);
            //then
            Assert.IsNull(a);
        }
    }
}

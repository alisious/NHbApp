using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHbApp.Domain;

namespace NHbUnitTest
{
    [TestClass]
    public class UnitTest1
    {
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
    }
}

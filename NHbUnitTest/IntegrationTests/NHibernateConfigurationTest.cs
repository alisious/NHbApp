using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHbApp.Infrastructure;

namespace NHbUnitTest.IntegrationTests
{
    [TestClass]
    public class NHibernateConfigurationTest
    {
        [TestMethod]
        public void można_utworzyć_bazę_sql()
        {
            NHibernateHelpers.GenerateDatabase(true,true,false);
        }
    }
}

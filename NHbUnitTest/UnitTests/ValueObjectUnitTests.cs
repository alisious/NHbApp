using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NHbApp.Domain;

namespace NHbUnitTest.UnitTests
{
    [TestClass]
    public class ValueObjectUnitTests
    {
        [TestMethod]
        public void EqualityOperator_BothNulls_TrueReturned()
        {
            FakeValueObject left = null;
            FakeValueObject right = null;
            Assert.IsTrue(left == right);
        }
        [TestMethod]
        public void EqualityOperator_LeftNull_FalseReturned()
        {
            FakeValueObject left = null;
            var right = new FakeValueObject("A");
            Assert.IsFalse(left == right);
        }
        [TestMethod]
        public void EqualityOperator_RightNull_FalseReturned()
        {
            var left = new FakeValueObject("A");
            FakeValueObject right = null;
            Assert.IsFalse(left == right);
        }
        [TestMethod]
        public void EqualityOperator_NotEqual_FalseReturned()
        {
            var left = new FakeValueObject("B");
            var right = new FakeValueObject("A");
            Assert.IsFalse(left == right);
        }
        [TestMethod]
        public void EqualityOperator_Equal_TrueReturned()
        {
            var left = new FakeValueObject("A");
            var right = new FakeValueObject("A");
            Assert.IsTrue(left == right);
        }

        [TestMethod]
        public void InequalityOperator_BothNulls_FalseReturned()
        {
            FakeValueObject left = null;
            FakeValueObject right = null;
            Assert.IsFalse(left != right);
        }
        [TestMethod]
        public void InequalityOperator_LeftNull_TrueReturned()
        {
            FakeValueObject left = null;
            var right = new FakeValueObject("A");
            Assert.IsTrue(left != right);
        }
        [TestMethod]
        public void InequalityOperator_RightNull_TrueReturned()
        {
            var left = new FakeValueObject("A");
            FakeValueObject right = null;
            Assert.IsTrue(left != right);
        }
        [TestMethod]
        public void InequalityOperator_NotEqual_TrueReturned()
        {
            var left = new FakeValueObject("B");
            var right = new FakeValueObject("A");
            Assert.IsTrue(left != right);
        }
        [TestMethod]
        public void InequalityOperator_Equal_FalseReturned()
        {
            var left = new FakeValueObject("A");
            var right = new FakeValueObject("A");
            Assert.IsFalse(left != right);
        }

        [TestMethod]
        public void GetHashCode_SingleValue_ThisValueHashCodeReturned()
        {
            const string singleValue = "abcd";
            var obj = new FakeValueObject(singleValue);

            Assert.AreEqual(singleValue.GetHashCode(), obj.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_NullValue_ZeroReturned()
        {
            var obj = new FakeValueObject(new object[] { null });

            Assert.AreEqual(0, obj.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_TwoValues_XorOfHashCodesReturned()
        {
            const string firstValue = "abcd";
            const int secodValue = 15;
            var obj = new FakeValueObject(firstValue, secodValue);

            Assert.AreEqual(firstValue.GetHashCode() ^ secodValue.GetHashCode(), obj.GetHashCode());
        }


#pragma warning disable 661,660 //Equals and GetHashCode are overridden in ValueObject class.
        private class FakeValueObject : ValueObject
#pragma warning restore 661,660
        {
            private readonly List<object> _fakeValues;

            public FakeValueObject(params object[] fakeValues)
            {
                _fakeValues = new List<object>(fakeValues);
            }

            protected override IEnumerable<object> GetAtomicValues()
            {
                return _fakeValues;
            }

            public static bool operator ==(FakeValueObject left, FakeValueObject right)
            {
                return EqualOperator(left, right);
            }

            public static bool operator !=(FakeValueObject left, FakeValueObject right)
            {
                return NotEqualOperator(left, right);
            }
        }
    }
}

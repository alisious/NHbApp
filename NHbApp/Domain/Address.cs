using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain
{
    #pragma warning disable 661,660 //Equals and GetHashCode are overridden in ValueObject class.
    public class Address : ValueObject
    #pragma warning restore 661,660
    {
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string StreetNo { get; protected set; }
        public string PlaceNo { get; protected set; }
        public string PostalCode { get; protected set; }
        public bool IsCurrent { get; protected set; }

       
        #region Infrastructure

        protected Address()
        {

        }
        

        public Address(string city, string street, string streetNo, string placeNo, string postalCode, bool isCurrent=true)
        {
            if (String.IsNullOrWhiteSpace(city)) throw new ArgumentException("Miejscowość jest wymagana do określenia adresu!");
            City = city;
            Street = street;
            StreetNo = streetNo;
            PlaceNo = placeNo;
            PostalCode = postalCode;
            IsCurrent = isCurrent;
        }


        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return City;
            yield return Street;
            yield return StreetNo;
            yield return PlaceNo;
            yield return PostalCode;

        }

        public static bool operator ==(Address left, Address right)
        {
            return EqualOperator(left, right);
        }

        public static bool operator !=(Address left, Address right)
        {
            return NotEqualOperator(left, right);
        }

        #endregion
    }
    
}

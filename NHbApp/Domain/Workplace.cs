using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain
{
    #pragma warning disable 661,660 //Equals and GetHashCode are overridden in ValueObject class.
    public class Workplace : Address
    #pragma warning restore 661,660
    {
        public Workplace(string workplaceName, string position, string city, string street, string streetNo, string placeNo, string postalCode, bool isCurrent=true)
        {
            if (String.IsNullOrWhiteSpace(workplaceName)) throw new ArgumentException(@"Miejsce pracy musi mieć nazwę!");
            if (String.IsNullOrWhiteSpace(city)) throw new ArgumentException(@"Miejsce pracy musi mieć określoną nazwę miejscowości!");
            WorkplaceName = workplaceName;
            City = city;
            Street = street;
            StreetNo = streetNo;
            PlaceNo = placeNo;
            PostalCode = postalCode;
            IsCurrent = isCurrent;
        }
        

        public string WorkplaceName { get; protected set; }
        public string Position { get; protected set; }


        #region Infrastructure

        protected Workplace()
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return WorkplaceName;
            yield return Position;
            yield return City;
            yield return Street;
            yield return StreetNo;
            yield return PlaceNo;
            yield return PostalCode;

        }

        public static bool operator ==(Workplace left, Workplace right)
        {
            return EqualOperator(left, right);
        }

        public static bool operator !=(Workplace left, Workplace right)
        {
            return NotEqualOperator(left, right);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain
{
    public class Person
    {
        private  string _familyname;
        private string _firstname;
        private HashSet<Address> _addresses = new HashSet<Address>();

        protected Person()
        {
        }


        public Person(string familyname, string firstname)
        {
            Familyname = familyname;
            Firstname = firstname;
        }

        public virtual string Familyname
        {
            get { return _familyname; }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Osoba musi mieć nazwisko!");
                _familyname = value;
            }
        }

        public virtual string Firstname
        {
            get { return _firstname; }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Osoba musi mieć imię!");
                _firstname = value;
            }
        }

        public ReadOnlyCollection<Address> Addresses
        {
            get
            {
                IList<Address> l = new List<Address>(_addresses);
                return new ReadOnlyCollection<Address>(l);
            }
        }

        public bool CreateAddress(string city, string street, string streetNo, string placeNo, string postalCode, bool isCurrent=true)
        {
            return _addresses.Add(new Address(){City = city,Streen=street,StreetNo=streetNo,PlaceNo = placeNo,PostalCode = postalCode,IsCurrent = isCurrent});
        }


        public virtual Guid Id { get; protected set; }
    }
}

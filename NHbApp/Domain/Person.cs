using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Remotion.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain
{
    public class Person
    {
        public virtual Guid Id { get; protected set; }

        private  string _familyname;
        private string _firstname;
        
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


        #region Addresses

        private readonly IList<Address> _addresses = new List<Address>();

        public virtual ReadOnlyCollection<Address> GetAddresses()
        {
            return new ReadOnlyCollection<Address>(_addresses);
        }

        public virtual bool AddAddress(string city, string street, string streetNo, string placeNo, string postalCode, bool isCurrent = true)
        {
            var addr = new Address(city, street, streetNo, placeNo, postalCode, isCurrent);
            if (_addresses.Contains(addr))
                return false;
            _addresses.Add(addr);
            return true;
        }
        
        public virtual bool RemoveAddress(string city, string street, string streetNo, string placeNo, string postalCode)
        {
            var addr = new Address(city, street, streetNo, placeNo, postalCode);
            return _addresses.Remove(addr);

        } 
        #endregion

        #region Workplaces

        private readonly IList<Workplace> _workplaces = new List<Workplace>();

        public virtual ReadOnlyCollection<Workplace> GetWorkplaces()
        {
            return new ReadOnlyCollection<Workplace>(_workplaces);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Remotion.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remotion.Linq.Parsing;

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
        
        public Person(string familyname, string firstname,string pesel,string dateOfBirth,string nameOfFather)
        {
            if (String.IsNullOrEmpty(familyname)) throw new ArgumentException("Osoba musi mieć nazwisko!");
            if (String.IsNullOrEmpty(firstname)) throw new ArgumentException("Osoba musi mieć imię!");
            if (String.IsNullOrWhiteSpace(pesel))
                if ((String.IsNullOrWhiteSpace(dateOfBirth) || String.IsNullOrWhiteSpace(nameOfFather))) throw new ArgumentException(@"Osoba musi mieć PESEL lub datę urodzenia i imię ojca!");
            
            Familyname = familyname;
            Firstname = firstname;
            Pesel = pesel;
            DateOfBirth = dateOfBirth;
            NameOfFather = nameOfFather;
          
        }

        public virtual string Familyname { get; protected set; }
        public virtual string Firstname { get; protected set; }
        public virtual string Pesel { get; protected set; }
        public virtual string DateOfBirth { get; protected set; }
        public virtual string NameOfFather { get; protected set; }

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

        public virtual bool AddWorkplace(string workplaceName, string position, string city, string street, string streetNo, string placeNo, string postalCode, bool isCurrent=true)
        {
            var wp = new Workplace(workplaceName, position, city, street, streetNo, placeNo, postalCode, isCurrent);
            if (_workplaces.Contains(wp)) 
                return false;
            _workplaces.Add(wp);
            return true;

        }
        

        public virtual bool RemoveWorkplace(string workplaceName, string position, string city, string street, string streetNo, string placeNo, string postalCode)
        {
            var wp = new Workplace(workplaceName, position, city, street, streetNo, placeNo, postalCode);
            return _workplaces.Remove(wp);
          
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain
{
    public class Person
    {
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

        public virtual Guid Id { get; protected set; }
    }
}

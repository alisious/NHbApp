using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NHbApp.Domain;
using NHbApp.Domain.Interfaces;
using NHibernate;

namespace NHbApp.Infrastructure
{
    public class PersonRepository :IPersonRepository
    {
        private readonly Repository<Person> _repository;

        public PersonRepository(ISession session)
        {
            _repository = new Repository<Person>(session);
        }

        public Person GetById(Guid id)
        {
            Person p = null;
            p = _repository.GetById(id);
            return p;
        }

        public bool Add(Person person)
        {
           return _repository.Add(person);
        }

        public bool Delete(Person person)
        {
           return _repository.Delete(person);
        }
    }
}

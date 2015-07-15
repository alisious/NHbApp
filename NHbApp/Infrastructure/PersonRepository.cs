﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHbApp.Domain;
using NHbApp.Domain.Interfaces;

namespace NHbApp.Infrastructure
{
    public class PersonRepository :IPersonRepository
    {
        public Person GetById(Guid id)
        {
            Person p = null;
            using (var session = NHibernateHelpers.OpenSession())
           
            {
                p = session.Get<Person>(id);
                
            }
            return p;
        }

        public void Add(Person person)
        {
            
            using (var session = NHibernateHelpers.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(person);
                transaction.Commit();
            }
           
        }

        public void Remove(Person person)
        {
            throw new NotImplementedException();
        }
    }
}

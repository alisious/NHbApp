using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Person GetById(Guid id);
        void Add(Person person);
        void Remove(Person person);
    }
}

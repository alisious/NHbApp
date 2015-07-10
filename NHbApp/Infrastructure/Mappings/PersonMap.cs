using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHbApp.Domain;

namespace NHbApp.Infrastructure.Mappings
{
    public class PersonMap :ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Familyname).Length(50).Not.Nullable();
            Map(x => x.Firstname).Length(50).Not.Nullable();
        }
    }
}

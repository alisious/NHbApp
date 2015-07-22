using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHbApp.Domain;

namespace NHbApp.Infrastructure.Mappings
{
    public class PersonRegistrationMap :SubclassMap<Request>
    {
        public PersonRegistrationMap()
        {
            Abstract();
            Table("PersonRegistration");
            Map(x => x.Content).CustomSqlType("text");
        }
    }
}

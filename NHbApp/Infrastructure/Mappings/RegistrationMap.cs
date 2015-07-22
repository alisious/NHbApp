using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHbApp.Domain;

namespace NHbApp.Infrastructure.Mappings
{
    public class RegistrationMap :ClassMap<Request>
    {
        public RegistrationMap()
        {
            UseUnionSubclassForInheritanceMapping();
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Author).Length(50).Not.Nullable();
            Map(x => x.CreationTime).Not.Nullable();
            Map(x => x.RequestType).CustomType<RequestType>();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
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
            HasMany<Address>(Reveal.Member<Person>("_addresses"))
                .Component(c =>
                {
                    c.Map(x => x.City).Length(50).Not.Nullable();
                    c.Map(x => x.Street).Length(50);
                    c.Map(x => x.StreetNo).Length(5);
                    c.Map(x => x.PlaceNo).Length(5);
                    c.Map(x => x.PostalCode).Length(6);
                    c.Map(x => x.IsCurrent).Not.Nullable();
                }).Table("Addresses");
            HasMany<Workplace>(Reveal.Member<Person>("_workplaces"))
                .Component(c =>
                {
                    c.Map(x => x.WorkplaceName).Length(150).Not.Nullable();
                    c.Map(x => x.Position).Length(100);
                    c.Map(x => x.City).Length(50).Not.Nullable();
                    c.Map(x => x.Street).Length(50);
                    c.Map(x => x.StreetNo).Length(5);
                    c.Map(x => x.PlaceNo).Length(5);
                    c.Map(x => x.PostalCode).Length(6);
                    c.Map(x => x.IsCurrent).Not.Nullable();
                }).Table("Workplaces");
        }
    }
}

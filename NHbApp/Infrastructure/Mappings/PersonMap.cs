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
            Map(x => x.Middlename).Length(50).Default("");
            Map(x => x.Pesel).Length(11).Default("");
            Map(x => x.PreviousName).Length(50).Default("");
            Map(x => x.DateOfBirth).Length(10).Default("");
            Map(x => x.PlaceOfBirth).Length(50).Default("");
            Map(x => x.NameOfFather).Length(50).Default("");
            Map(x => x.NameOfMother).Length(50).Default(""); 
            Map(x => x.MotherMaidenName).Length(50).Default("");
            Map(x => x.State).CustomType<ObjectState>().Not.Nullable();
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

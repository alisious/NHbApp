using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain
{
    public class Address
    {
        public string City { get; set; }
        public string Streen { get; set; }
        public string StreetNo { get; set; }
        public string PlaceNo { get; set; }
        public string PostalCode { get; set; }
        public bool IsCurrent { get; set; }
    }
}

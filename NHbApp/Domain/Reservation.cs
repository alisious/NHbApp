using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain
{
    public class Reservation
    {
        
        public Guid Id { get; protected set; }
        public string StartDate { get; protected set; }
        public string Notes { get; protected set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain
{
    public class Workplace : Address
    {
        public string WorkplaceName { get; protected set; }
        public string Position { get; protected set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return base.GetAtomicValues();
            yield return WorkplaceName;
            yield return Position;

        }
    }
}

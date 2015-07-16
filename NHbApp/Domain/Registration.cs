using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHbApp.Domain
{
    public abstract class Registration
    {
        public Guid Id { get; protected set; }
        public string Author { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public RegistrationType RegistrationType { get; protected set; }
        public RegistrationState State { get; protected set; }

    }

    public enum RegistrationType
    {
        Create,
        Correct,
        Update,
        Delete,
        Question
    }
}

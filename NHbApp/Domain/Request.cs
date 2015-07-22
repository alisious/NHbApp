using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg.XmlHbmBinding;

namespace NHbApp.Domain
{
    public abstract class Request
    {
        public Guid Id { get; protected set; }
        public string Author { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public RequestType RequestType { get; protected set; }
        public RequestState RequestState { get; protected set; }
        public string Content { get; set; }
    }

    public enum RequestType
    {
        Create,
        Correct,
        Update,
        Delete,
        Question
    }
}

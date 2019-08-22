

using System;

namespace Cascadian.Entities
{
    public class ContactMessage
    {
        public Guid? MessageId { get; set; }

        public Person Person { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public string Message { get; set; }

        public string Origin { get; set; }

        public DateTime EntryDateTime { get; set; }
    }
}



using System;

namespace Cascadian.Entities
{
    public class ContactInfo
    {
        public Guid? ContactInfoInternalId { get; set; }

        public Person Person { get; set; }

        public ContactType Type { get; set; }

        public string Value { get; set; }

        public Guid? ChangeId { get; set; }

    }
}

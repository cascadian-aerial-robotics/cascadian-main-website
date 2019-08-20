using System;

namespace Cascadian.Entities
{
    public class ContactType
    {
        public ContactType(string name)
        {
            Name = name;
        }

        public ContactType(Guid internalId, string name)
        {
            InternalId = (Guid?)internalId;
            Name = name;
        }

        public Guid? InternalId { get; set; }

        public string Name { get; set; }
    }
}
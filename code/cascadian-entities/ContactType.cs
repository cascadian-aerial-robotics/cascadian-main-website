using System;

namespace Cascadian.Entities
{
    public class ContactType
    {
        public ContactType(string name)
        {
            Name = name;
        }

        public ContactType(short internalId, string name)
        {
            InternalId = internalId;
            Name = name;
        }

        public short? InternalId { get; set; }

        public string Name { get; set; }
    }
}
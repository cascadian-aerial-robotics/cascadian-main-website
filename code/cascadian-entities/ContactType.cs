using System;

namespace Cascadian.Entities
{
    public class ContactType
    {
        public ContactType(string name)
        {
            Name = name;
        }

        public ContactType(int internalId, string name)
        {
            InternalId = internalId;
            Name = name;
        }

        public int? InternalId { get; set; }

        public string Name { get; set; }
    }
}
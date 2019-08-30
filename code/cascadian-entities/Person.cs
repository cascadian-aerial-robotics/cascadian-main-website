using System;
using System.Collections.Generic;

namespace Cascadian.Entities
{
    public class Person
    {
        public Guid? PersonInternalId { get; set; }

        public string PersonUserIdentifier { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Guid? ChangeId { get; set; }

        public IEnumerable<ContactInfo> ContactInfo
        {
            get
            {
                return _contactInfo;
            }
            set
            {
                _contactInfo = value;

                // Ensures data integrity by assigning the parent Person
                foreach (var contact in _contactInfo)
                {
                    contact.Person = this;
                }
            }
        }
        private IEnumerable<ContactInfo> _contactInfo;

    }
}

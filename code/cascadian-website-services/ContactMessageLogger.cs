
using System.Collections.Generic;
using System.Threading.Tasks;
using Cascadian.Abstractions;
using Cascadian.Entities;
using Cascadian.Website.Abstractions;
using System.Linq;


namespace Cascadian.Website.Services
{
    public class ContactMessageLogger : IContactMessageLogger
    {
        public IPersonRepository PersonRepository { get; set; }

        public IContactInfoRepository ContactInfoRepository { get; set; }

        public IContactMessageRepository ContactMessageRepository { get; set; }
        public ContactMessageLogger(IPersonRepository personRepository)//, IContactInfoRepository contactInfoRepository, IContactMessageRepository contactMessageRepository)
        {
            PersonRepository = personRepository;
            //ContactInfoRepository = contactInfoRepository;
            //ContactMessageRepository = contactMessageRepository;
        }
        public async Task SaveMessage(string contactName, string contactEmail, string message, string contactOrigin, IEnumerable<KeyValuePair<string, string>> additionalFields = null)
        {
            ContactInfo contactInfo = null;

            // First we take a look to see if its a known person.
            var person = await PersonRepository.GetByPersonIdentifier(contactEmail);

            if (person == null)
            {
                // Person is not in the repository. Create one.
                person = new Person
                {
                    FullName = contactName,
                    PersonUserIdentifier = contactEmail
                };

                await PersonRepository.Add(person);

                // Create the contact entry, and add the contact info.
                contactInfo = new ContactInfo() { Person = person, Type = new ContactType("email"), Value = contactEmail };
                await ContactInfoRepository.Add(contactInfo);

            }
            else
            {
                // If the person is in the repository we pick the correct contact info.
                contactInfo = person.ContactInfo.First(x => x.Value.ToLowerInvariant() == contactEmail.ToLowerInvariant() || x.Type.Name.ToLowerInvariant() == "email");
            }

            var contactMessage = new ContactMessage() { ContactInfo = contactInfo, Person = person, Message = message, Origin = contactOrigin };

            await ContactMessageRepository.Add(contactMessage);

        }
    }
}

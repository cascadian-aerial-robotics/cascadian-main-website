using Cascadian.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cascadian.Abstractions
{
    public interface IContactInfoRepository : IRepository<ContactInfo, Guid>
    {
        Task<IEnumerable<ContactInfo>> GetContactsForPerson(Person person);
    }
}

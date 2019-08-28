using Cascadian.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cascadian.Abstractions
{
    public interface IContactMessageRepository : IRepository<ContactMessage, Guid>
    {
    }
}

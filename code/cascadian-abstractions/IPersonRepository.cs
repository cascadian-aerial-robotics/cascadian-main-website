using Cascadian.Entities;
using System.Threading.Tasks;

namespace Cascadian.Abstractions
{
    public interface IPersonRepository : IRepository<Person, string>
    {
        Task<Person> GetByPersonIdentifier(string personIdentifier);
    }
}

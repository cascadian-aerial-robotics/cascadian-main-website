using Cascadian.Abstractions;
using Cascadian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cascadian.Repositories.Sql
{
    public class PersonRepository : SqlRepositoryBase IPersonRepository
    {
        public PersonRepository(IServiceProvider secretsProvider):base(secretsProvider)
        {

        }

        public Task<IQueryable<Person>> Query => throw new NotImplementedException();

        public Task Add(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Task<Person> Get(string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByPersonIdentifier(string personIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}

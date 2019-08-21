using Cascadian.Abstractions;
using Cascadian.Entities;
using Grump.Abstractions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascadian.Repositories.Sql
{
    public class SqlPersonRepository : SqlRepositoryBase, IPersonRepository
    {
        public SqlPersonRepository(ISecretsProvider secretsProvider):base(secretsProvider)
        {

        }

        public Task<IQueryable<Person>> Query => throw new NotImplementedException();

        public async Task Add(Person entity)
        {
            using (var command = new SqlCommand("Person_Add"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(CreateSqlParameter("PersonUserIdentifier", System.Data.SqlDbType.NVarChar, entity.PersonUserIdentifier,360));
                command.Parameters.Add(CreateSqlParameter("FullName", System.Data.SqlDbType.NVarChar, entity.FullName, 300));
                command.Parameters.Add(CreateSqlParameter("FirstName", System.Data.SqlDbType.NVarChar, entity.FirstName, 100));
                command.Parameters.Add(CreateSqlParameter("MiddleName", System.Data.SqlDbType.NVarChar, entity.MiddleName, 100));
                command.Parameters.Add(CreateSqlParameter("LastName", System.Data.SqlDbType.NVarChar, entity.LastName, 100));
                command.Parameters.Add(CreateSqlOutputParameter("PersonInternalId", System.Data.SqlDbType.UniqueIdentifier));
                command.Parameters.Add(CreateSqlOutputParameter("ChangeId", System.Data.SqlDbType.UniqueIdentifier));

                await ExecuteNonQuery(command);

                entity.PersonInternalId = (Guid?) command.Parameters["@PersonInternalId"].Value;
                entity.ChangeId = (Guid?)command.Parameters["@ChangeId"].Value;
            }
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

        public async Task<Person> GetByPersonIdentifier(string personIdentifier)
        {
            using (var command = new SqlCommand("Persons_Get"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(CreateSqlParameter("PersonUserIdentifier", System.Data.SqlDbType.NVarChar, personIdentifier, 360));

                using (var dataset = await GetDataSet(command))
                {
                    if (dataset.Tables.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return new Person();
                        
                    }
                }

                

            }
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

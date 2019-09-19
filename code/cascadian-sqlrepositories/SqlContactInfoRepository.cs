using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cascadian.Abstractions;
using Cascadian.Entities;
using Grump.Abstractions;
using Grump.Sql;
using Microsoft.Data.SqlClient;

namespace Cascadian.Repositories.Sql
{
    public class SqlContactInfoRepository : SqlRepositoryBase, IContactInfoRepository
    {
        public SqlContactInfoRepository(ISecretsProvider secretsProvider) : base(secretsProvider)
        {
        }

        public Task<IQueryable<ContactInfo>> Query => throw new NotImplementedException();

        public async Task Add(ContactInfo contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("contact");
            }

            if (contact.Person?.PersonInternalId == null)
            {
                throw new ArgumentException("The Person property of the contact must be instantiated and fully hydrated including PersonInternalId");
            }

            if (contact.Type == null)
            {
                throw new ArgumentException("The contact type must be specified.");
            }

            using (var command = new SqlCommand("ContactInfo_Add"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(CreateSqlParameter("@PersonInternalId", System.Data.SqlDbType.UniqueIdentifier, contact.Person.PersonInternalId));
                command.Parameters.Add(CreateSqlParameter("@ContactTypeName", System.Data.SqlDbType.NVarChar, contact.Type.Name, 100));
                command.Parameters.Add(CreateSqlParameter("@Value", System.Data.SqlDbType.NVarChar, contact.Value, 200));

                command.Parameters.Add(CreateSqlOutputParameter("@ContactInfoInternalId", System.Data.SqlDbType.UniqueIdentifier));
                command.Parameters.Add(CreateSqlOutputParameter("@ChangeId", System.Data.SqlDbType.UniqueIdentifier));
                command.Parameters.Add(CreateSqlOutputParameter("@ContactInfoTypeId", System.Data.SqlDbType.SmallInt));

                await ExecuteNonQuery(command);

                contact.ContactInfoInternalId = (Guid?)command.Parameters["@ContactInfoInternalId"].Value;
                contact.ChangeId = (Guid?)command.Parameters["@ChangeId"].Value;
                contact.Type.InternalId = (short?)command.Parameters["@ContactInfoTypeId"].Value;

            }
        }

        public Task Delete(ContactInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContactInfo>> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContactInfo> Get(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactInfo>> GetContactsForPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(ContactInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}

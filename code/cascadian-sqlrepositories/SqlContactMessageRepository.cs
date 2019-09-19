using Cascadian.Abstractions;
using Cascadian.Entities;
using Grump.Abstractions;
using Grump.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cascadian.Repositories.Sql
{
    public class SqlContactMessageRepository : SqlRepositoryBase, IContactMessageRepository
    {
        public SqlContactMessageRepository(ISecretsProvider secretsProvider) : base(secretsProvider)
        {
        }

        public Task<IQueryable<ContactMessage>> Query => throw new NotImplementedException();

        public async Task Add(ContactMessage message)
        {
            using (var command = new SqlCommand("ContactMessages_Add"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(CreateSqlParameter("@ContactInfoInternalId", System.Data.SqlDbType.UniqueIdentifier, message.ContactInfo.ContactInfoInternalId));
                command.Parameters.Add(CreateSqlParameter("@MessageOriginName", System.Data.SqlDbType.NVarChar, message.Origin, 50));
                command.Parameters.Add(CreateSqlParameter("@MessageContent", System.Data.SqlDbType.NVarChar, message.Message, 500));

                command.Parameters.Add(CreateSqlOutputParameter("@MessageId", System.Data.SqlDbType.UniqueIdentifier));
                
                await ExecuteNonQuery(command);

                message.MessageId = (Guid?)command.Parameters["@MessageId"].Value;
                
            }
        }

        public Task Delete(ContactMessage entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContactMessage>> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContactMessage> Get(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(ContactMessage entity)
        {
            throw new NotImplementedException();
        }
    }
}

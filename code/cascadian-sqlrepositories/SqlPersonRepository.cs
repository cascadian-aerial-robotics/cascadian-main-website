using Cascadian.Abstractions;
using Cascadian.Entities;
using Grump.Abstractions;
using Grump.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grump.Data;



namespace Cascadian.Repositories.Sql
{
    public class SqlPersonRepository : SqlRepositoryBase, IPersonRepository
    {
        public IContactInfoRepository ContactInfoRepository { get; set; }
        public SqlPersonRepository(IContactInfoRepository contactInfoRepository, ISecretsProvider secretsProvider):base(secretsProvider)
        {
            ContactInfoRepository = contactInfoRepository;
        }

        public Task<IQueryable<Person>> Query => throw new NotImplementedException();

        public async Task Add(Person entity)
        {
            using (var command = new SqlCommand("Persons_Add"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(CreateSqlParameter("@PersonUserIdentifier", System.Data.SqlDbType.NVarChar, entity.PersonUserIdentifier,360));
                command.Parameters.Add(CreateSqlParameter("@FullName", System.Data.SqlDbType.NVarChar, entity.FullName, 300));
                command.Parameters.Add(CreateSqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, entity.FirstName, 100));
                command.Parameters.Add(CreateSqlParameter("@MiddleName", System.Data.SqlDbType.NVarChar, entity.MiddleName, 100));
                command.Parameters.Add(CreateSqlParameter("@LastName", System.Data.SqlDbType.NVarChar, entity.LastName, 100));
                command.Parameters.Add(CreateSqlOutputParameter("@PersonInternalId", System.Data.SqlDbType.UniqueIdentifier));
                command.Parameters.Add(CreateSqlOutputParameter("@ChangeId", System.Data.SqlDbType.UniqueIdentifier));

                await ExecuteNonQuery(command);

                entity.PersonInternalId = (Guid?) command.Parameters["@PersonInternalId"].Value;
                entity.ChangeId = (Guid?)command.Parameters["@ChangeId"].Value;

                
            }

            if (entity.ContactInfo != null)
            {
                foreach (var contact in entity.ContactInfo)
                {
                    await ContactInfoRepository.Add(contact);
                }
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
            Person person = null;

            using (var command = new SqlCommand("Persons_Get"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(CreateSqlParameter("PersonUserIdentifier", System.Data.SqlDbType.NVarChar, personIdentifier, 360));

                using (var dataset = await GetDataSet(command))
                {

                    if (dataset.Tables.Count != 0)
                    {
                        var personRow = dataset.Tables[0].Rows[0];

                        person = new Person()
                        {
                            PersonInternalId = (Guid?)personRow["PersonInternalId"],

                            PersonUserIdentifier = (string)personRow["PersonUserIdentifier"],

                            FullName = personRow.GetValueOrNull<string>("FullName"), // (string)personRow["FullName"],

                            FirstName = personRow.GetValueOrNull<string>("FirstName"),

                            MiddleName = personRow.GetValueOrNull<string>("MiddleName"),

                            LastName = personRow.GetValueOrNull<string>("LastName"),

                            ChangeId = (Guid?)personRow["ChangeId"]
                        };

                        var contactsTable = dataset.Tables[1];
                        var contactList = new List<ContactInfo>();


                        for (int i = 0; i < contactsTable.Rows.Count; i++)
                        {
                            var row = contactsTable.Rows[i];

                            var contactInfo = new ContactInfo()
                            {
                                Person = person,
                                ContactInfoInternalId = (Guid?)row["ContactInfoInternalId"],
                                Type = new ContactType((short)row["ContactType"], (string)row["ContactTypeName"]),
                                Value = (string)row["ContactTypeName"],
                                ChangeId = (Guid?)row["ChangeId"],
                            };

                            contactList.Add(contactInfo);

                        }

                        person.ContactInfo = contactList.AsEnumerable();
                    }
                }

            }

            return person;
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

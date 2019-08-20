using Grump.Abstractions;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace Cascadian.Repositories.Sql
{
    public abstract class SqlRepositoryBase
    {
        public ISecretsProvider SecretsProvider { get; set; }
        public SqlRepositoryBase(ISecretsProvider secretsProvider)
        {
            SecretsProvider = secretsProvider;
        }

        protected async Task<SqlDataReader> GetDataReader(SqlCommand command)
        {
            var connectionString = await SecretsProvider.GetSecretAsync("sqlconnectionstring");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (command.Connection = connection)
                {
                    await connection.OpenAsync();

                    return await command.ExecuteReaderAsync();
                }
            }
        }

    }
}

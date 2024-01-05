using Microsoft.Extensions.Configuration;
using SystemLibrary.Data;

namespace SystemUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlData db = GetConnection();
                // Additional code or logic
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                // Log the exception or take appropriate action
            }

        }
        static SqlData GetConnection()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
            ISqlDataAccess dbAccess = new SqlDataAccess(config);
            SqlData db = new SqlData(dbAccess);

            return db;
        }
        public class SqlData
        {
            private readonly ISqlDataAccess _dbAccess;

            public SqlData(ISqlDataAccess dbAccess)
            {
                _dbAccess = dbAccess ?? throw new ArgumentNullException(nameof(dbAccess));
            }

            // Other methods and properties...
        }

    }
}

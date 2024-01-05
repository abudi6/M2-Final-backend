﻿using Microsoft.Extensions.Configuration;
using SystemLibrary.Data;

namespace SystemUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlData db = GetConnection();

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
    }
}

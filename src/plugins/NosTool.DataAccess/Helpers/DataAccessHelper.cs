using System;

namespace NosTool.DataAccess.MSSQL.Helpers
{
    public static class DataAccessHelper
    {
        public static string GetConnectionString()
        {
            // Using parameters
            var server = "127.0.0.1";
            var database = "opennos";
            var userId = "sa";
            var password = "SuperStrongPass2024";
            var port = 1433; // Replace with your actual port

            // Option 1: Build the connection string from parameters
            string connectionString = $"Server={server},{port};Database={database};User Id={userId};Password={password};";

            // Option 2: Retrieve the connection string from the environment variable if it's set
            string envConnectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING");

            if (!string.IsNullOrEmpty(envConnectionString))
            {
                connectionString = envConnectionString;
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not set.");
            }

            return connectionString;
        }
    }
}

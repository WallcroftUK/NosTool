namespace NosTool.DataAccess.MSSQL.Helpers
{
    public static class DataAccessHelper
    {
        public static string GetConnectionString()
        {
            // Using parameters
            var server = "10.0.1.163";
            var database = "opennos";
            var userId = "tool";
            var password = "SuperStrongPass2024";
            var port = 1433; // Replace with your actual port

            // Option 1: Build the connection string from parameters
            string connectionString1 = $"Server={server},{port};Database={database};User Id={userId};Password={password};";

            string connectionString = "Server=10.0.1.163;Database=opennos;User Id=tool;Password=SuperStrongPass2024;Encrypt=False;";

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not set.");
            }

            return connectionString;
        }
    }
}
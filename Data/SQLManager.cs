using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace DocumentAnalyzerService.Data
{
    public class SqlManager
    {
        public static readonly SqlManager Instance = new SqlManager();
        
        private const string Datasource = @"NEPTUNE\MSSQLSERVER"; // your server
        private const string Database = "analyzer"; // your database name
        private const string Username = "sa"; // username of server to connect
        private const string Password = "1234"; // password
        
        // your connection string
        private const string ConnectionString = @"Data Source=" + Datasource + ";Initial Catalog=" + Database + ";Persist Security Info=True;User ID=" + Username + ";Password=" + Password;

        // Private constructor
        private SqlManager() { }
        
        /**
         * Selects all employees from the SQL Server DB
         */
        public void SelectEmployees()
        {
            var cnn = new SqlConnection(ConnectionString);
            cnn.Open();
            
            //create a new SQL Query using StringBuilder
            var strBuilder = new StringBuilder();
            strBuilder.Append("SELECT * FROM Employee");

            var sqlQuery = strBuilder.ToString();
            using (var command = new SqlCommand(sqlQuery, cnn)) //pass SQL query created above and connection
            {
                using (var reader = command.ExecuteReader())
                {
                    foreach (var line in reader)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            
            cnn.Close();
            
            return;
        }
    }
}
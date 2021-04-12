using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DocumentAnalyzerService.Models;

namespace DocumentAnalyzerService.Services
{
    public class SqlService
    {
        public static readonly SqlService Instance = new SqlService();
        
        private const string Datasource = @"NEPTUNE\MSSQLSERVER"; // your server
        private const string Database = "analyzerdb"; // your database name
        private const string Username = "sa"; // username of server to connect
        private const string Password = "1234"; // password
        
        // your connection string
        private const string ConnectionString = @"Data Source=" + Datasource + ";Initial Catalog=" + Database + ";Persist Security Info=True;User ID=" + Username + ";Password=" + Password;

        // Private constructor
        private SqlService() { }
        
        /**
         * Selects all employees from the SQL Server DB
         */
        public List<Employee> SelectEmployees()
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
            
            return null;
        }
    }
}
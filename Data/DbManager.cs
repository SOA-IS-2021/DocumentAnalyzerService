using System.Collections.Generic;
using DocumentAnalyzerService.Models;
using DocumentAnalyzerService.Services;

namespace DocumentAnalyzerService.Data
{
    /**
     * @source: https://qawithexperts.com/article/c-sharp/connect-to-sql-server-in-c-example-using-console-application/178
     */
    public class DbManager: IDbManager
    {
        
        /**
         * Selects all employees from the SQL Server DB
         */
        public List<Employee> GetEmployees()
        {
            return SqlManager.Instance.SelectEmployees();
        }

        /**
         * Gets the file processed from Mongo DB
         */
        public string GetProcessedFile(string fileName)
        {
            return MongoManager.Instance.FindProcessedFile(fileName);
        }

        /**
         * Uploads the file to the Mongo DB
         */
        public void PostProcessedFile(File file)
        {
            MongoManager.Instance.InsertProcessedFile(file);
        }
    }
}
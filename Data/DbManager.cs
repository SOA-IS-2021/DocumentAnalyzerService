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
            SqlManager.Instance.SelectEmployees();
            return null;
        }

        /**
         * Gets the file processed from Mongo DB
         */
        public File GetProcessedFile(string fileName)
        {
            return null;
        }

        /**
         * Uploads the file to the Mongo DB
         */
        public void PostProcessedFile(File file)
        {
            
        }
    }
}
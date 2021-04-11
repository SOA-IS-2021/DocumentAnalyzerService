using System.Collections.Generic;
using System.Reflection.Metadata;
using DocumentAnalyzerService.Models;

namespace DocumentAnalyzerService.Services
{
    public interface IDbManager
    {
        // Returns all the employees from the SQL DB
        public List<Employee> GetEmployees();

        // Returns the file from the Mongo DB
        public string GetProcessedFile(string fileName);

        // Uploads the file to the Mongo DB
        public void PostProcessedFile(File file);
    }
}
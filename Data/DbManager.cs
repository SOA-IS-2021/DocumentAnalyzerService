using System.Collections.Generic;
using DocumentAnalyzerService.Models;
using DocumentAnalyzerService.Services;

namespace DocumentAnalyzerService.Data
{
    public class DbManager: IDbManager
    {
        public List<Employee> GetEmployees()
        {
            throw new System.NotImplementedException();
        }

        public File GetProcessedFile(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public void PostProcessedFile(File file)
        {
            throw new System.NotImplementedException();
        }
    }
}
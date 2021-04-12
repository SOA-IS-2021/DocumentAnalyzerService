using System.Collections.Generic;

namespace DocumentAnalyzerService.Models
{
    public class FileProcessed
    {
        public FileProcessed(string fileName, List<EmployeeAppearance> employees)
        {
            this.fileName = fileName;
            this.employees = employees;
        }

        public string fileName { get; set; }

        // List of employees 
        public List<EmployeeAppearance> employees { get; set; }
    }
}
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentAnalyzerService.Models
{
    public class File
    {
        public File(string fileName, List<EmployeeAppearance> employees)
        {
            this.fileName = fileName;
            this.employees = employees;
        }

        public string fileName { get; set; }

        // List of employees 
        public List<EmployeeAppearance> employees { get; set; }
    }
}
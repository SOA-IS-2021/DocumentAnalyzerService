using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentAnalyzerService.Models
{
    public class File
    {
        public File(string fileName, List<EmployeeAppearance> employees)
        {
            FileName = fileName;
            Employees = employees;
        }

        public string FileName { get; set; }

        // List of employees 
        public List<EmployeeAppearance> Employees { get; set; }
    }
}
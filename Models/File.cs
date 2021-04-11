using System.Collections.Generic;

namespace DocumentAnalyzerService.Models
{
    public class File
    {
        public File(string fileName, List<KeyValuePair<string, int>> appearance)
        {
            FileName = fileName;
            Appearance = appearance;
        }

        public string FileName { get; set; }

        // List of employees (Name and appearance count)
        public List<KeyValuePair<string, int>> Appearance { get; set; }
    }
}
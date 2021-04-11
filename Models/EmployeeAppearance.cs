namespace DocumentAnalyzerService.Models
{
    public class EmployeeAppearance
    {
        public EmployeeAppearance(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; set; }
        
        public int Count { get; set; }
    }
}
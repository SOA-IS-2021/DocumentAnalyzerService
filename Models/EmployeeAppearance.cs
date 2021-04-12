namespace DocumentAnalyzerService.Models
{
    public class EmployeeAppearance
    {
        public EmployeeAppearance(string name, int appearance)
        {
            this.name = name;
            this.appearance = appearance;
        }

        public string name { get; set; }
        
        public int appearance { get; set; }
    }
}
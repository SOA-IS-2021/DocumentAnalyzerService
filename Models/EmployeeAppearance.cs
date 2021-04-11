namespace DocumentAnalyzerService.Models
{
    public class EmployeeAppearance
    {
        public EmployeeAppearance(string id, int appearance)
        {
            Id = id;
            Appearance = appearance;
        }

        public string Id { get; set; }
        
        public int Appearance { get; set; }
    }
}
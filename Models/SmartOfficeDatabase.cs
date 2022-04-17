namespace SmartOffice.Issat.API.Models
{
    public class SmartOfficeDatabase
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CollectionName { get; set; } = null!;
    }
}

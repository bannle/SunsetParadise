namespace SunsetParadise.Models
{
    public class Room
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = "Disponible"; 
    }
}

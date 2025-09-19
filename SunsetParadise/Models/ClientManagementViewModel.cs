namespace SunsetParadise.Models
{
    public class ClientManagementViewModel
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public Client NewClient { get; set; } = new Client();
    }
}

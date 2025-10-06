namespace Projet_UA2{
public class ClientDAO : IClientDAO
{
    private readonly AppDbContext _context; 
// Initialise une nouvelle instance de la classe ClientDAO avec le contexte de la base de données.
    public ClientDAO(AppDbContext context)
    {
        _context = context;
    }
// Enregistre un client dans la base de données.
    public void SaveClient(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }
// Récupère un client à partir de son identifiant.
    public Client GetClientById(int clientId)
    {
        return _context.Clients.FirstOrDefault(c => c.ClientID == clientId);
    }
    
}

}
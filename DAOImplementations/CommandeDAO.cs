using Microsoft.EntityFrameworkCore;


namespace Projet_UA2
{
    public class CommandeDAO : ICommandeDAO
{
    private readonly AppDbContext _context; 
// Initialise une nouvelle instance de la classe CommandeDAO avec le contexte de la base de données.
    public CommandeDAO(AppDbContext context)
    {
        _context = context;
    }
// Enregistre une commande dans la base de données.
    public void SaveCommande(Commande commande)
    {
        _context.Commandes.Add(commande);
        _context.SaveChanges();
    }

 // Récupère une commande à partir de son identifiant.
    public Commande GetCommandeById(int commandeId)
    {
        return _context.Commandes
            .Include(c => c.Client)
            .Include(c => c.Produit)
            .FirstOrDefault(c => c.CommandeID == commandeId);
    }
// Met à jour une commande dans la base de données.
    public void UpdateCommande(Commande commande)
    {
        _context.Commandes.Update(commande);
        _context.SaveChanges();
    }
    
}

}
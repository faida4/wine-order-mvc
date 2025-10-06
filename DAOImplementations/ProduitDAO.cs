namespace Projet_UA2
{
  public class ProduitDAO : IProduitDAO
{
    private readonly AppDbContext _context; 
// Initialise une nouvelle instance de la classe ProduitDAO avec le contexte de la base de données.
    public ProduitDAO(AppDbContext context)
    {
        _context = context;
    }
// Récupère tous les produits de la base de données.
    public List<Produit> GetProduits()
    {
        return _context.Produits.ToList();
    }
// Récupère un produit à partir de son identifiant.
    public Produit GetProduitById(int produitId)
    {
        return _context.Produits.FirstOrDefault(p => p.ProduitID == produitId);
    }
    
}

}
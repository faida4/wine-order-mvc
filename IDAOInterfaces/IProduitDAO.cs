namespace Projet_UA2
{
public interface IProduitDAO
{
    List<Produit> GetProduits();
    Produit GetProduitById(int produitId);
    
}

}
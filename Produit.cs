namespace Projet_UA2{
public class Produit
{
    public int ProduitID { get; set; }
    public string DescriptionProduit { get; set; }
    public decimal Prix { get; set; }
   
    public string ImageUrl { get; set; }

    public Produit()
    {
        // Initialise les propriétés par défaut 
        DescriptionProduit = "Produit standard";
        Prix = 0.0m;
        ImageUrl = "default_product.jpg";
        
    }
    
}

}

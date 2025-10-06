namespace Projet_UA2
{
 public interface ICommandeDAO
{
    void SaveCommande(Commande commande);
    Commande GetCommandeById(int commandeId);
    void UpdateCommande(Commande commande);
    
}
}
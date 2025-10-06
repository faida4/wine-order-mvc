using Microsoft.EntityFrameworkCore;
using System;
namespace Projet_UA2
{
    public class Commande
    {
        

        public int CommandeID { get; set; }
        public int ClientID { get; set; }
        public int ProduitID { get; set; }
        public DateTime DateCommande { get; set; }
        public string? NumeroCommande { get; set; }
        public decimal PrixTotal { get; set; }
        public string? StatutCommande { get; set; }

        // Navigation properties
       public Client? Client { get; set; }
       public Produit? Produit { get; set; }

         // Constructeur 
       public Commande()
    {
            StatutCommande = "En cours";
            NumeroCommande = "0"; // une valeur par défaut 
          
    }

   
    
    
    }
}

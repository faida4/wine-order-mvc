namespace Projet_UA2 {
public class Client
{
    public int ClientID { get; set; }
    public string Prenom { get; set; }
    public string Nom { get; set; }
    public DateTime DateNaissance { get; set; }
    public string NumeroTelephone { get; set; }
    public string? Adresse { get; set; }
    public string? CodePostal { get; set; }

// Constructeur par défaut
    public Client()
    {
        // Initialise les propriétés par défaut 
        Prenom = "";
        Nom = "";
        DateNaissance = DateTime.MinValue;
        NumeroTelephone = "";
    }

  
    
    
}
}

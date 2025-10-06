namespace Projet_UA2
{
    public class ConfirmationCommandeViewModel
    {
        public int CommandeID { get; set; }
        public int ClientID { get; set; }
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public string? AdresseClient { get; set; }
        public string? CodePostalClient{ get; set; }
        public DateTime DateNaissance { get; set; }
        public string FormattedDateNaissanceClient => DateNaissance.ToString("yyyy-MM-dd");
        public string? NumeroTelephone { get; set; }
        public string? DescriptionProduit { get; set; }
        public int Quantité { get; set; }
        public decimal PrixTotalProduit { get; set; }
        public DateTime DateCommande { get; set; }
        public string? StatutCommande { get; set; }
    }
}

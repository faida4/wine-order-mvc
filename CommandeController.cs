
using Microsoft.AspNetCore.Mvc;


namespace Projet_UA2
{
    public class CommandeController : Controller
    {
         private readonly IClientDAO _clientDAO;
    private readonly ICommandeDAO _commandeDAO;
    private readonly IProduitDAO _produitDAO;

    public CommandeController(IClientDAO clientDAO, ICommandeDAO commandeDAO, IProduitDAO produitDAO)
    {
        _clientDAO = clientDAO;
        _commandeDAO = commandeDAO;
        _produitDAO = produitDAO;
    }

        [HttpGet]
        public IActionResult Test()
        {
            List<Produit> produits = _produitDAO.GetProduits();
            return View(produits);
        }

        [HttpGet]
        public IActionResult VoirProduits()
        {
            List<Produit> produits = _produitDAO.GetProduits();
            return View(produits);
        }

        [HttpGet]
        public IActionResult CreateCommande(int produitID)
        {
            // Charger la liste des produits depuis la base de données
            var produits = _produitDAO.GetProduits();
            return View(produits);
        }

        [HttpPost]
        public IActionResult CreateCommande(Client client, int produitID, int quantité)
        {
            // Enregistrez le client dans la base de données en utilisant l'interface DAO
            _clientDAO.SaveClient(client);

            // Récupérez les informations du produit depuis la base de données en utilisant l'interface DAO
            var produit = _produitDAO.GetProduitById(produitID);

            if (produit == null)
            {
                // Gérer le cas où le produit n'est pas trouvé
                return NotFound();
            }

            // Calcul du prix total en fonction de la quantité
            decimal prixTotal = produit.Prix * quantité;

            // Créez la commande avec les détails associés
            var commande = new Commande
            {
                
                ClientID = client.ClientID,
                ProduitID = produitID,
                DateCommande = DateTime.Now,
                PrixTotal = prixTotal,
                StatutCommande = "En attente",
            };

            // Enregistrez la commande dans la base de données en utilisant l'interface DAO
            _commandeDAO.SaveCommande(commande);

            // Mettez à jour le numéro de commande après l'enregistrement
            commande.NumeroCommande = commande.CommandeID.ToString();
            _commandeDAO.UpdateCommande(commande);

            // Redirigez vers la page de confirmation avec les détails de la commande 
            return RedirectToAction("ConfirmationCommande", new
    {
        commandeId = commande.CommandeID,
         quantité
    });
          
        }

        [HttpGet]
        public IActionResult ConfirmationCommande(int commandeId, int quantité)
        {
            // Récupérer les détails de la commande depuis la base de données avec les informations du client et du produit
            var commande = _commandeDAO.GetCommandeById(commandeId);

            if (commande == null)
            {
                // Gérer le cas où la commande n'est pas trouvée
                return NotFound();
            }

            // Récupérer les informations  DAO 
            var client = _clientDAO.GetClientById(commande.ClientID);
            var produit = _produitDAO.GetProduitById(commande.ProduitID);

            // Crée un ViewModel pour la page de confirmation
            var confirmationViewModel = new ConfirmationCommandeViewModel
            {
                CommandeID = commande.CommandeID,
                ClientID = client.ClientID,
                Prenom = client.Prenom,
                Nom = client.Nom,
                AdresseClient = client.Adresse,
                CodePostalClient = client.CodePostal,
                DateNaissance = client.DateNaissance,
                NumeroTelephone = client.NumeroTelephone,
                DescriptionProduit = produit.DescriptionProduit,
                Quantité = quantité,
                PrixTotalProduit = commande.PrixTotal,
                DateCommande = commande.DateCommande,
                StatutCommande = commande.StatutCommande
            };

            // Passez le ViewModel à la vue
            return View(confirmationViewModel);
        }
    }
}


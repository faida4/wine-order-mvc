using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projet_UA2.Models;

namespace Projet_UA2.Controllers;

public class CommandeController : Controller
{
    private readonly ILogger<CommandeController> _logger;

    public CommandeController(ILogger<CommandeController> logger)
    {
        _logger = logger;
    }

   
     public IActionResult VoirProduits()
    {
        return View();
    }
    
    public IActionResult CreateCommande()
    {
        return View();
    }
     public IActionResult ConfirmationCommande()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

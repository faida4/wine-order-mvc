
using Microsoft.EntityFrameworkCore;

namespace Projet_UA2
{

    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Ajout des services DAO avec leur interface correspondante
                services.AddScoped<IClientDAO, ClientDAO>();
                services.AddScoped<ICommandeDAO, CommandeDAO>();
                services.AddScoped<IProduitDAO, ProduitDAO>();

    services.AddControllersWithViews();


            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                services.AddControllersWithViews();
                services.AddScoped<AppDbContext>();
                
                services.AddRazorPages()
        .AddRazorPagesOptions(options =>
        {
            options.RootDirectory = "/Pages";
            options.Conventions.AddPageRoute("/Home/Acceuil", "");
        });
      
        }

      // Méthode pour configurer le pipeline de requêtes de l'application 
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

 // Redirection des requêtes HTTP vers HTTPS
app.UseHttpsRedirection();
// Configuration du serveur pour servir les fichiers statiques
app.UseStaticFiles();
// Configuration du routage des requêtes
    app.UseRouting();

 // Configuration des points de terminaison des requêtes
    app.UseEndpoints(endpoints =>
    {
        // Configuration de la route par défaut vers le contrôleur Home et l'action Acceuil
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Acceuil}/{id?}"
        );

 // Configuration de la route pour l'action CreateCommande du contrôleur Commande
        endpoints.MapControllerRoute(
            name: "creerCommande",
            pattern: "{controller=Commande}/{action=CreateCommande}/{id?}"
        );
// Configuration de la route pour l'action ConfirmationCommande du contrôleur Commande
         endpoints.MapControllerRoute(
            name: "ConfirmationCommande",
            pattern: "{controller=Commande}/{action=ConfirmationCommande}/{id?}"
        );
        // Configuration de la route pour l'action VoirProduits du contrôleur Commande
        endpoints.MapControllerRoute(
            name: "VoirProduits",
            pattern: "{controller=Commande}/{action=VoirProduits}/{id?}"
        );


        

    });
}

    }
}

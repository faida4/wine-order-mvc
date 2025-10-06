
using Microsoft.EntityFrameworkCore;

using Projet_UA2;


var builder = WebApplication.CreateBuilder(args);

// Configuration setup
builder.Configuration.AddJsonFile("appsettings.json");

// Ajouter la configuration du DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Ajout des services au conteneur.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClientDAO, ClientDAO>();
    builder.Services.AddScoped<ICommandeDAO, CommandeDAO>();
    builder.Services.AddScoped<IProduitDAO, ProduitDAO>();

var app = builder.Build();

// Configurez le pipeline de requêtes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Acceuil}/{id?}");

app.Run();


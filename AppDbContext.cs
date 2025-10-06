using Microsoft.EntityFrameworkCore;
namespace Projet_UA2
{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Produit> Produits { get; set; }
    public DbSet<Commande> Commandes { get; set; }

// Configure le modèle de données pour la base de données.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure les colonnes de types decimal
        modelBuilder.Entity<Commande>()
            .Property(c => c.PrixTotal)
            .HasColumnType("decimal(18,2)"); //  Ajustez la précision et l'échelle au besoin

        modelBuilder.Entity<Produit>()
            .Property(p => p.Prix)
            .HasColumnType("decimal(18,2)"); //  Ajustez la précision et l'échelle au besoin


            // Configure les relations entre les entités
         modelBuilder.Entity<Commande>()
                .HasOne(c => c.Produit)
                .WithMany()  
                .HasForeignKey(c => c.ProduitID);

                modelBuilder.Entity<Commande>()
                .HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientID);

           

        

        base.OnModelCreating(modelBuilder);
    }
}


}

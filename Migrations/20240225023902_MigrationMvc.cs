using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetUA2.Migrations
{
    /// <inheritdoc />
    public partial class MigrationMvc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    ProduitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionProduit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantité = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.ProduitID);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    CommandeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    ProduitID = table.Column<int>(type: "int", nullable: false),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroCommande = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrixTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatutCommande = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.CommandeID);
                    table.ForeignKey(
                        name: "FK_Commandes_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commandes_Produits_ProduitID",
                        column: x => x.ProduitID,
                        principalTable: "Produits",
                        principalColumn: "ProduitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "ProduitID", "DescriptionProduit", "ImageUrl", "Prix", "Quantité" },
                values: new object[,]
                {
                    { 1, "Produit A", "/Pictures/p1.jpg", 19.99m, 0 },
                    { 2, "Produit B", "/Pictures/p2.jpg", 29.99m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ClientID",
                table: "Commandes",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ProduitID",
                table: "Commandes",
                column: "ProduitID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Produits");
        }
    }
}

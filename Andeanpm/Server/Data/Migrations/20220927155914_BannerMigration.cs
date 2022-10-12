using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Andeanpm.Server.Data.Migrations
{
    public partial class BannerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "Id", "Module", "Url" },
                values: new object[,]
                {
                    { 1, "Our Company", "assets/banners/ourcompany.jpg" },
                    { 2, "Our People", "assets/banners/ourpeople.jpg" },
                    { 3, "Careers", "assets/banners/careers.jpg" },
                    { 4, "Cerro Rico Mine", "assets/banners/cerroricomine.jpg" },
                    { 5, "Cachi Laguna", "assets/banners/cachilaguna.jpg" },
                    { 6, "Cerro Rico Deposits", "assets/banners/cerroricodeposits.jpg" },
                    { 7, "Ore Purchasing", "assets/banners/orepurchasing.jpg" },
                    { 8, "El Asiento", "assets/banners/elasiento.jpg" },
                    { 9, "Tatasi Portugalete", "assets/banners/tatasiportugalete.jpg" },
                    { 10, "Monserrat", "assets/banners/monserrat.jpg" },
                    { 11, "San Bartolome", "assets/banners/sanbartolome.jpg" },
                    { 12, "Exploration", "assets/banners/exploration.jpg" },
                    { 13, "San Pablo", "assets/banners/sanpablo.jpg" },
                    { 14, "Rio Blanco", "assets/banners/rioblanco.jpg" },
                    { 15, "Sustainability", "assets/banners/sustainability.jpg" },
                    { 16, "Esg", "assets/banners/esg.jpg" },
                    { 17, "Governance", "assets/banners/governance.jpg" },
                    { 18, "Investors", "assets/banners/investors.jpg" },
                    { 19, "News", "assets/banners/news.jpg" },
                    { 20, "Contact", "assets/banners/contact.jpg" },
                    { 21, "Customer Care", "assets/banners/customercare.jpg" }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

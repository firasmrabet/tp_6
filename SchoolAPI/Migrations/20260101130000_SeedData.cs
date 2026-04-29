using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAPI.Migrations
{
    
    public partial class SeedData : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name", "Sections", "Director", "Rating", "WebSite" },
                values: new object[,]
                {
                    { 1, "ENISo", "GIA, GE, GM, GC", "Mahdi Abdessalem", 4.5, "https://www.eniso.tn" },
                    { 2, "ENIT", "Informatique, Genie Civil, Telecom", "Karim Ben Salem", 4.7, "https://www.enit.rnu.tn" },
                    { 3, "ENIM", "Mecanique, Electromecanique", "Sami Bouzid", 4.2, null }
                });
        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Schools", keyColumn: "Id", keyValue: 1);
            migrationBuilder.DeleteData(table: "Schools", keyColumn: "Id", keyValue: 2);
            migrationBuilder.DeleteData(table: "Schools", keyColumn: "Id", keyValue: 3);
        }
    }
}


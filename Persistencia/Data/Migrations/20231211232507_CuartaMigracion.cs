using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class CuartaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "contacto_persona",
                columns: new[] { "id", "descripcion", "id_contacto", "id_persona" },
                values: new object[,]
                {
                    { 1, "3132419732", 1, 1 },
                    { 2, "3132419732", 1, 2 },
                    { 3, "3132419732", 1, 3 },
                    { 4, "3132419732", 1, 4 },
                    { 5, "3132419732", 1, 5 },
                    { 6, "julian@gmial", 2, 6 },
                    { 7, "margi@gmial", 2, 7 },
                    { 8, "nico@gmial", 2, 8 },
                    { 9, "lalala@gmial", 2, 9 },
                    { 10, "sopas@gmial", 2, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "contacto_persona",
                keyColumn: "id",
                keyValue: 10);
        }
    }
}

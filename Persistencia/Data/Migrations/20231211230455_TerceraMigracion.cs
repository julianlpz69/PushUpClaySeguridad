using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class TerceraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categoria_persona",
                columns: new[] { "id", "nombre_categoria" },
                values: new object[,]
                {
                    { 1, "Auxiliar" },
                    { 2, "Cajero" },
                    { 3, "Supervisor" },
                    { 4, "Vigilante" }
                });

            migrationBuilder.InsertData(
                table: "estado",
                columns: new[] { "id", "descripcion" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Finalizado" },
                    { 3, "Pendiente" }
                });

            migrationBuilder.InsertData(
                table: "pais",
                columns: new[] { "id", "nombre_pais" },
                values: new object[] { 1, "Colombia" });

            migrationBuilder.InsertData(
                table: "tipo_contacto",
                columns: new[] { "id", "descripcion" },
                values: new object[,]
                {
                    { 1, "Celular" },
                    { 2, "Email" }
                });

            migrationBuilder.InsertData(
                table: "tipo_persona",
                columns: new[] { "id", "descripcion" },
                values: new object[,]
                {
                    { 1, "Empleado" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "turno",
                columns: new[] { "id", "hora_turno_final", "hora_turno_inicio", "nombre_turno" },
                values: new object[,]
                {
                    { 1, 12f, 6f, "Mañana" },
                    { 2, 8f, 12f, "Tarde" },
                    { 3, 12f, 8f, "Noche" }
                });

            migrationBuilder.InsertData(
                table: "departamento",
                columns: new[] { "id", "id_pais", "nombre_dep" },
                values: new object[] { 1, 1, "Santander" });

            migrationBuilder.InsertData(
                table: "ciudad",
                columns: new[] { "id", "id_dep", "nombre_ciudad" },
                values: new object[,]
                {
                    { 1, 1, "Bucaramanga" },
                    { 2, 1, "Floridablanca" },
                    { 3, 1, "Giron" },
                    { 4, 1, "Piedecuesta" }
                });

            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "id", "date_registro", "direccion", "id_categoria", "id_ciudad", "id_persona", "id_tipo_persona", "nombre" },
                values: new object[,]
                {
                    { 1, new DateOnly(2009, 1, 11), null, 4, 3, "123459", 1, "Carlos David" },
                    { 2, new DateOnly(2011, 1, 11), null, null, 1, "123468", 2, "Karla Lopez" },
                    { 3, new DateOnly(2009, 1, 11), null, 1, 4, "123477", 1, "Hector Hernandez" },
                    { 4, new DateOnly(2013, 1, 11), null, null, 1, "123486", 2, "Juan Sanches" },
                    { 5, new DateOnly(2009, 1, 11), null, 4, 1, "123494", 1, "Pablo Gaviria" },
                    { 6, new DateOnly(2022, 1, 11), null, null, 3, "123505", 2, "Elon Musk" },
                    { 7, new DateOnly(2009, 1, 11), null, 4, 3, "123553", 1, "Leidy gaga" },
                    { 8, new DateOnly(2009, 1, 11), null, null, 1, "123741", 2, "Michael Jackson" },
                    { 9, new DateOnly(2009, 1, 11), null, 1, 4, "123562", 1, "Fredy Mercury" },
                    { 10, new DateOnly(2021, 1, 11), null, null, 1, "123635", 2, "Fredy Fasbear" },
                    { 11, new DateOnly(2009, 1, 11), null, 4, 3, "132456", 1, "Finn el Humano" }
                });

            migrationBuilder.InsertData(
                table: "contrato",
                columns: new[] { "id", "fecha_contrato", "fecha_fin", "id_cliente", "id_empleado", "id_estado" },
                values: new object[,]
                {
                    { 1, new DateOnly(2009, 1, 11), new DateOnly(2023, 1, 11), 2, 1, 1 },
                    { 2, new DateOnly(2022, 2, 11), new DateOnly(2023, 2, 11), 4, 3, 1 },
                    { 3, new DateOnly(2022, 3, 11), new DateOnly(2023, 3, 11), 6, 5, 2 },
                    { 4, new DateOnly(2022, 4, 11), new DateOnly(2023, 4, 11), 8, 7, 1 },
                    { 5, new DateOnly(2022, 5, 11), new DateOnly(2023, 5, 11), 10, 9, 3 },
                    { 6, new DateOnly(2022, 6, 11), new DateOnly(2023, 6, 11), 2, 11, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_persona_id_persona",
                table: "persona",
                column: "id_persona",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_persona_id_persona",
                table: "persona");

            migrationBuilder.DeleteData(
                table: "categoria_persona",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categoria_persona",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ciudad",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "contrato",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "contrato",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "contrato",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "contrato",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "contrato",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "contrato",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tipo_contacto",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tipo_contacto",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "turno",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "turno",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "turno",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "estado",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "estado",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "estado",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "categoria_persona",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categoria_persona",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ciudad",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ciudad",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ciudad",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tipo_persona",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tipo_persona",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "departamento",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "pais",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}

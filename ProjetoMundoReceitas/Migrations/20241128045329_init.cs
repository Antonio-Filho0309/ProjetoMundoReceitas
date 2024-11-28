using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoMundoReceitas.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeName = table.Column<string>(type: "TEXT", nullable: false),
                    RecipeAvaliation = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipeCust = table.Column<string>(type: "TEXT", nullable: false),
                    RecipeDescription = table.Column<string>(type: "TEXT", nullable: false),
                    RecipeIngredients = table.Column<string>(type: "TEXT", nullable: false),
                    RecipeMaterials = table.Column<string>(type: "TEXT", nullable: false),
                    RecipePreparation = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Lauro@gmail.com", "Lauro", "1234" },
                    { 2, "Antonio@gmail.com", "Antonio", "1234" },
                    { 3, "Batman@gmail.com", "Batman", "1234" },
                    { 4, "Miguel@gmail.com", "Miguel", "1234" },
                    { 5, "Lucas@gmail.com", "Lucas", "1234" }
                });

            migrationBuilder.InsertData(
                table: "Recipers",
                columns: new[] { "Id", "RecipeAvaliation", "RecipeCust", "RecipeDescription", "RecipeIngredients", "RecipeMaterials", "RecipeName", "RecipePreparation", "UserId" },
                values: new object[,]
                {
                    { 1, 0, "Custo medio", "MUITO GOSTOSO", "TESTE TESTE TESTE TESTE", "TESTE TESTE TESTE", "Bolo da Negona", "TESTE", 1 },
                    { 2, 0, "Custo medio", "MUITO GOSTOSO", "TESTE TESTE TESTE TESTE", "TESTE TESTE TESTE", "Bolo da Negona", "TESTE", 2 },
                    { 3, 0, "Custo medio", "MUITO GOSTOSO", "TESTE TESTE TESTE TESTE", "TESTE TESTE TESTE", "Bolo da Negona", "TESTE", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipers_UserId",
                table: "Recipers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

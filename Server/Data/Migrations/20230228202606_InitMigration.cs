using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionPremises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentArea = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPremises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionPremiseId = table.Column<int>(type: "int", nullable: false),
                    TypeOfEquipmentId = table.Column<int>(type: "int", nullable: false),
                    CountOfEquipment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_ProductionPremises_ProductionPremiseId",
                        column: x => x.ProductionPremiseId,
                        principalTable: "ProductionPremises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_TypesOfEquipment_TypeOfEquipmentId",
                        column: x => x.TypeOfEquipmentId,
                        principalTable: "TypesOfEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ProductionPremiseId",
                table: "Contracts",
                column: "ProductionPremiseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_TypeOfEquipmentId",
                table: "Contracts",
                column: "TypeOfEquipmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ProductionPremises");

            migrationBuilder.DropTable(
                name: "TypesOfEquipment");
        }
    }
}

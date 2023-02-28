using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeOneToOneToManyToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_ProductionPremiseId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_TypeOfEquipmentId",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ProductionPremiseId",
                table: "Contracts",
                column: "ProductionPremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_TypeOfEquipmentId",
                table: "Contracts",
                column: "TypeOfEquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_ProductionPremiseId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_TypeOfEquipmentId",
                table: "Contracts");

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
    }
}

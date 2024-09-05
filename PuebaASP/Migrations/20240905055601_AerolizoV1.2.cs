using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuebaASP.Migrations
{
    /// <inheritdoc />
    public partial class AerolizoV12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Luggage_LuggageId",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Luggage",
                table: "Luggage");

            migrationBuilder.RenameTable(
                name: "Luggage",
                newName: "Luggages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Luggages",
                table: "Luggages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Luggages_LuggageId",
                table: "Passengers",
                column: "LuggageId",
                principalTable: "Luggages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Luggages_LuggageId",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Luggages",
                table: "Luggages");

            migrationBuilder.RenameTable(
                name: "Luggages",
                newName: "Luggage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Luggage",
                table: "Luggage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Luggage_LuggageId",
                table: "Passengers",
                column: "LuggageId",
                principalTable: "Luggage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

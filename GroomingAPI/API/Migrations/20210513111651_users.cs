using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroomingAPI.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Groomers_GroomerID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Customers_CustomerID",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Groomers");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Pets",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "PetID",
                table: "Pets",
                newName: "PetId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_CustomerID",
                table: "Pets",
                newName: "IX_Pets_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "GroomerID",
                table: "Customers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_GroomerID",
                table: "Customers",
                newName: "IX_Customers_UserId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Customers_CustomerId",
                table: "Pets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Customers_CustomerId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Pets",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "Pets",
                newName: "PetID");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_CustomerId",
                table: "Pets",
                newName: "IX_Pets_CustomerID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Customers",
                newName: "GroomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                newName: "IX_Customers_GroomerID");

            migrationBuilder.CreateTable(
                name: "Groomers",
                columns: table => new
                {
                    GroomerID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groomers", x => x.GroomerID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Groomers_GroomerID",
                table: "Customers",
                column: "GroomerID",
                principalTable: "Groomers",
                principalColumn: "GroomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Customers_CustomerID",
                table: "Pets",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

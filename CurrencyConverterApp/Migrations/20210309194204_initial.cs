using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverterApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrenciesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CurrencyISO4217 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrenciesId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyQuotes",
                columns: table => new
                {
                    CurrencyQuotesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrenciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrencyQuoteDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyQuotes", x => x.CurrencyQuotesId);
                    table.ForeignKey(
                        name: "FK_CurrencyQuotes_Currencies_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalTable: "Currencies",
                        principalColumn: "CurrenciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyQuotes_CurrenciesId",
                table: "CurrencyQuotes",
                column: "CurrenciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyQuotes");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}

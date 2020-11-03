using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Insurance_Company.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dolzhnosti",
                columns: table => new
                {
                    Kod_dolzhnosti = table.Column<int>(type: "INT", nullable: false),
                    Naimenovanie_dolzhnosti = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Oklad = table.Column<double>(type: "FLOAT", nullable: false),
                    Obyazannosti = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Trebovaniya = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dolzhnosti", x => x.Kod_dolzhnosti);
                });

            migrationBuilder.CreateTable(
                name: "Gruppy_klientov",
                columns: table => new
                {
                    Kod_gruppy = table.Column<int>(type: "INT", nullable: false),
                    Naimenovanie = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Opisanie = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gruppy_klientov", x => x.Kod_gruppy);
                });

            migrationBuilder.CreateTable(
                name: "Riski",
                columns: table => new
                {
                    Kod_riska = table.Column<int>(type: "INT", nullable: false),
                    Naimenovanie = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Opisanie = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Srednyaya_veroyatnost = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riski", x => x.Kod_riska);
                });

            migrationBuilder.CreateTable(
                name: "Sotrudniki",
                columns: table => new
                {
                    Kod_sotrudnika = table.Column<int>(type: "INT", nullable: false),
                    FIO = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Data_rozdeniya = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Pol = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Adres = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Telefon = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Pasportnye_dannye = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Kod_dolzhnosti = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sotrudniki", x => x.Kod_sotrudnika);
                    table.ForeignKey(
                        name: "FK_Sotrudniki_Dolzhnosti_Kod_dolzhnosti",
                        column: x => x.Kod_dolzhnosti,
                        principalTable: "Dolzhnosti",
                        principalColumn: "Kod_dolzhnosti",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Klienty",
                columns: table => new
                {
                    Kod_klienta = table.Column<int>(type: "INT", nullable: false),
                    FIO = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Data_rozhdeniya = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Pol = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Adres = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Telefon = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Pasportnye_dannye = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Kod_gruppy = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienty", x => x.Kod_klienta);
                    table.ForeignKey(
                        name: "FK_Klienty_Gruppy_klientov_Kod_gruppy",
                        column: x => x.Kod_gruppy,
                        principalTable: "Gruppy_klientov",
                        principalColumn: "Kod_gruppy",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vidy_polisov",
                columns: table => new
                {
                    Kod_vida_polisa = table.Column<int>(type: "INT", nullable: false),
                    Naimenovanie = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Opisanie = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Usloviya = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Kod_riska = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidy_polisov", x => x.Kod_vida_polisa);
                    table.ForeignKey(
                        name: "FK_Vidy_polisov_Riski_Kod_riska",
                        column: x => x.Kod_riska,
                        principalTable: "Riski",
                        principalColumn: "Kod_riska",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Polisy",
                columns: table => new
                {
                    Nomer_polisa = table.Column<int>(type: "INT", nullable: false),
                    Data_nachala = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Data_okonchaniya = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Stoimost = table.Column<double>(type: "FLOAT", nullable: false),
                    Summa_vyplaty = table.Column<double>(type: "FLOAT", nullable: false),
                    Otmetka_o_vyplate = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Otmetka_ob_okonchanii = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Kod_vida_polisa = table.Column<int>(type: "INT", nullable: false),
                    Kod_klienta = table.Column<int>(type: "INT", nullable: false),
                    Kod_sotrudnika = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polisy", x => x.Nomer_polisa);
                    table.ForeignKey(
                        name: "FK_Polisy_Klienty_Kod_klienta",
                        column: x => x.Kod_klienta,
                        principalTable: "Klienty",
                        principalColumn: "Kod_klienta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Polisy_Sotrudniki_Kod_sotrudnika",
                        column: x => x.Kod_sotrudnika,
                        principalTable: "Sotrudniki",
                        principalColumn: "Kod_sotrudnika",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Polisy_Vidy_polisov_Kod_vida_polisa",
                        column: x => x.Kod_vida_polisa,
                        principalTable: "Vidy_polisov",
                        principalColumn: "Kod_vida_polisa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klienty_Kod_gruppy",
                table: "Klienty",
                column: "Kod_gruppy");

            migrationBuilder.CreateIndex(
                name: "IX_Polisy_Kod_klienta",
                table: "Polisy",
                column: "Kod_klienta");

            migrationBuilder.CreateIndex(
                name: "IX_Polisy_Kod_sotrudnika",
                table: "Polisy",
                column: "Kod_sotrudnika");

            migrationBuilder.CreateIndex(
                name: "IX_Polisy_Kod_vida_polisa",
                table: "Polisy",
                column: "Kod_vida_polisa");

            migrationBuilder.CreateIndex(
                name: "IX_Sotrudniki_Kod_dolzhnosti",
                table: "Sotrudniki",
                column: "Kod_dolzhnosti");

            migrationBuilder.CreateIndex(
                name: "IX_Vidy_polisov_Kod_riska",
                table: "Vidy_polisov",
                column: "Kod_riska");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polisy");

            migrationBuilder.DropTable(
                name: "Klienty");

            migrationBuilder.DropTable(
                name: "Sotrudniki");

            migrationBuilder.DropTable(
                name: "Vidy_polisov");

            migrationBuilder.DropTable(
                name: "Gruppy_klientov");

            migrationBuilder.DropTable(
                name: "Dolzhnosti");

            migrationBuilder.DropTable(
                name: "Riski");
        }
    }
}

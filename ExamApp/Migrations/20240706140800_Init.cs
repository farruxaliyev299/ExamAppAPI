using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExamApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ders",
                columns: table => new
                {
                    Kod = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Ad = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Sinif = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    MuellimAd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MuellimSoyad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders", x => x.Kod);
                });

            migrationBuilder.CreateTable(
                name: "Shagird",
                columns: table => new
                {
                    Nomre = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    Ad = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Soyad = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Sinif = table.Column<decimal>(type: "numeric(2,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shagird", x => x.Nomre);
                });

            migrationBuilder.CreateTable(
                name: "Imtahan",
                columns: table => new
                {
                    Nomre = table.Column<decimal>(type: "numeric(14,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersKod = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    ShagirdNomre = table.Column<decimal>(type: "numeric(5,0)", nullable: true),
                    Tarix = table.Column<DateTime>(type: "date", nullable: true),
                    Qiymet = table.Column<decimal>(type: "numeric(1,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imtahan", x => x.Nomre);
                    table.ForeignKey(
                        name: "FK_Imtahan_Ders_DersKod",
                        column: x => x.DersKod,
                        principalTable: "Ders",
                        principalColumn: "Kod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imtahan_Shagird_ShagirdNomre",
                        column: x => x.ShagirdNomre,
                        principalTable: "Shagird",
                        principalColumn: "Nomre");
                });

            migrationBuilder.InsertData(
                table: "Ders",
                columns: new[] { "Kod", "Ad", "MuellimAd", "MuellimSoyad", "Sinif" },
                values: new object[,]
                {
                    { "FIZ", "Fizika", "Fizika Muellimi", "Fizika Muellimi", 9m },
                    { "RIY", "Riyaziyyat", "Riyaziyyat Muellimi", "Riyaziyyat Muellimi", 9m }
                });

            migrationBuilder.InsertData(
                table: "Shagird",
                columns: new[] { "Nomre", "Ad", "Sinif", "Soyad" },
                values: new object[,]
                {
                    { 12345m, "Shagird1", 9m, "Shagird1" },
                    { 54321m, "Shagird1", 9m, "Shagird1" }
                });

            migrationBuilder.InsertData(
                table: "Imtahan",
                columns: new[] { "Nomre", "DersKod", "Qiymet", "ShagirdNomre", "Tarix" },
                values: new object[,]
                {
                    { 123m, "RIY", 9m, 12345m, new DateTime(2024, 7, 6, 18, 7, 59, 630, DateTimeKind.Local).AddTicks(5753) },
                    { 124m, "FIZ", 9m, 54321m, new DateTime(2024, 7, 6, 18, 7, 59, 630, DateTimeKind.Local).AddTicks(5769) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imtahan_DersKod",
                table: "Imtahan",
                column: "DersKod");

            migrationBuilder.CreateIndex(
                name: "IX_Imtahan_ShagirdNomre",
                table: "Imtahan",
                column: "ShagirdNomre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imtahan");

            migrationBuilder.DropTable(
                name: "Ders");

            migrationBuilder.DropTable(
                name: "Shagird");
        }
    }
}

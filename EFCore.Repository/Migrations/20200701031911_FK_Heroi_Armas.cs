using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repository.Migrations
{
    public partial class FK_Heroi_Armas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Herois_HeroiId",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_HeroiId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "HeroiId",
                table: "Armas");

            migrationBuilder.CreateIndex(
                name: "IX_Armas_IdHeroi",
                table: "Armas",
                column: "IdHeroi");

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Herois_IdHeroi",
                table: "Armas",
                column: "IdHeroi",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Herois_IdHeroi",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_IdHeroi",
                table: "Armas");

            migrationBuilder.AddColumn<Guid>(
                name: "HeroiId",
                table: "Armas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Armas_HeroiId",
                table: "Armas",
                column: "HeroiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Herois_HeroiId",
                table: "Armas",
                column: "HeroiId",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

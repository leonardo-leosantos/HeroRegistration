using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repository.Migrations
{
    public partial class FK_HeroisBatalhas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroisBatalhas_Batalhas_BatalhaId",
                table: "HeroisBatalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroisBatalhas_Herois_HeroiId",
                table: "HeroisBatalhas");

            migrationBuilder.DropIndex(
                name: "IX_HeroisBatalhas_BatalhaId",
                table: "HeroisBatalhas");

            migrationBuilder.DropIndex(
                name: "IX_HeroisBatalhas_HeroiId",
                table: "HeroisBatalhas");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "HeroisBatalhas");

            migrationBuilder.DropColumn(
                name: "HeroiId",
                table: "HeroisBatalhas");

            migrationBuilder.CreateIndex(
                name: "IX_HeroisBatalhas_IdBatalha",
                table: "HeroisBatalhas",
                column: "IdBatalha");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroisBatalhas_Batalhas_IdBatalha",
                table: "HeroisBatalhas",
                column: "IdBatalha",
                principalTable: "Batalhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroisBatalhas_Herois_IdHeroi",
                table: "HeroisBatalhas",
                column: "IdHeroi",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroisBatalhas_Batalhas_IdBatalha",
                table: "HeroisBatalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroisBatalhas_Herois_IdHeroi",
                table: "HeroisBatalhas");

            migrationBuilder.DropIndex(
                name: "IX_HeroisBatalhas_IdBatalha",
                table: "HeroisBatalhas");

            migrationBuilder.AddColumn<Guid>(
                name: "BatalhaId",
                table: "HeroisBatalhas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HeroiId",
                table: "HeroisBatalhas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeroisBatalhas_BatalhaId",
                table: "HeroisBatalhas",
                column: "BatalhaId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroisBatalhas_HeroiId",
                table: "HeroisBatalhas",
                column: "HeroiId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroisBatalhas_Batalhas_BatalhaId",
                table: "HeroisBatalhas",
                column: "BatalhaId",
                principalTable: "Batalhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroisBatalhas_Herois_HeroiId",
                table: "HeroisBatalhas",
                column: "HeroiId",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

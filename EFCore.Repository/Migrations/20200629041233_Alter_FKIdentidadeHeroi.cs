using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repository.Migrations
{
    public partial class Alter_FKIdentidadeHeroi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentidadesSecretas_Herois_HeroiId",
                table: "IdentidadesSecretas");

            migrationBuilder.DropIndex(
                name: "IX_IdentidadesSecretas_HeroiId",
                table: "IdentidadesSecretas");

            migrationBuilder.DropColumn(
                name: "HeroiId",
                table: "IdentidadesSecretas");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadesSecretas_IdHeroi",
                table: "IdentidadesSecretas",
                column: "IdHeroi",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentidadesSecretas_Herois_IdHeroi",
                table: "IdentidadesSecretas",
                column: "IdHeroi",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentidadesSecretas_Herois_IdHeroi",
                table: "IdentidadesSecretas");

            migrationBuilder.DropIndex(
                name: "IX_IdentidadesSecretas_IdHeroi",
                table: "IdentidadesSecretas");

            migrationBuilder.AddColumn<Guid>(
                name: "HeroiId",
                table: "IdentidadesSecretas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadesSecretas_HeroiId",
                table: "IdentidadesSecretas",
                column: "HeroiId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentidadesSecretas_Herois_HeroiId",
                table: "IdentidadesSecretas",
                column: "HeroiId",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

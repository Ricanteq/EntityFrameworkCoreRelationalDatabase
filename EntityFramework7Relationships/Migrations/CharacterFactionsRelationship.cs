#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EntityFramework7Relationships.Migrations;

/// <inheritdoc />
public partial class CharacterFactionsRelationship : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "FactionsWeapons",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>("text", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_FactionsWeapons", x => x.Id); });

        migrationBuilder.CreateTable(
            "CharacterFaction",
            table => new
            {
                CharactersId = table.Column<int>("integer", nullable: false),
                FactionsId = table.Column<int>("integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CharacterFaction", x => new { x.CharactersId, x.FactionsId });
                table.ForeignKey(
                    "FK_CharacterFaction_Characters_CharactersId",
                    x => x.CharactersId,
                    "Characters",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_CharacterFaction_FactionsWeapons_FactionsId",
                    x => x.FactionsId,
                    "FactionsWeapons",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_CharacterFaction_FactionsId",
            "CharacterFaction",
            "FactionsId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "CharacterFaction");

        migrationBuilder.DropTable(
            "FactionsWeapons");
    }
}
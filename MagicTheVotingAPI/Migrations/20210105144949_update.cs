using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicTheVotingAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MagicVotePair",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CardAMultiverseId = table.Column<int>(nullable: true),
                    CardBMultiverseId = table.Column<int>(nullable: true),
                    CardAVotes = table.Column<int>(nullable: false),
                    CardBVotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicVotePair", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicVotePair_MagicCard_CardAMultiverseId",
                        column: x => x.CardAMultiverseId,
                        principalTable: "MagicCard",
                        principalColumn: "MultiverseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MagicVotePair_MagicCard_CardBMultiverseId",
                        column: x => x.CardBMultiverseId,
                        principalTable: "MagicCard",
                        principalColumn: "MultiverseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MagicVotePair_CardAMultiverseId",
                table: "MagicVotePair",
                column: "CardAMultiverseId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicVotePair_CardBMultiverseId",
                table: "MagicVotePair",
                column: "CardBMultiverseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MagicVotePair");
        }
    }
}

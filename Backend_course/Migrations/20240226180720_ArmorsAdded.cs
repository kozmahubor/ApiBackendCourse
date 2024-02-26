using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_course.Migrations
{
    /// <inheritdoc />
    public partial class ArmorsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmorCharacter",
                columns: table => new
                {
                    ArmorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharactersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorCharacter", x => new { x.ArmorsId, x.CharactersId });
                    table.ForeignKey(
                        name: "FK_ArmorCharacter_Armors_ArmorsId",
                        column: x => x.ArmorsId,
                        principalTable: "Armors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorCharacter_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Armors",
                columns: new[] { "Id", "Name", "Resist" },
                values: new object[,]
                {
                    { new Guid("601c0da6-17d6-4553-9795-453ec11d79a2"), "Boots", 15 },
                    { new Guid("7b741263-1b93-40c0-a85a-1943c099cfb9"), "Shield", 50 },
                    { new Guid("926df240-4214-44d5-9dd1-03a7dc10f975"), "Chestplate", 30 },
                    { new Guid("9c349ea0-44dc-4ef1-b280-2750fa9ef209"), "Helmet", 10 },
                    { new Guid("b389f7d3-e060-4584-a60f-9741475b67f1"), "Leggings", 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmorCharacter_CharactersId",
                table: "ArmorCharacter",
                column: "CharactersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmorCharacter");

            migrationBuilder.DropTable(
                name: "Armors");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_course.Migrations
{
    /// <inheritdoc />
    public partial class bugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("601c0da6-17d6-4553-9795-453ec11d79a2"));

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("7b741263-1b93-40c0-a85a-1943c099cfb9"));

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("926df240-4214-44d5-9dd1-03a7dc10f975"));

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("9c349ea0-44dc-4ef1-b280-2750fa9ef209"));

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("b389f7d3-e060-4584-a60f-9741475b67f1"));

            migrationBuilder.InsertData(
                table: "Armors",
                columns: new[] { "Id", "Name", "Resist" },
                values: new object[,]
                {
                    { new Guid("39a832b5-7ca9-4241-80c1-e3f5828dedbc"), "Boots", 15 },
                    { new Guid("892e830b-5854-416c-ac08-10cca04b2e23"), "Helmet", 10 },
                    { new Guid("95c1c556-a7b1-4bd6-9805-7cbdca7cfffc"), "Shield", 50 },
                    { new Guid("c19d8d3d-ad93-4f0c-8488-5dc309bae0e0"), "Leggings", 20 },
                    { new Guid("e93670d0-75bb-497c-92ea-7cb820ff96db"), "Chestplate", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("39a832b5-7ca9-4241-80c1-e3f5828dedbc"));

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("892e830b-5854-416c-ac08-10cca04b2e23"));

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("95c1c556-a7b1-4bd6-9805-7cbdca7cfffc"));

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("c19d8d3d-ad93-4f0c-8488-5dc309bae0e0"));

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("e93670d0-75bb-497c-92ea-7cb820ff96db"));

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
        }
    }
}

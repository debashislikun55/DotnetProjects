using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("55890013-7386-4920-b508-017f4ae0c71f"), "Medium" },
                    { new Guid("9834664c-58fe-41f3-b213-4ac3c96e7a42"), "Easy" },
                    { new Guid("a6bcf8e3-8d70-4d9d-98ef-e5c5d75c708e"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "RegionImageUrl", "code", "name" },
                values: new object[,]
                {
                    { new Guid("1368538a-efe5-412b-81f0-b7d030486884"), null, "BOP", "Bay of plenty" },
                    { new Guid("1368538a-efe5-412b-81f0-b7e030476884"), null, "STL", "Southland" },
                    { new Guid("2fe54e01-21a8-41bf-9dae-a9033c863bd0"), "https://AKL.url", "AKL", "Auckland" },
                    { new Guid("f2c84407-ce28-4952-b3e7-bfd60ecc3044"), "https://ntl.url", "NTL", "Northland" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("55890013-7386-4920-b508-017f4ae0c71f"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("9834664c-58fe-41f3-b213-4ac3c96e7a42"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("a6bcf8e3-8d70-4d9d-98ef-e5c5d75c708e"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("1368538a-efe5-412b-81f0-b7d030486884"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("1368538a-efe5-412b-81f0-b7e030476884"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("2fe54e01-21a8-41bf-9dae-a9033c863bd0"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("f2c84407-ce28-4952-b3e7-bfd60ecc3044"));
        }
    }
}

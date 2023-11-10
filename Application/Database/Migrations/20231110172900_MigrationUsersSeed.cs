using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUsersSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("18821ff2-7224-4316-ba1f-3883f9089287"), new DateTime(2005, 11, 10, 18, 29, 0, 522, DateTimeKind.Local).AddTicks(7089), "user", "ik/1g2rQCe3FZqmPv7nabsM563LpBfBKwsxQgLr8z2I=:iurqxkfltF1pHzjmblSwbQ==:10000:SHA256", 0, "user" },
                    { new Guid("ed78a8c9-201f-491b-8afe-a080fc1cb6df"), new DateTime(2003, 11, 10, 18, 29, 0, 513, DateTimeKind.Local).AddTicks(2431), "admin", "EdaZ/7r06IeBJxTfea14VxKVrZZz2zm0SWz8vfzhUpI=:uIOLRb+P9iF2AuznnF2Iuw==:10000:SHA256", 2, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("18821ff2-7224-4316-ba1f-3883f9089287"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed78a8c9-201f-491b-8afe-a080fc1cb6df"));
        }
    }
}

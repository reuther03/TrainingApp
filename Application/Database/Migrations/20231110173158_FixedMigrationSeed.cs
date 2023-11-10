using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixedMigrationSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("18821ff2-7224-4316-ba1f-3883f9089287"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed78a8c9-201f-491b-8afe-a080fc1cb6df"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("5fde871c-15f5-419f-a132-c766b37b71a7"), new DateTime(2003, 11, 10, 18, 31, 58, 566, DateTimeKind.Local).AddTicks(4220), "admin@email.com", "Jc9QGSy6JiDYIByaLoj4OApubS+KObRK1t8yJJiU61Y=:CQCBWd7W0gYT89kJXXrg7g==:10000:SHA256", 2, "admin" },
                    { new Guid("aa923149-86d9-4b2d-b831-060fecf69e47"), new DateTime(2005, 11, 10, 18, 31, 58, 573, DateTimeKind.Local).AddTicks(9978), "user@email.com", "t4FYq2L2zxFBWwYoCA/QoC0HlIHzm56rDUIVWwvuCI0=:zcGCVgFrn79B44T4mP3wng==:10000:SHA256", 0, "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5fde871c-15f5-419f-a132-c766b37b71a7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa923149-86d9-4b2d-b831-060fecf69e47"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("18821ff2-7224-4316-ba1f-3883f9089287"), new DateTime(2005, 11, 10, 18, 29, 0, 522, DateTimeKind.Local).AddTicks(7089), "user", "ik/1g2rQCe3FZqmPv7nabsM563LpBfBKwsxQgLr8z2I=:iurqxkfltF1pHzjmblSwbQ==:10000:SHA256", 0, "user" },
                    { new Guid("ed78a8c9-201f-491b-8afe-a080fc1cb6df"), new DateTime(2003, 11, 10, 18, 29, 0, 513, DateTimeKind.Local).AddTicks(2431), "admin", "EdaZ/7r06IeBJxTfea14VxKVrZZz2zm0SWz8vfzhUpI=:uIOLRb+P9iF2AuznnF2Iuw==:10000:SHA256", 2, "admin" }
                });
        }
    }
}

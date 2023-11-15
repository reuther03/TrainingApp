using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsGlobalProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("545d78b4-1016-4dd7-91a8-1fcec3bcc559"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62f7078f-590e-45b3-aa3f-2d2c626a8e92"));

            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "TrainingPlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "TrainingPlanExercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "Email", "Password", "Role", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { new Guid("267a5558-c6e5-4485-b1c5-399af5e19763"), new DateTime(2005, 11, 14, 18, 51, 50, 883, DateTimeKind.Local).AddTicks(5150), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "user@email.com", "POkmaWvxk7Jpk1giVgbhLxIdz+nKEug+PMIG5YLL5ds=:XvH/22DknetY0qK5RTA3xg==:10000:SHA256", 0, null, null, "user" },
                    { new Guid("caa52184-8fd1-46d9-8b56-8b637c631a12"), new DateTime(2003, 11, 14, 18, 51, 50, 876, DateTimeKind.Local).AddTicks(7467), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@email.com", "zu0tBLmLZ5zQ2dIBQo6xvL4G3jomLIQCgz94faE0KLA=:uIz9WStnZSHgZKs2EsDQ5w==:10000:SHA256", 2, null, null, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("267a5558-c6e5-4485-b1c5-399af5e19763"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("caa52184-8fd1-46d9-8b56-8b637c631a12"));

            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "TrainingPlanExercises");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "Email", "Password", "Role", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { new Guid("545d78b4-1016-4dd7-91a8-1fcec3bcc559"), new DateTime(2003, 11, 11, 23, 59, 32, 92, DateTimeKind.Local).AddTicks(8911), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@email.com", "8wxerU8lvgj+//g9Rfb8R8YOxwR+I2Q4x76Fi6w1GAM=:589BIyciq6Xehfcggeimrw==:10000:SHA256", 2, null, null, "admin" },
                    { new Guid("62f7078f-590e-45b3-aa3f-2d2c626a8e92"), new DateTime(2005, 11, 11, 23, 59, 32, 100, DateTimeKind.Local).AddTicks(9089), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "user@email.com", "bQBjoLISjDAtLVo15ATGkobADyFlieQIhaK0p/VCSvI=:PN2y3P5QGfw1RtTxeIGF4g==:10000:SHA256", 0, null, null, "user" }
                });
        }
    }
}

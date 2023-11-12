using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedBaseEntityProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5fde871c-15f5-419f-a132-c766b37b71a7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa923149-86d9-4b2d-b831-060fecf69e47"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Trainings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Trainings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Trainings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Trainings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TrainingPlans",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "TrainingPlans",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TrainingPlans",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "TrainingPlans",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TrainingPlanExercises",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "TrainingPlanExercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TrainingPlanExercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "TrainingPlanExercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Exercises",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Exercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Exercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Exercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "Email", "Password", "Role", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { new Guid("545d78b4-1016-4dd7-91a8-1fcec3bcc559"), new DateTime(2003, 11, 11, 23, 59, 32, 92, DateTimeKind.Local).AddTicks(8911), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@email.com", "8wxerU8lvgj+//g9Rfb8R8YOxwR+I2Q4x76Fi6w1GAM=:589BIyciq6Xehfcggeimrw==:10000:SHA256", 2, null, null, "admin" },
                    { new Guid("62f7078f-590e-45b3-aa3f-2d2c626a8e92"), new DateTime(2005, 11, 11, 23, 59, 32, 100, DateTimeKind.Local).AddTicks(9089), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "user@email.com", "bQBjoLISjDAtLVo15ATGkobADyFlieQIhaK0p/VCSvI=:PN2y3P5QGfw1RtTxeIGF4g==:10000:SHA256", 0, null, null, "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("545d78b4-1016-4dd7-91a8-1fcec3bcc559"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62f7078f-590e-45b3-aa3f-2d2c626a8e92"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TrainingPlanExercises");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TrainingPlanExercises");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TrainingPlanExercises");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TrainingPlanExercises");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Exercises");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("5fde871c-15f5-419f-a132-c766b37b71a7"), new DateTime(2003, 11, 10, 18, 31, 58, 566, DateTimeKind.Local).AddTicks(4220), "admin@email.com", "Jc9QGSy6JiDYIByaLoj4OApubS+KObRK1t8yJJiU61Y=:CQCBWd7W0gYT89kJXXrg7g==:10000:SHA256", 2, "admin" },
                    { new Guid("aa923149-86d9-4b2d-b831-060fecf69e47"), new DateTime(2005, 11, 10, 18, 31, 58, 573, DateTimeKind.Local).AddTicks(9978), "user@email.com", "t4FYq2L2zxFBWwYoCA/QoC0HlIHzm56rDUIVWwvuCI0=:zcGCVgFrn79B44T4mP3wng==:10000:SHA256", 0, "user" }
                });
        }
    }
}

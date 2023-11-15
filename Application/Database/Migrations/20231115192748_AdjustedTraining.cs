using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedTraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TrainingPlanExercises_TrainingPlanExerciseId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingPlanExerciseId",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("267a5558-c6e5-4485-b1c5-399af5e19763"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("caa52184-8fd1-46d9-8b56-8b637c631a12"));

            migrationBuilder.RenameColumn(
                name: "TrainingPlanExerciseId",
                table: "Exercises",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Trainings",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Exercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MuscleGroup",
                table: "Exercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TutorialUrl",
                table: "Exercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "Email", "Password", "Role", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { new Guid("90909428-90a3-472f-82c1-1cae2958ecc1"), new DateTime(2003, 11, 15, 20, 27, 48, 504, DateTimeKind.Local).AddTicks(2215), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@email.com", "J85YDXM03webh4ikxnHdwxz+5iT8jN9XaGhXhF4nFhw=:uAS5N7Najc7j6gcg5PsJjw==:10000:SHA256", 2, null, null, "admin" },
                    { new Guid("9b243303-a4ee-4e8d-b6fd-b1bcf9221c64"), new DateTime(2005, 11, 15, 20, 27, 48, 510, DateTimeKind.Local).AddTicks(8621), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "user@email.com", "/BAz3OIVZDzQzzNoW1Yq2yy99zrLPMi+lFAdWZZhqkU=:AviXVWNvYxSmEvehhPus2Q==:10000:SHA256", 0, null, null, "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_UserId",
                table: "Trainings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Users_UserId",
                table: "Trainings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Users_UserId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_UserId",
                table: "Trainings");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90909428-90a3-472f-82c1-1cae2958ecc1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b243303-a4ee-4e8d-b6fd-b1bcf9221c64"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MuscleGroup",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TutorialUrl",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Exercises",
                newName: "TrainingPlanExerciseId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "Email", "Password", "Role", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { new Guid("267a5558-c6e5-4485-b1c5-399af5e19763"), new DateTime(2005, 11, 14, 18, 51, 50, 883, DateTimeKind.Local).AddTicks(5150), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "user@email.com", "POkmaWvxk7Jpk1giVgbhLxIdz+nKEug+PMIG5YLL5ds=:XvH/22DknetY0qK5RTA3xg==:10000:SHA256", 0, null, null, "user" },
                    { new Guid("caa52184-8fd1-46d9-8b56-8b637c631a12"), new DateTime(2003, 11, 14, 18, 51, 50, 876, DateTimeKind.Local).AddTicks(7467), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@email.com", "zu0tBLmLZ5zQ2dIBQo6xvL4G3jomLIQCgz94faE0KLA=:uIz9WStnZSHgZKs2EsDQ5w==:10000:SHA256", 2, null, null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingPlanExerciseId",
                table: "Exercises",
                column: "TrainingPlanExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TrainingPlanExercises_TrainingPlanExerciseId",
                table: "Exercises",
                column: "TrainingPlanExerciseId",
                principalTable: "TrainingPlanExercises",
                principalColumn: "Id");
        }
    }
}

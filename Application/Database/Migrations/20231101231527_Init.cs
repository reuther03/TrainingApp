using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingPlanExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MuscleGroup = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    TutorialUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlanTrainingPlanExercise",
                columns: table => new
                {
                    ExercisesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrainingPlanId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanTrainingPlanExercise", x => new { x.ExercisesId, x.TrainingPlanId });
                    table.ForeignKey(
                        name: "FK_TrainingPlanTrainingPlanExercise_TrainingPlanExercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "TrainingPlanExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlanTrainingPlanExercise_TrainingPlans_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Sets = table.Column<int>(type: "INTEGER", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    TrainingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrainingPlanExerciseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_TrainingPlanExercises_TrainingPlanExerciseId",
                        column: x => x.TrainingPlanExerciseId,
                        principalTable: "TrainingPlanExercises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exercises_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingPlanExerciseId",
                table: "Exercises",
                column: "TrainingPlanExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanTrainingPlanExercise_TrainingPlanId",
                table: "TrainingPlanTrainingPlanExercise",
                column: "TrainingPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "TrainingPlanTrainingPlanExercise");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "TrainingPlanExercises");

            migrationBuilder.DropTable(
                name: "TrainingPlans");
        }
    }
}

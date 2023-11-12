﻿// <auto-generated />
using System;
using Application.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Application.Database.Migrations
{
    [DbContext(typeof(TrainingDbContext))]
    [Migration("20231111225932_AddedBaseEntityProps")]
    partial class AddedBaseEntityProps
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Domain.TrainingPlans.TrainingPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TrainingPlans");
                });

            modelBuilder.Entity("Domain.TrainingPlans.TrainingPlanExercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("MuscleGroup")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TutorialUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TrainingPlanExercises");
                });

            modelBuilder.Entity("Domain.Trainings.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<double>("Kg")
                        .HasColumnType("REAL");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<int>("Reps")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sets")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TrainingPlanExerciseId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.HasIndex("TrainingPlanExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Domain.Trainings.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("545d78b4-1016-4dd7-91a8-1fcec3bcc559"),
                            BirthDate = new DateTime(2003, 11, 11, 23, 59, 32, 92, DateTimeKind.Local).AddTicks(8911),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@email.com",
                            Password = "8wxerU8lvgj+//g9Rfb8R8YOxwR+I2Q4x76Fi6w1GAM=:589BIyciq6Xehfcggeimrw==:10000:SHA256",
                            Role = 2,
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("62f7078f-590e-45b3-aa3f-2d2c626a8e92"),
                            BirthDate = new DateTime(2005, 11, 11, 23, 59, 32, 100, DateTimeKind.Local).AddTicks(9089),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user@email.com",
                            Password = "bQBjoLISjDAtLVo15ATGkobADyFlieQIhaK0p/VCSvI=:PN2y3P5QGfw1RtTxeIGF4g==:10000:SHA256",
                            Role = 0,
                            Username = "user"
                        });
                });

            modelBuilder.Entity("TrainingPlanTrainingPlanExercise", b =>
                {
                    b.Property<Guid>("ExercisesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TrainingPlanId")
                        .HasColumnType("TEXT");

                    b.HasKey("ExercisesId", "TrainingPlanId");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("TrainingPlanTrainingPlanExercise");
                });

            modelBuilder.Entity("Domain.Trainings.Exercise", b =>
                {
                    b.HasOne("Domain.Trainings.Training", "Training")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TrainingPlans.TrainingPlanExercise", "TrainingPlanExercise")
                        .WithMany()
                        .HasForeignKey("TrainingPlanExerciseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Training");

                    b.Navigation("TrainingPlanExercise");
                });

            modelBuilder.Entity("TrainingPlanTrainingPlanExercise", b =>
                {
                    b.HasOne("Domain.TrainingPlans.TrainingPlanExercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TrainingPlans.TrainingPlan", null)
                        .WithMany()
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Trainings.Training", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
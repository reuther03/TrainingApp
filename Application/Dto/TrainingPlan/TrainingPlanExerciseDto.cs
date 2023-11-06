﻿using Domain.TrainingPlans;

namespace Application.Dto.TrainingPlan;

public class TrainingPlanExerciseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string MuscleGroup { get; set; } = default!;
    public string? ImgUrl { get; set; }
}
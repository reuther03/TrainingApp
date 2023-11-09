using Application.Features.TrainingPlanExercises.Dto;

namespace Application.Features.TrainingPlans.Dto;

public class TrainingPlanDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<TrainingPlanExerciseDetailsDto> Exercises { get; set; }
}
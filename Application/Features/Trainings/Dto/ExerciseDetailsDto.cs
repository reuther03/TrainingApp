namespace Application.Features.Trainings.Dto;

public class ExerciseDetailsDto
{
    public double Kg { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public string? Note { get; set; } = null;
}
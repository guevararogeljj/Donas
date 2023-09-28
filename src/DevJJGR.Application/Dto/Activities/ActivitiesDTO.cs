namespace Donouts.Application.Dto.Activities;

public class ActivitiesDTO : EntityDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public bool Visible { get; set; }
}
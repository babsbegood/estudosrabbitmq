namespace EstudosRabbit.Core.Event
{
    public record DirectEvent(Guid id, string description, string type = "direct");
}

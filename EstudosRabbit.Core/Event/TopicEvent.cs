namespace EstudosRabbit.Core.Event
{
    public record TopicEvent(Guid id, string description, string type = "topic");
}

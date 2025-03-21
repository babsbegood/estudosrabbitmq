namespace EstudosRabbit.Core.Event
{
    public record FanoutEvent(Guid id, string description, string type = "fanout");

}

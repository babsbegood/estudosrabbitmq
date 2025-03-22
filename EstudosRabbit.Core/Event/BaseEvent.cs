namespace EstudosRabbit.Core.Event
{
    public abstract record BaseEvent
    {
        public Guid MessageId { get; set; } = Guid.NewGuid();
    }
}

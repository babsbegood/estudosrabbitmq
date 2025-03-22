namespace EstudosRabbit.Core.Event
{
    public record FanoutEvent : BaseEvent
    {
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = "fanout";

        public FanoutEvent(Guid messageId, string description)
        {
            MessageId = messageId;
            Description = description;
        }
    }
}

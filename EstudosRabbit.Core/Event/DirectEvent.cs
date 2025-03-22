namespace EstudosRabbit.Core.Event
{
    public record DirectEvent : BaseEvent
    {
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = "direct";

        public DirectEvent(Guid messageId, string description)
        {
            MessageId = messageId;
            Description = description;
        }
    }
}

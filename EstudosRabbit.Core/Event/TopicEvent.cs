﻿namespace EstudosRabbit.Core.Event
{
    public record TopicEvent: BaseEvent
    {
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = "topic";

        public TopicEvent(Guid messageId, string description)
        {
            MessageId = messageId;
            Description = description;
        }
    }
}

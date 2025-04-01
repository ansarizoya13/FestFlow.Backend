using FestFlow.Backend.API.Enums;

namespace FestFlow.Backend.API.Responses
{
    public class EventWithQuestionResponse
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public List<EventQuestionairre> EventQuestionairres { get; set; }
    }

    public class EventQuestionairre
    {
        public Guid EventQuestionnaireId { get; set; }
        public string Label { get; set; }
        public InputElements Type { get; set; }
        public bool Mandatory { get; set; }
        public int Sequence { get; set; }
        public bool HasMultipleAnswers { get; set; }
        public List<EventQuestionairreOption>? Options { get; set; }
    }

    public class EventQuestionairreOption
    {
        public Guid EventQuestionairreOptionSetId { get; set; }
        public string Option { get; set; }
    }
}

namespace FestFlow.Backend.API.Responses
{
    public class GetEventsResponse
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLive { get; set; }
        public bool IsAvailableForFeedback { get; set; }
    }
}

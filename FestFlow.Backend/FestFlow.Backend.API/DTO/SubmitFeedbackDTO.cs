namespace FestFlow.Backend.API.DTO
{
    public class SubmitFeedbackDTO
    {
        public Guid EventId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}

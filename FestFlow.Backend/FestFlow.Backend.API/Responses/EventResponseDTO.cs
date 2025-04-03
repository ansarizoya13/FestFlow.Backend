namespace FestFlow.Backend.API.Responses
{
    public class EventResponseDto
    {
        public List<EventQuestionnaireResponseDto> Responses { get; set; }
    }

    public class EventQuestionnaireResponseDto
    {
        public Guid EventQuestionnaireId { get; set; }  // ID of the question
        public string? Answer { get; set; }  // User's input (text, number, email, etc.)
        public List<Guid>? EventQuestionnaireOptionSetIds { get; set; }  // Selected options (for dropdown, checkbox, radio)
    }
}

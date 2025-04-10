namespace FestFlow.Backend.API.DTO
{
    public class EventCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> Branches { get; set; }
        public List<QuestionCreateDTO> Questions { get; set; }
    }

    public class QuestionCreateDTO
    {
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public bool Mandatory { get; set; }
        public List<string> Options { get; set; }
    }
}

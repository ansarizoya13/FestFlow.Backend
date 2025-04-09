namespace FestFlow.Backend.API.Responses
{
    public class EventQuestionAnswersResponse
    {
        public Guid EventQuestionnaireID { get; set; }
        public string QuestionLabel { get; set; }
        public int Type { get; set; }
        public bool IsOptionSet { get; set; }
        public int Sequence { get; set; }
        public Guid? AnswerID { get; set; }
        public Guid UserId { get; set; }
        public string Answer { get; set; }
        public int AnswerCount { get; set; }
    }
}

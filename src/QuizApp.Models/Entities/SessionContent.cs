namespace QuizApp.Models.Entities
{
    public class SessionContent
    {
        public Guid SessionId { get; set; }
        public Guid SubscriberId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
        public bool IsSucess { get; set; }
    }
}

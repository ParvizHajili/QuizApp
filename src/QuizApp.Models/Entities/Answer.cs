using QuizApp.Models.Common;

namespace QuizApp.Models.Entities
{
    public class Answer : BaseEntity<Guid>
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
    }
}

using QuizApp.Models.Common;

namespace QuizApp.Models.Entities
{
    public class Question : BaseEntity<Guid>
    {
        public string Text { get; set; }
        public Guid QuestionSetId { get; set; }
    }
}

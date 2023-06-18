using QuizApp.Models.Common;

namespace QuizApp.Models.Entities
{
    public class QuestionSet : BaseEntity<Guid>
    {
        public string Subject { get; set; }
    }
}

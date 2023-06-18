using QuizApp.Models.Common;

namespace QuizApp.Models.Entities
{
    public class Session : BaseEntity<Guid>
    {
        public string Code { get; set; }
        public Guid QuestionSetId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

namespace QuizApp.Models.Common
{
    public class BaseEntity<TKey> where TKey : unmanaged
    {
        public TKey Id { get; set; }
    }
}

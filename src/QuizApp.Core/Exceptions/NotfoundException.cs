using System.Runtime.Serialization;

namespace QuizApp.Core.Exceptions
{
    public class NotfoundException : Exception
    {
        public NotfoundException() : base() { }
        public NotfoundException(string message) : base(message) { }
        public NotfoundException(string message, Exception innerException) : base(message, innerException) { }
        public NotfoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

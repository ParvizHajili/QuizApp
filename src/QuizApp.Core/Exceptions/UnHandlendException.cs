using System.Runtime.Serialization;

namespace QuizApp.Core.Exceptions
{
    public class UnHandlendException : Exception
    {
        public UnHandlendException() : base() { }
        public UnHandlendException(string message) : base(message) { }
        public UnHandlendException(string message, Exception innerException) : base(message, innerException) { }
        public UnHandlendException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

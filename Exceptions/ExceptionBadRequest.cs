using System.Runtime.Serialization;

namespace StaffixAPI.Exceptions
{
    [Serializable]
    public class ExceptionBadRequest : Exception
    {
        public ExceptionBadRequest(string? message): base(message)
        {}
    }
}
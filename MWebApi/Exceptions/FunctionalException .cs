namespace MWebApi.Exceptions
{
    public class FunctionalException : Exception
    {
        public int ErrorCode { get; }

        public FunctionalException(string message, int errorCode): base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}

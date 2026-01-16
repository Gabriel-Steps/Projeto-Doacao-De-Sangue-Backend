namespace ProjetoDoacaoDeSangue.Application.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; }

        protected ApiException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}

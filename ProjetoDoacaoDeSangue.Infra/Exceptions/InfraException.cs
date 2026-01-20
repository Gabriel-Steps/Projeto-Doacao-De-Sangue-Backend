namespace ProjetoDoacaoDeSangue.Infra.Exceptions
{
    public class InfraException : Exception
    {
        public int StatusCode { get; }

        protected InfraException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}

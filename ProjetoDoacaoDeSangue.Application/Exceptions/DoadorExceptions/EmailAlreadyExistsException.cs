namespace ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions
{
    public class EmailAlreadyExistsException : ApiException
    {
        public EmailAlreadyExistsException(string email)
        : base($"Email already exists: {email}", 409)
        {
        }
    }
}

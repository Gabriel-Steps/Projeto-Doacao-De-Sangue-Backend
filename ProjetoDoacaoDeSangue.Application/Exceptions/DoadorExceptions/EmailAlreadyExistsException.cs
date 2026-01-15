namespace ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions
{
    internal class EmailAlreadyExistsException : ApiException
    {
        public EmailAlreadyExistsException(string email) : base($"Email already exists: {email}", 400)
        {
        }
    }
}

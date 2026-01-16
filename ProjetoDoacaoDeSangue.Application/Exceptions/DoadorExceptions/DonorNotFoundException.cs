namespace ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions
{
    public class DonorNotFoundException : ApiException
    {
        public DonorNotFoundException(int id) : 
            base($"Donor with ID {id} was not found.", 404)
        {
        }
    }
}

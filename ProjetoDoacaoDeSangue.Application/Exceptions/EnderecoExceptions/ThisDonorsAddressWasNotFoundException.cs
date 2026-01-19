namespace ProjetoDoacaoDeSangue.Application.Exceptions.EnderecoExceptions
{
    public class ThisDonorsAddressWasNotFoundException : ApiException
    {
        public ThisDonorsAddressWasNotFoundException(int id) :
            base($"The donor address with this ID: {id} does not exist.", 404)
        {
        }
    }
}

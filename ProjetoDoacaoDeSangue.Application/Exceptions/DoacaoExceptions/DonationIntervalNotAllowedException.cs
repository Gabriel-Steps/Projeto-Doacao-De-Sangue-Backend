namespace ProjetoDoacaoDeSangue.Application.Exceptions.DoacaoExceptions
{
    public class DonationIntervalNotAllowedException : ApiException
    {
        public DonationIntervalNotAllowedException(int dias) : 
            base($"This donor must wait {dias} days between donations.", 400)
        {
        }
    }
}

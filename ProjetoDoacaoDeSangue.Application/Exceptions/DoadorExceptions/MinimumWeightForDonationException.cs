namespace ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions
{
    public class MinimumWeightForDonationException : ApiException
    {
        public MinimumWeightForDonationException() : base("The minimum weight for donating blood is 50 kg.", 400)
        {
        }
    }
}

namespace ProjetoDoacaoDeSangue.Core.Exceptions.DoadorExceptions
{
    public class MinimumWeightForDonationException : DomainException
    {
        public MinimumWeightForDonationException() : base("The minimum weight for donating blood is 50 kg.")
        {
        }
    }
}

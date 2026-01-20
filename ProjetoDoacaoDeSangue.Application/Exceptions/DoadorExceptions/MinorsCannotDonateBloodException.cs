namespace ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions
{
    public class MinorsCannotDonateBloodException : ApiException
    {
        public MinorsCannotDonateBloodException() 
            : base("Minors are not allowed to donate blood.", 400)
        {
        }
    }
}

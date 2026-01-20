namespace ProjetoDoacaoDeSangue.Application.Exceptions.EstoqueSangueExceptions
{
    public class BloodSupplyNotFoundException : ApiException
    {
        public BloodSupplyNotFoundException() :
            base("The blood type provided is not yet registered in the database.", 404) { }
    }
}

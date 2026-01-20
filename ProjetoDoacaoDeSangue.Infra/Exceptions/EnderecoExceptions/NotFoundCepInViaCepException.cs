namespace ProjetoDoacaoDeSangue.Infra.Exceptions.EnderecoExceptions
{
    public class NotFoundCepInViaCepException : InfraException
    {
        public NotFoundCepInViaCepException(string cep) 
            : base($"The CEP: {cep} was not found ", 404) { }
    }
}

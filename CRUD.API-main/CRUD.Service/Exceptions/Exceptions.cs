namespace CRUD.Service.Exceptions
{
    public class RegraNegocioException : Exception
    {
        public RegraNegocioException(string message) : base(message) { }
    }

    public class ConflitoException : Exception
    {
        public ConflitoException(string message) : base(message) { }
    }

    public class NaoEncontradoException : Exception
    {
        public NaoEncontradoException(string message) : base(message) { }
    }

    public class ServicoIndisponivelException : Exception
    {
        public ServicoIndisponivelException(string message) : base(message) { }
    }
}

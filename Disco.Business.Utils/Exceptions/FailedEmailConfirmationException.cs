namespace Disco.Business.Utils.Exceptions
{
    public class FailedEmailConfirmationException : Exception
    {
        private readonly Dictionary<string, string> Errors;

        public FailedEmailConfirmationException(Dictionary<string, string> errors)
        {
            Errors = errors;
        }
    }
}

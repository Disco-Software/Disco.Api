namespace Disco.Business.Utils.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public Dictionary<string, string> Errors { get; }

        public InvalidPasswordException(Dictionary<string, string> errors)
        {
            Errors = errors;
        }
    }
}

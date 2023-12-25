namespace Disco.Business.Interfaces.Dtos.Errors.Admin.Error
{
    public class ErrorMessage
    {
        public ErrorMessage(
            string name,
            string message)
        {
            Name = name;
            Message = message;
        }

        public string Name { get; set; }
        public string Message { get; set; }
    }
}

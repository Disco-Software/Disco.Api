namespace Disco.Business.Interfaces.Dtos.Errors.Admin.Error
{
    public class ErrorDto
    {
        public ErrorDto() { }
        public ErrorDto(
            List<ErrorMessage> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public List<ErrorMessage> ErrorMessages { get; set; }
    }
}

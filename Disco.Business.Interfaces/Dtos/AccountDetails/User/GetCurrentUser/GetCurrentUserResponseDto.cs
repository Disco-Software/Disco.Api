namespace Disco.Business.Interfaces.Dtos.AccountDetails.User.GetCurrentUser
{
    public class GetCurrentUserResponseDto
    {
        public GetCurrentUserResponseDto(
            UserDto user)
        {
            User = user;
        }

        public UserDto User { get; set; }
    }
}

namespace Disco.Business.Interfaces.Dtos.AccountDetails.User.ChangePhoto
{
    public class ChangePhotoResponseDto
    {
        public ChangePhotoResponseDto(
            UserDto user)
        {
            User = user;
        }

        public UserDto User { get; set; }
    }
}

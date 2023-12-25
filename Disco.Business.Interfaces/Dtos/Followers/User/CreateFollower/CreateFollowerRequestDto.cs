namespace Disco.Business.Interfaces.Dtos.Followers.User.CreateFollower
{
    public class CreateFollowerRequestDto
    {
        public CreateFollowerRequestDto(
            int userId,
            string? installationId)
        {
            AccountId = userId;
            InstallationId = installationId;
        }

        public int AccountId { get; set; }
        public string? InstallationId {  get; set; }
    }
}

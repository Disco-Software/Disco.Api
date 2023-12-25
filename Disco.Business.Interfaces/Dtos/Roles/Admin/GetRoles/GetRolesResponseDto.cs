namespace Disco.Business.Interfaces.Dtos.Roles.Admin.GetRoles
{
    public class GetRolesResponseDto
    {
        public GetRolesResponseDto(
            string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

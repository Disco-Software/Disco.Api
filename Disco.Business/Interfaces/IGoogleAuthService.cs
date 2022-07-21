using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1.Data;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IGoogleAuthService
    {
        Task<Person> GetUserData(IGoogleAuthProvider authProvider);
    }
}

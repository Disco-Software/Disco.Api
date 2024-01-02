namespace Disco.Business.Interfaces.Interfaces
{
    public interface IPasswordRecoveryGeneratorService
    {
        Task<string> GetPasswordRecoveryAsync();
    }
}

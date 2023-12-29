namespace Disco.Business.Interfaces.Interfaces
{
    public interface IEmailGeneratorService
    {
        Task<string> GenerateEmailConfirmationContentAsync();
    }
}

namespace Disco.Business.Interfaces.Options.EmailConfirmation
{
    public class EmailConfirmationCodeConfigurationOptions
    {
        public EmailConfirmationCodeConfigurationOptions() { }

        public SecurityOptions SecurityOptions { get; set; } = new SecurityOptions();
    }
}

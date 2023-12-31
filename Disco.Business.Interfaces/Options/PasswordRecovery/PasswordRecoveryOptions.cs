namespace Disco.Business.Interfaces.Options.PasswordRecovery
{
    public class PasswordRecoveryOptions
    {
        public PasswordRecoveryOptions() { }
        public PasswordRecoveryOptions(
            TemplateOptions templateOptions,
            int repetitions,
            int lifeTime)
        {
            Templates = templateOptions;
            Repetitions = repetitions;
            LifeTime = lifeTime;

        }

        public TemplateOptions Templates { get; set; }
        public int Repetitions { get; set; }
        public int LifeTime {  get; set; }
    }
}

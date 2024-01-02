namespace Disco.Business.Interfaces.Options.EmailConfirmation
{
    public class SecurityOptions
    {
        public SecurityOptions() { }
        public SecurityOptions(
            int lifeTime)
        {
            LifeTime = lifeTime;
        }

        public int LifeTime { get; set; }
    }
}

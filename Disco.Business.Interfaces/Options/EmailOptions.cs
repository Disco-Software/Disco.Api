namespace Disco.Business.Interfaces.Options
{
    public class EmailOptions
    {
        public string Mail { get; set; }
        public string Name { get; set; } = "Disco";
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}

namespace Maia.Maps.Domain.Options
{
    public class DatabaseOptions
    {
        public const string Database = nameof(Database);

        public string? HostAddress { get; set; }
        public string? Name { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public int Porta { get; set; }
    }
}

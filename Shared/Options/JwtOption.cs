namespace Shared.Options
{
    public class JwtOption
    {
        public const string Jwt = "Jwt";
        public string Key { get; set; } = string.Empty;
        public string RefreshKey { get; set; } = string.Empty;
        public int DurationTokenInMinutes { get; set; }
    }
}

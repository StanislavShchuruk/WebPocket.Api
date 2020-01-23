namespace WebPocket.Services.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int AccessTokenLifeTime { get; set; }
    }
}

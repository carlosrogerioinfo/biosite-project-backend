
namespace Biosite.Core.JwtBearer
{
    public class TokenSettings
    {
        //For use JWT Authentication
        public static string SECRET_KEY = Runtime.JwtSecretKey;
        public static string AUDIENCE = Runtime.Audience;
        public static string ISSUER = Runtime.Issuer;
        public static int TIME_VALIDATION_TOKEN = Runtime.ExpiresInMinutes;
    }
}

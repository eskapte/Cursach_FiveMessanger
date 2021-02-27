using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FiveMessanger
{
    public class AuthOptions
    {
        public const string ISSUER = "FiveMessangerServer";
        public const string AUDIENCE = "FiveMessangerReactApp";
        const string KEY = "super mega puper secret key, i hope is will work";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
            => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}

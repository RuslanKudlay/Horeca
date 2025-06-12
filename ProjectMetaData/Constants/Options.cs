using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Horeca.Constants;

public class Options
{
    public class AuthOptions
    {
        public const string ISSUER = "horeca_server";
        public const string AUDIENCE = "horeca_client";
        const string KEY = "fekm@#E%$egrg345re34#$%#%^rgergrtg";
        public const int LIFETIME = 24 * 60; // minutes
        public const int REFRESHLIFETIME = 30 * 24 * 60; // minutes
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
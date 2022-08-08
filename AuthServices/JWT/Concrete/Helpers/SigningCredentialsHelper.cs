using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServices.JWT.Concrete.Helpers
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredential(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }

    }
}

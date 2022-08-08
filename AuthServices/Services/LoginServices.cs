using AuthServices.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServices.Services
{
    public class LoginServices : ILoginServices
    {
        public Task<ServicesResponse<LoginResponse>> Login()
        {
            ServicesResponse<LoginResponse> result = new ServicesResponse<LoginResponse>();
            return Login();
        }
    }
}

using AuthServices.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServices.Services
{
    public interface ILoginServices
    {
      public  Task<ServicesResponse<LoginResponse>> Login();

    }
}

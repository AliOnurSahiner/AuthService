using AuthServiceBussiness.Validation;
using AuthServices.Models.Request;
using AuthServicesDAL.Aspects.Autofac.Validation;
using AuthServicesDAL.Context.AuthDBContext;
using AuthServicesDAL.CrossCuttingConcerns.Validation;
using AuthServicesDAL.Entities.User;
using AuthServicesDAL.JWT.Concrete;
using AuthServicesDAL.JWT.Concrete.Abstract;
using System.Linq;


namespace AuthServiceBussiness.Concrete
{
    [ValidationAspect(typeof(LoginValidator),Priority =1)]
    public class AuthManager
    {
        private readonly AuthDBContext _context = new AuthDBContext();
     
        public AuthManager(AuthDBContext context)
        {
            _context=context;
          
        }

        public  User Login(LoginRequest request)
        {
            ValidationTool.Validate(new LoginValidator(), request);
            var getUserData = _context.Users.FirstOrDefault(x => x.Email.ToLower() == request.Email.ToLower() && x.Password == request.Password);
            if (getUserData != null)
            {
                return getUserData;
            }
            return null;

        }


        //public AccessToken CreateAccessToken(User user)
        //{
        //    var claims = _context.GetClaims(user);
        //    var accessToken = _tokenHelper.CreateToken(user, claims);
        //    return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        //}
    }
}


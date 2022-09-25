using AuthServices.JWT.Concrete;
using AuthServicesDAL.Entities.User;

namespace AuthServicesDAL.JWT.Concrete.Abstract
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}

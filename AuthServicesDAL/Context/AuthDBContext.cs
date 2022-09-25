using AuthServices.JWT.Concrete;
using AuthServicesDAL.Entities.User;
using AuthServicesDAL.JWT.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AuthServicesDAL.Context.AuthDBContext
{
    public class AuthDBContext : DbContext
    {
        public AuthDBContext()
        {

        }
        public AuthDBContext(DbContextOptions<AuthDBContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    }
}

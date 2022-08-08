using AuthServices.Entities;
using AuthServices.JWT.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServices.Context
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

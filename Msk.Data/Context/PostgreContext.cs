using Microsoft.EntityFrameworkCore;
using Msk.Domain.Login;
using Msk.Domain.Token;
using Msk.Domain.Users;


namespace Msk.Data.Context
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {

        }
        public DbSet<User> user { get; set; }
        public DbSet<UserRefreshTokens> userrefreshtokens { get; set; }
        public DbSet<Adress> adress { get; set; }
        


        public DbSet<Contact> contact { get; set; }
        //public DbSet<Adress> adress { get; set; }
        //public DbSet<Contact> contact { get; set; }
        //public DbSet<Login> login { get; set; }
    }
}

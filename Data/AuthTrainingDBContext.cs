using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace training.Data
{
    public class AuthTrainingDBContext : IdentityDbContext
    {
        public AuthTrainingDBContext(DbContextOptions<AuthTrainingDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(b => { b.ToTable("dara_users"); });
            builder.Entity<IdentityRole>(b => { b.ToTable("dara_roles"); });
            builder.Entity<IdentityUserRole<string>>(b => { b.ToTable("dara_userroles"); });
            builder.Entity<IdentityUserClaim<string>>(b => { b.ToTable("dara_userclaims"); });
            builder.Entity<IdentityUserLogin<string>>(b => { b.ToTable("dara_userlogins"); });
            builder.Entity<IdentityRoleClaim<string>>(b => { b.ToTable("dara_roleclaims"); });
            builder.Entity<IdentityUserToken<string>>(b => { b.ToTable("dara_usertokens"); });
            var adminRoleId = "7e65cd34-453e-4cd6-94e5-f0218948832b";
            var userRoleId = "87f94e74-b67b-4888-8a95-0636e910a3aa";
            var managerRoleId = "3b9a8725-1e43-4c1e-a6d1-cdf15e3cb6cc";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                new IdentityRole
                {
                    Id = managerRoleId,
                    ConcurrencyStamp = managerRoleId,
                    Name = "Manager",
                    NormalizedName = "Manager".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}

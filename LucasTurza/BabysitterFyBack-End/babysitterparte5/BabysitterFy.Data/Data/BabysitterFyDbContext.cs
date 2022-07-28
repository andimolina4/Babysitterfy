using BabysitterFy.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BabysitterFy.Data.Data
{
    public class BabysitterFyDbContext : IdentityDbContext<
        AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>> 
    {
        public DbSet<Babysitter> Babysitter { get; set; }
        public DbSet<Parent> Parent { get; set; }

        private readonly IConfiguration _configuration;
        public BabysitterFyDbContext(DbContextOptions<BabysitterFyDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("BaseProjectDatabase"), b => b.MigrationsAssembly("BabysitterFy.UI.WebAPI"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
               .HasMany(ur => ur.UserRoles)
               .WithOne(u => u.User)
               .HasForeignKey(u => u.UserId)
               .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId)
                .IsRequired();

            modelBuilder.Entity<AppRole>().HasData(
                 new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMINISTRATOR" },
                 new AppRole { Id = 2, Name = "Moderator", NormalizedName = "MODERATOR" },
                 new AppRole { Id = 3, Name = "Babysitter", NormalizedName = "BABYSITTER" },
                 new AppRole { Id = 4, Name = "Parent", NormalizedName = "PARENT" }
                );

            var user = new AppUser()
            {
                Id = 1,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM"
            };

            modelBuilder.Entity<AppUser>().HasData(user);

            var passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin123$.");

            var userRole = new AppUserRole() { UserId = 1, RoleId = 1 };

            modelBuilder.Entity<AppUserRole>().HasData(userRole);
        }
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RegjistriCivil.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>  
    {                                               
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<IdCard> IdCards { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<BirthCertificate> BirthCertificates { get; set; }
        public DbSet<MarriageCertificate> MarriageCertificates { get; set; }
        public DbSet<DeathCertificate> DeathCertificates { get; set; }
        public DbSet<FamilyCertificate> FamilyCertificates { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<FamilyMemberBase> FamilyMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            SeedRoles(modelBuilder);
            SeedUser(modelBuilder);
            SeedUserRoles(modelBuilder);
        }
        
        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = "3", Name = "Employee", NormalizedName = "EMPLOYEE" }
            );
        }
        
        private void SeedUser(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var adminUser = new IdentityUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin#123");
            modelBuilder.Entity<IdentityUser>().HasData(adminUser);
        }
        
        private void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" } // Admin
            );
        }
    }
}

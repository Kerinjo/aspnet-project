using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shared.Enums;

namespace Data
{
    public class LibraryContext : IdentityDbContext<IdentityUser>
    {
        public LibraryContext()
        {
        }
        public DbSet<UserEntity> Users{ get; set; }
        public DbSet<MediaEntity> Media { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var db = System.IO.Path.Join(path, "library.db");
            options.UseSqlite($"Data Source={db}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity() { Id = 1, Name = "zozol"}
            );
            modelBuilder.Entity<MediaEntity>().HasData(
                new MediaEntity() { Id = 1, Author = "Emily Bront\u00EB", Title = "Wuthering Heights", Category = Category.Book, Status = Status.Finished }
            );
            string ADMIN_ID = Guid.NewGuid().ToString();
            string TEST_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();
            string ROLE2_ID = Guid.NewGuid().ToString();

            // dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "test",
                NormalizedName = "TEST",
                Id = ROLE2_ID,
                ConcurrencyStamp = ROLE2_ID
            });

            // utworzenie administratora jako użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adminuser@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adminuser@wsei.edu.pl",
                NormalizedUserName = "ADMINUSER@WSEI.EDU.PL",
                NormalizedEmail = "ADMINUSER@WSEI.EDU.PL"
            };

            var test = new IdentityUser
            {
                Id = TEST_ID,
                Email = "testuser@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "testuser@wsei.edu.pl",
                NormalizedUserName = "TESTUSER@WSEI.EDU.PL",
                NormalizedEmail = "TESTUSER@WSEI.EDU.PL"
            };

            // haszowanie hasła, najlepiej wykonać to poza programem i zapisać gotowy
            // PasswordHash
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "S3cretPassword");
            test.PasswordHash = ph.HashPassword(test, "test123");

            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(test);

            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE2_ID,
                UserId = TEST_ID
            });
        }
    }
}

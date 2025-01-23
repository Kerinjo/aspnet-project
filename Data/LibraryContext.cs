using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace Data
{
    public class LibraryContext : DbContext
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
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity() { Id = 1, Name = "zozol"}
            );
            modelBuilder.Entity<MediaEntity>().HasData(
                new MediaEntity() { Id = 1, Author = "Emily Bront\u00EB", Title = "Wuthering Heights", Category = Category.Book, Status = Status.Finished }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PolyBook.Domain.Entities;

namespace PolyBook.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "29676f3e-7f57-4e4a-b72b-dc238f999541",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "49db4b55-76ac-49c9-80df-e7632fa3448b",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "29676f3e-7f57-4e4a-b72b-dc238f999541",
                UserId = "49db4b55-76ac-49c9-80df-e7632fa3448b"
            });

            modelBuilder.Entity<Gallery>().HasData(new Gallery
            {
                Id = new Guid("800eb303-5aae-4584-b187-672b5154dc73"),
                GalleryTitle = "Библиотека",
                GalleryNum = 0,
            });
            modelBuilder.Entity<Gallery>().HasData(new Gallery
            {
                Id = new Guid("8373b069-930c-4cef-8e14-8c855d93d0a8"),
                GalleryTitle = "Маркет",
                GalleryNum = 1,
            });

            modelBuilder.Entity<Gallery>().HasData(new Gallery
            {
                Id = new Guid("8c66dcd4-d113-4acb-92b8-19a79a60e66f"),
                GalleryTitle = "Ищу книгу",
                GalleryNum = 2,
            });

            modelBuilder.Entity<Gallery>().HasData(new Gallery
            {
                Id = new Guid("88ad46cc-0896-4215-86e3-3d94c3e00419"),
                GalleryTitle = "Рекомендую книгу",
                GalleryNum = 3,
            });
        }
    }
}

using Domain.Model.BloodRegister;
using Domain.Model.Posts;
using Domain.Model.Users;
using Domain.Model.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }

        public DbSet<Register> Registers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Event> Events { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "0d4492c3-c15e-4986-bbd6-d6157c06dbe1", Name = "ADMIN", NormalizedName = "ADMIN".ToUpper() });
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<Hospital>().HasData(
              new {Id=1,Name= "None",Address="None",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now },
              new { Id = 2, Name = "Bệnh viện Quốc tế", Address = "06 Ngô Quyền, Huế", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
             );
            //Seeding the User to AspNetUsers table
            
            modelBuilder.Entity<User>().HasData(
                new 
                {
                    Id = "23ba1d27-0638-48ce-a968-d03d6dee5d41", 
                    FullName = "Chau Du",
                    Birthday = new DateTime(2001, 2, 1),
                    Address="Hue",
                    HospitalId = 1,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email="chaudu301@gmail.com",
                    NormalizedEmail="CHAUDU301@GMAIL.COM",
                    EmailConfirmed=true,
                    PasswordHash = hasher.HashPassword(null, "123456789"),
                    SecurityStamp = "AKMZLDVQDMJAX4AKBITZL5OOVZB6SHPN",
                    ConcurrencyStamp= "e26d8cb5-e3ce-4e0c-9588-ffd39ee998b1",
                    PhoneNumberConfirmed =false,
                    TwoFactorEnabled=false,
                    LockoutEnabled =true,
                    AccessFailedCount = 0
                }
            );
            

            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "0d4492c3-c15e-4986-bbd6-d6157c06dbe1",
                    UserId = "23ba1d27-0638-48ce-a968-d03d6dee5d41"
                }
            );


        }

    }
}
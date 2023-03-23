using Domain.Model.BloodRegister;
using Domain.Model.Posts;
using Domain.Model.Users;
using Domain.Model.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "0d4492c3-c15e-4986-bbd6-d6157c06dbe1", Name = "ADMIN", NormalizedName = "ADMIN".ToUpper() },
                new IdentityRole { Id = "3c84e231-ddb0-4794-8c48-3dbf4ed01d1c", Name = "USER", NormalizedName = "USER".ToUpper() },
                new IdentityRole { Id = "4f077375-71ce-4b2c-88cc-96d3fc60ecf5", Name = "STAFF", NormalizedName = "STAFF".ToUpper() },
                new IdentityRole { Id = "9fd9a17b-59d2-4e0d-996a-00014aba94d8", Name = "HOSPITAL", NormalizedName = "HOSPITAL".ToUpper() }
              );
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<Hospital>().HasData(
              new {Id=1,Name= "None",Address="None",Lat = "0",Long ="0",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now },
              new { Id = 2, Name = "Bệnh viện Trung Ương Huế", Address = "16 Lê Lợi, Vĩnh Ninh, Thành phố Huế, Thừa Thiên Huế, Việt Nam",Lat= "16.462613301814663", Long = "107.58851619580426", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
             );
            modelBuilder.Entity<Image>().HasData(
                new { Id = 1, FileName = "banner.jpg", ContentType = "image/jpeg", Url = "/uploads/posts/Post-21262023220332-banner.jpg" },
                new { Id = 2, FileName = "tieu-su-ca-si-lisa-blackpink-3.jpeg", ContentType = "image/jpeg", Url = "/uploads/posts/Post-21242023220345-tieu-su-ca-si-lisa-blackpink-3.jpeg" }
                );
            modelBuilder.Entity<Blog>().HasData(
                new { Id = 1, Title = "Lợi ích việc hiến máu", Description = "Chúng ta nên chia sẻ và cho đi", Content = "Hiến máu chủ yếu là hiến hồng cầu. Máu gồm có huyết tương chiếm 55% thể tích máu và các tế bào máu chiếm 45% còn lại.", ImageId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                );
            modelBuilder.Entity<Event>().HasData(
                   new { Id = 1, EventName = "Hiến máu nhân đạo", Description = "Sinh viên các trường hiến máu", Content = "Yêu cầu trên 42kg, sức khỏe tốt", StartTime = new DateTime(2023, 3, 1), EndTime = new DateTime(2023, 3, 30), Status = EventStatus.Ongoing, ImageId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
              );
            modelBuilder.Entity<BloodGroup>().HasData(
                new { Id = 1, Name = "A", Description = "Nhóm máu A", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new { Id = 2, Name = "B", Description = "Nhóm máu B", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                );
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
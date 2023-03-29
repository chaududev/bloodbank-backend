using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class db_bloodbank_v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Long = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Charities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Situation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charities_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BloodId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TimeSign = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QR = table.Column<int>(type: "int", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    Ml = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registers_BloodGroups_BloodId",
                        column: x => x.BloodId,
                        principalTable: "BloodGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registers_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registers_Images_QR",
                        column: x => x.QR,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d4492c3-c15e-4986-bbd6-d6157c06dbe1", "9231a4db-246f-4e61-a7f6-1545d9bd462b", "ADMIN", "ADMIN" },
                    { "3c84e231-ddb0-4794-8c48-3dbf4ed01d1c", "f8ae1d73-4195-4212-b37a-ba8a438db39a", "USER", "USER" },
                    { "4f077375-71ce-4b2c-88cc-96d3fc60ecf5", "9ff28a0d-9c21-4f99-8be0-15d9c20aed74", "STAFF", "STAFF" },
                    { "9fd9a17b-59d2-4e0d-996a-00014aba94d8", "7ee7b0fa-46b5-4b73-9893-2f1ba0e1c6ad", "HOSPITAL", "HOSPITAL" }
                });

            migrationBuilder.InsertData(
                table: "BloodGroups",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3727), "Nhóm máu A", "A", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3728) },
                    { 2, new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3730), "Nhóm máu B", "B", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3731) },
                    { 3, new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3732), "Nhóm máu AB", "AB", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3733) },
                    { 4, new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3735), "Nhóm máu O", "O", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3735) }
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "CreatedAt", "Lat", "Long", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "None", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3502), "0", "0", "None", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3517) },
                    { 2, "16 Lê Lợi, Vĩnh Ninh, Thành phố Huế, Thừa Thiên Huế, Việt Nam", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3521), "16.462613301814663", "107.58851619580426", "Bệnh viện Trung Ương Huế", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3521) },
                    { 3, "3 Đ. Ngô Quyền, Vĩnh Ninh, Thành phố Huế, Thừa Thiên Huế, Việt Nam", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3523), "16.46068028180563", "107.58710131107946", "Bệnh Viện Quốc Tế Huế", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3523) }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ContentType", "FileName", "Url" },
                values: new object[,]
                {
                    { 1, "image/jpeg", "notfound.jpg", "/uploads/image/notfound.jpg" },
                    { 2, "image/jpeg", "pexels-cdc-3992933.jpg", "/uploads/posts/Post-29342023150316-pexels-cdc-3992933.jpg" },
                    { 3, "image/jpeg", "blog1.jpg", "/uploads/posts/Post-29322023150310-blog1.jpg" },
                    { 4, "image/jpeg", "blog3.jpg", "/uploads/posts/Post-29312023150312-blog3.jpg" },
                    { 5, "image/jpeg", "blog4.jpg", "/uploads/posts/Post-29282023150359-blog4.jpg" },
                    { 6, "image/jpeg", "blog2.jpg", "/uploads/posts/Post-29262023150355-blog2.jpg" },
                    { 7, "image/jpeg", "charity4.jpg", "/uploads/posts/Post-29242023150345-charity4.jpg" },
                    { 8, "image/jpeg", "charity1.jpg", "/uploads/posts/Post-29232023150313-charity1.jpg" },
                    { 9, "image/jpeg", "charity2.jpg", "/uploads/posts/Post-29182023150351-charity2.jpg" },
                    { 10, "image/jpeg", "event2.jpg", "/uploads/posts/Post-29162023150302-event2.jpg" },
                    { 11, "image/jpeg", "event4.jpg", "/uploads/posts/Post-29142023150311-event4.jpg" },
                    { 12, "image/jpeg", "event5.jpg", "/uploads/posts/Post-29112023150310-event5.jpg" },
                    { 13, "image/jpeg", "event3.jpg", "/uploads/posts/Post-29032023150344-event3.jpg" },
                    { 14, "image/jpeg", "event1.jpg", "/uploads/posts/Post-29582023140333-event1.jpg" },
                    { 15, "image/jpeg", "Qrcode-29462023100303.png", "/uploads/qrcode/Qrcode-29462023100303.png" },
                    { 16, "image/jpeg", "Qrcode-29452023100345.png", "/uploads/qrcode/Qrcode-29452023100345.png" },
                    { 17, "image/jpeg", "Qrcode-29352023100327.png", "/uploads/qrcode/Qrcode-29352023100327.png" },
                    { 18, "image/jpeg", "Qrcode-29342023100315.png", "/uploads/qrcode/Qrcode-29342023100315.png" },
                    { 19, "image/jpeg", "Qrcode-23202023200346.png", "/uploads/qrcode/Qrcode-23202023200346.png" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "HospitalId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23ba1d27-0638-48ce-a968-d03d6dee5d41", 0, "Hue", new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e26d8cb5-e3ce-4e0c-9588-ffd39ee998b1", "chaudu301@gmail.com", true, "Chau Du", 1, true, null, "CHAUDU301@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAENbuJS2LVaoQrKKFZWQha0JlUt9YtUcnwzjqIrMHx9ZRIJR8reaBOrcVWQY0u/6JBQ==", null, false, "AKMZLDVQDMJAX4AKBITZL5OOVZB6SHPN", false, "admin" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Content", "CreatedAt", "Description", "ImageId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "<p><span style=\"background-color: rgb(255, 255, 255); font-size: 17px; font-family: Inter; color: rgb(41, 41, 41);\">Chuyển khoản: Ban doc: 100.000 đồng; Ngo Thanh Ha: 100.000 đồng; ban doc: 200.000 đồng; ban doc: 150.000 đồng; Nguyen Quy Mai: 200.000 đồng; ban doc: 500.000 đồng; ban doc: 100.000 đồng; ban doc: 300.000 đồng; ban doc: 100.000 đồng; ban doc: 100.000 đồng; Nguyen Thi Minh Trang: 200.000 đồng; ban doc: 100.000 đồng; ban doc: 1.000.000 đồng; ban doc: 50.000 đồng; ban doc: 200.000 đồng; ban doc: 200.000 đồng; ban doc: 200.000 đồng; Ngo Tang Huyen Trang: 100.000 đồng; ban doc: 2.000.000 đồng; ban doc: 100.000 đồng; ban doc: 200.000 đồng; Pham Thi Anh Hoa: 3.000.000 đồng; ban doc: 100.000 đồng; ban doc: 500.000 đồng; ban doc: 200.000 đồng; ban doc: 300.000 đồng; ban doc: 200.000 đồng; ban doc: 500.000 đồng; ban doc: 2.000.000 đồng; ban doc: 20.000 đồng; Tran Ngoc Thanh: 1.000.000 đồng; Vo Thi Thanh Mai: 500.000 đồng; ban doc: 200.000 đồng; ban doc: 200.000 đồng; ban doc: 100.000 đồng; ban doc: 100.000 đồng; ban doc: 100.000 đồng; ban doc: 100.000 đồng; Vo An Chieu: 100.000 đồng; ban doc: 100.000 đồng; ban doc: 300.000 đồng; ban doc: 200.000 đồng; ban doc: 100.000 đồng; ban doc: 100.000 đồng; ban doc: 100.000 đồng; ban doc: 1.000.000 đồng; ban doc: 1.000.000 đồng; ban doc: 200.000 đồng; ban doc: 100.000 đồng; ban doc: 500.000 đồng; ban doc: 1.000.000 đồng; ban doc: 200.000 đồng; ban doc: 200.000 đồng; ban doc: 500.000 đồng; ban doc: 100.000 đồng; ban doc: 300.000 đồng; ban doc: 100.000 đồng; Vu Tuong Vy: 300.000 đồng; Phuoc: 500.000 đồng; ban doc: 200.000 đồng; Vu Thanh Thanh Huyen: 100.000 đồng; ban doc: 500.000 đồng; ban doc: 151.122 đồng; ban doc: 100.000 đồng; ban doc: 10.000 đồng; ban doc: 50.000 đồng; To Thi My Anh: 500.000 đồng; ban doc: 100.000 đồng; ban doc: 200.000 đồng; ban doc: 200.000 đồng; ban doc: 100.000 đồng; ban doc: 500.000 đồng; ban doc: 200.000 đồng; ban doc: 100.000 đồng; ban doc: 300.000 đồng; Le Luong Phi Long: 500.000 đồng; ban doc: 100.000 đồng; ban doc: 1.000.000 đồng; ban doc: 200.000 đồng; ban doc: 200.000 đồng; ban doc: 100.000 đồng; Bui Thi Kim Thoa: 50.000 đồng; ban doc: 200.000 đồng; ban doc: 100.000 đồng; ban doc: 200.000 đồng; ban doc: 100.000 đồng; ban doc: 100.000 đồng; ban doc: 1.000.000 đồng; Mr.Philvo: 500.000 đồng; ban doc: 500.000 đồng; Nguyen Kim Ngan: 500.000 đồng; ban doc: 1.000.000 đồng; ban doc: 200.000 đồng; ban doc: 200.000 đồng; Pham Thi Thu Nga: 200.000 đồng; ban doc: 200.000 đồng; ban doc: 500.000 đồng; ban doc: 100.000 đồng; ban doc: 100.000 đồng; ban doc: 3.000.000 đồng; ban doc: 100.000 đồng; Do Thi Thanh Tam: 200.000 đồng; Duong Hai Yen: 50.000 đồng; ban doc: 200.000 đồng; Dinh Thi Anh Tuyet: 200.000 đồng; Ngo Tra Giang: 200.000 đồng; ban doc: 150.000 đồng; ban doc: 100.000 đồng; ban doc: 200.000 đồng; ban doc: 200.000 đồng; ban doc: 500.000 đồng; ban doc: 200.000 đồng; Tran Chi Hao: 500.000 đồng; ban doc: 100.000 đồng; Tran Viet Phuong: 100.000 đồng; Nguyen Bui Hong Phuc: 200.000 đồng; ban doc: 50.000 đồng; ban doc: 200.000 đồng; Tuyen: 500.000 đồng; ban doc: 400.000 đồng; ban doc: 50.000 đồng; ban doc: 100.000 đồng; Nguyen Thi But: 500.000 đồng; ban doc: 200.000 đồng; ban doc: 200.000 đồng; Bui Thi Van: 197.000 đồng; ban doc: 60.000 đồng; ban doc: 100.000 đồng; ban doc: 500.000 đồng; Nhu: 300.000 đồng; Trang Tran: 500.000 đồng; ban doc: 300.000 đồng; ban doc: 1.000.000 đồng; ban doc: 200.000 đồng; ban doc: 500.000 đồng; ban doc: 100.000 đồng; ban doc: 100.000 đồng; Le Truong Son: 1.000.000 đồng; Bui Huynh Phuoc: 500.000 đồng; ban doc: 2.000.000 đồng;</span></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3609), "Chúng ta nên chia sẻ và cho đi", 6, "Những gương mặt vàng trong làng hiến máu", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3610) },
                    { 2, "<h2 style=\"text-align: left;\"><span style=\"background-color: rgb(255, 255, 255); font-size: 1.5rem; font-family: &quot;Google Sans&quot;, &quot;Google Sans Text&quot;, Roboto, sans-serif; color: rgb(31, 31, 31);\">Cách cập nhật ứng dụng Android</span></h2><ol><li style=\"text-align: left;\"><span style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">Mở ứng dụng Cửa hàng Google Play <img src=\"https://storage.googleapis.com/support-kms-prod/OLcEYVL0fFBX9EyZw2qzUbxOa3qfXAfh85gx\" alt=\"Google Play\" width=\"18\" height=\"18\">.</span></li><li style=\"text-align: left;\">Ở trên cùng bên phải, hãy nhấn vào biểu tượng hồ sơ.</li><li style=\"text-align: left;\">Nhấn vào <strong style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">Quản lý ứng dụng và thiết bị</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">. Ứng dụng có bản cập nhật sẽ được gắn nhãn &quot;Đã có bản cập nhật&quot;.</span></li><li style=\"text-align: left;\">Nhấn vào <strong style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">Cập nhật</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">.</span></li></ol><h2 style=\"text-align: left;\"><span style=\"background-color: rgb(255, 255, 255); font-size: 1.5rem; font-family: &quot;Google Sans&quot;, &quot;Google Sans Text&quot;, Roboto, sans-serif; color: rgb(31, 31, 31);\">Cách cập nhật Cửa hàng Google Play</span></h2><ol><li style=\"text-align: left;\"><span style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">Mở ứng dụng Cửa hàng Google Play <img src=\"https://storage.googleapis.com/support-kms-prod/OLcEYVL0fFBX9EyZw2qzUbxOa3qfXAfh85gx\" alt=\"Google Play\" width=\"18\" height=\"18\">.</span></li><li style=\"text-align: left;\">Ở trên cùng bên phải, hãy nhấn vào biểu tượng hồ sơ.</li><li style=\"text-align: left;\">Nhấn vào <strong style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">Cài đặt</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\"> <img src=\"https://lh3.googleusercontent.com/3_l97rr0GvhSP2XV5OoCkV2ZDTIisAOczrSdzNCBxhIKWrjXjHucxNwocghoUa39gw=w36-h36\" alt=\"sau đó\" width=\"18\" height=\"18\"> </span><strong style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">Giới thiệu</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\"> <img src=\"https://lh3.googleusercontent.com/3_l97rr0GvhSP2XV5OoCkV2ZDTIisAOczrSdzNCBxhIKWrjXjHucxNwocghoUa39gw=w36-h36\" alt=\"sau đó\" width=\"18\" height=\"18\"> </span><strong style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">Phiên bản Cửa hàng Play</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">.</span></li><li style=\"text-align: left;\">Bạn sẽ nhận được thông báo cho biết Cửa hàng Play đã được cập nhật hay chưa. Nhấn <strong style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">OK</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">.</span><ul><li style=\"text-align: left;\"><span style=\"background-color: rgb(255, 255, 255); font-size: 16px; font-family: &quot;Google Sans Text&quot;, Roboto, &quot;Helvetica Neue&quot;, Helvetica, sans-serif; color: rgb(31, 31, 31);\">Nếu có bản cập nhật thì nó sẽ được tự động tải xuống và cài đặt sau vài phút.</span></li></ul></li></ol><p><br></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3612), "Bạn có thể tự động cập nhật trên CHPlay hoặc Appstore", 5, "Cập nhật chức năng mới của app", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3613) },
                    { 3, "<p><strong style=\"background-color: rgb(255, 255, 255); font-size: 14px; font-family: sans-serif; color: rgb(32, 33, 34);\">Bệnh lây truyền qua đường máu</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 14px; font-family: sans-serif; color: rgb(32, 33, 34);\"> là căn bệnh có thể lây lan qua ô nhiễm bởi máu và các chất dịch cơ thể khác. Mầm bệnh lây truyền qua đường máu là các vi sinh vật như virus hoặc vi khuẩn. Các ví dụ phổ biến nhất là </span><a href=\"https://vi.wikipedia.org/wiki/HIV\" rel=\"noopener noreferrer\" style=\"background-color: initial; font-size: 14px; font-family: sans-serif; color: rgb(51, 102, 204);\">HIV</a><span style=\"background-color: rgb(255, 255, 255); font-size: 14px; font-family: sans-serif; color: rgb(32, 33, 34);\">, </span><a href=\"https://vi.wikipedia.org/wiki/Vi%C3%AAm_gan_B\" rel=\"noopener noreferrer\" style=\"background-color: initial; font-size: 14px; font-family: sans-serif; color: rgb(51, 102, 204);\">viêm gan B</a><span style=\"background-color: rgb(255, 255, 255); font-size: 14px; font-family: sans-serif; color: rgb(32, 33, 34);\"> (HVB), </span><a href=\"https://vi.wikipedia.org/wiki/Vi%C3%AAm_gan_C\" rel=\"noopener noreferrer\" style=\"background-color: initial; font-size: 14px; font-family: sans-serif; color: rgb(51, 102, 204);\">viêm gan C</a><span style=\"background-color: rgb(255, 255, 255); font-size: 14px; font-family: sans-serif; color: rgb(32, 33, 34);\"> (HVC) và </span><a href=\"https://vi.wikipedia.org/wiki/S%E1%BB%91t_xu%E1%BA%A5t_huy%E1%BA%BFt\" rel=\"noopener noreferrer\" style=\"background-color: initial; font-size: 14px; font-family: sans-serif; color: rgb(51, 102, 204);\">sốt xuất huyết</a><span style=\"background-color: rgb(255, 255, 255); font-size: 14px; font-family: sans-serif; color: rgb(32, 33, 34);\"> do virus.</span></p><p><span style=\"background-color: rgb(255, 255, 255); color: rgb(32, 33, 34);\">Các bệnh thường không lây truyền trực tiếp qua tiếp xúc với máu, mà là do côn trùng hoặc vec tơ khác, được phân loại hữu ích hơn là bệnh truyền qua vector, mặc dù tác nhân gây bệnh có thể được tìm thấy trong máu. Các bệnh do vector gây ra bao gồm </span><a href=\"https://vi.wikipedia.org/wiki/Virus_T%C3%A2y_s%C3%B4ng_Nin\" rel=\"noopener noreferrer\" style=\"background-color: initial; color: rgb(51, 102, 204); font-size: 14px; font-family: sans-serif;\">virus Tây sông Nin</a><span style=\"background-color: rgb(255, 255, 255); color: rgb(32, 33, 34); font-size: 14px; font-family: sans-serif;\">, </span><a href=\"https://vi.wikipedia.org/w/index.php?title=S%E1%BB%91t_zika&amp;action=edit&amp;redlink=1\" rel=\"noopener noreferrer\" style=\"background-color: initial; color: rgb(221, 51, 51); font-size: 14px; font-family: sans-serif;\">sốt zika</a><span style=\"background-color: rgb(255, 255, 255); color: rgb(32, 33, 34); font-size: 14px; font-family: sans-serif;\"> và </span><a href=\"https://vi.wikipedia.org/wiki/S%E1%BB%91t_r%C3%A9t\" rel=\"noopener noreferrer\" style=\"background-color: initial; color: rgb(51, 102, 204); font-size: 14px; font-family: sans-serif;\">sốt rét</a><span style=\"background-color: rgb(255, 255, 255); color: rgb(32, 33, 34); font-size: 14px; font-family: sans-serif;\">. Nhiều bệnh lây truyền qua đường máu cũng có thể được ký hợp đồng bằng các biện pháp khác, bao gồm hành vi tình dục có nguy cơ cao hoặc sử dụng thuốc tiêm tĩnh mạch. Những bệnh này cũng đã được xác định trong y học thể thao. Vì rất khó xác định mầm bệnh nào trong bất kỳ mẫu máu nào có chứa, và một số bệnh truyền qua đường máu gây tử vong, thực hành y tế tiêu chuẩn coi tất cả máu (và bất kỳ chất lỏng nào trong cơ thể) đều có khả năng lây nhiễm. Các biện pháp phòng ngừa máu và dịch cơ thể là một loại thực hành kiểm soát nhiễm trùng nhằm tìm cách giảm thiểu loại lây truyền bệnh này.</span></p><p><br></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3614), "Nhiều bệnh truyền nhiễm lây qua đường máu", 4, "Đừng xem thường việc đứt tay", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3615) },
                    { 4, "<p><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">Sức khỏe là vốn quý nhất của mỗi người, chỉ khi có sức khỏe con người mới có thể học tập, làm việc, vui chơi, sống vui vẻ và có ích. </span><strong style=\"background-color: transparent; font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166);\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/tai-sao-nen-kham-suc-khoe-dinh-ky/\" rel=\"noopener noreferrer\">Khám sức khỏe định kỳ</a></strong><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\"> có ý nghĩa vô cùng quan trọng, thể hiện trách nhiệm của mỗi người đối với sức khỏe bản thân. Phòng bệnh bao giờ cũng hiệu quả, nhẹ nhàng hơn chữa bệnh. Một người trông có vẻ ngoài khỏe mạnh nhưng có thể tiềm ẩn nhiều nguy cơ bệnh tật. Có những bệnh lý nghiêm trọng đôi khi phát hiện tình cờ khi </span><strong style=\"background-color: transparent; font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166);\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/sieu-am-la-gi-nhung-dieu-can-biet-ve-sieu-am/\" rel=\"noopener noreferrer\">siêu âm</a></strong><strong style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">,</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\"> </span><strong style=\"background-color: transparent; font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166);\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/chup-x-quang-la-gi-tat-ca-nhung-dieu-can-biet/\" rel=\"noopener noreferrer\">chụp phim X-quang</a></strong><strong style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">,..</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">. khi khám sức khỏe mặc dù người bệnh không hề có triệu chứng gì. Nếu các bệnh lý nghiêm trọng không được phát hiện sớm, khi phát hiện đã ở mức độ nặng thì việc điều trị sẽ vô cùng khó khăn, tốn kém và ảnh hưởng nghiêm trọng đến chất lượng cuộc sống.</span></p><p>Theo đó, việc khám sức khỏe định kỳ giúp mỗi người hiểu rõ tình trạng sức khỏe của bản thân, bởi khi đi khám sức khỏe, bạn sẽ được kiểm tra sức khỏe một cách toàn diện thông qua khám tổng quát, khám chuyên khoa, thực hiện các xét nghiệm và các kỹ thuật <strong style=\"font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166); background-color: transparent;\"><a href=\"https://www.vinmec.com/vi/tin-tuc/hoat-dong-benh-vien/cap-nhat-cong-nghe-moi-nhat-ve-chan-doan-hinh-anh/\" rel=\"noopener noreferrer\">chẩn đoán hình ảnh</a></strong><span style=\"font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51); background-color: rgb(255, 255, 255);\"> như chụp X-quang, siêu âm, </span><strong style=\"font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166); background-color: transparent;\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/chup-ct-la-gi-truong-hop-nao-can-tiem-thuoc-can-quang/\" rel=\"noopener noreferrer\">CT</a></strong><span style=\"font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51); background-color: rgb(255, 255, 255);\">... Thông qua kết quả khám, các bác sĩ không những giúp đánh giá tình trạng sức khỏe hiện tại mà còn giúp dự đoán các yếu tố nguy cơ có thể gây bệnh trong tương lai.</span></p><p><br></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3617), "Sức khỏe là vốn quý nhất của mỗi người", 3, "Khám sức khỏe định kỳ 6 tháng", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3618) },
                    { 5, "<p><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">Tùy vào độ tuổi khi đến khám, ngoài các nội dung khám tổng quát và xét nghiệm sàng lọc, khám sức khỏe định kỳ còn thực hiện các dịch vụ khám và xét nghiệm chuyên biệt liên quan đến nguy cơ mắc bệnh tương ứng với lứa tuổi, cụ thể như:</span></p><ul><li><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">Ở độ tuổi 18-30, khám và xét nghiệm tập trung vào các bệnh truyền nhiễm có nguy cơ cao như </span><strong style=\"background-color: transparent; font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166);\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/viem-gan-b-la-gi-cach-phong-tranh-benh-hieu-qua/\" rel=\"noopener noreferrer\">viêm gan B</a></strong><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">, </span><strong style=\"background-color: transparent; font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166);\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/lam-nao-khi-da-mac-virus-viem-gan-c/\" rel=\"noopener noreferrer\">viêm gan C</a></strong><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">, bệnh lây qua đường tình dục như </span><strong style=\"background-color: transparent; font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166);\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/benh-lau-nguyen-nhan-duong-lay-dau-hieu-nhan-biet/\" rel=\"noopener noreferrer\">lậu</a></strong><strong style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">,</strong><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\"> </span><strong style=\"background-color: transparent; font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166);\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/benh-giang-mai-nguyen-nhan-duong-lay-dau-hieu-nhan-biet/\" rel=\"noopener noreferrer\">giang mai</a></strong><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">; khám kiểm tra sức khỏe sinh sản, </span><strong style=\"background-color: transparent; font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(0, 102, 166);\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/san-phu-khoa-va-ho-tro-sinh-san/tai-sao-ban-can-kham-suc-khoe-tien-hon-nhan/\" rel=\"noopener noreferrer\">sức khỏe tiền hôn nhân</a></strong><span style=\"background-color: rgb(255, 255, 255); font-size: 15px; font-family: Helvetica, Arial, san-serif; color: rgb(51, 51, 51);\">.</span></li><li><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51);\">Ở tuổi 30-40, tập trung tầm soát các bệnh lý có thể xuất hiện sớm ở độ tuổi này như bệnh tim mạch, </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/dau-hieu-som-bao-hieu-benh-tieu-duong/\" rel=\"noopener noreferrer\">đái tháo đường</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\">, </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/dau-hieu-nhan-biet-ban-bi-roi-loan-lipid-mau/\" rel=\"noopener noreferrer\">rối loạn lipid máu</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\">, </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/bien-chung-nguy-hiem-cua-benh-gout/\" rel=\"noopener noreferrer\">gout</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\">,... Ở phụ nữ, sẽ được </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/goi-dich-vu/sang-loc-ung-thu/goi-tam-soat-va-phat-hien-som-ung-thu-phu-khoa/\" rel=\"noopener noreferrer\">tầm soát ung thư phụ khoa</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\">.</span></li><li><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51);\">Ở tuổi trung niên, khám tầm soát các bệnh lý tim mạch, đái tháo đường, </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/benh/tang-huyet-ap-3089/\" rel=\"noopener noreferrer\">tăng huyết áp</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\">, xương khớp,... và tầm soát các bệnh lý ung thư phổ biến như </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/benh/ung-thu-gan-3043/\" rel=\"noopener noreferrer\">ung thư gan</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\">, </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/dau-hieu-nhan-biet-ung-thu-da-day-giai-doan-dau/\" rel=\"noopener noreferrer\">ung thư dạ dày</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\">, </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/ung-buou-xa-tri/ung-thu-vom-hong-giai-doan-dau-dau-hieu-chan-doan-dieu-tri/?link_type=related_posts\" rel=\"noopener noreferrer\">ung thư vòm họng</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\">, </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/benh/ung-thu-phoi-3039/\" rel=\"noopener noreferrer\">ung thư phổi</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\">, </span><strong style=\"background-color: transparent; color: rgb(0, 102, 166); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"><a href=\"https://www.vinmec.com/vi/tin-tuc/thong-tin-suc-khoe/benh-ung-thu-tuyen-tien-liet-co-chua-duoc-khong/?link_type=related_posts\" rel=\"noopener noreferrer\">ung thư tuyến tiền liệt</a></strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); font-size: 15px; font-family: Helvetica, Arial, san-serif;\"> ở nam giới...</span></li></ul><p><br></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3619), "Các chuyên gia y tế khuyến cáo mọi người nên thực hiện khám sức khỏe định kỳ đều đặn", 2, "Các loại bệnh phổ biến năm nay", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3620) }
                });

            migrationBuilder.InsertData(
                table: "Charities",
                columns: new[] { "Id", "Content", "CreatedAt", "ImageId", "Money", "Name", "Situation", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "<p>Ông Nguyễn Văn Đan hiện đang hôn mê nằm ở bệnh viện Quốc tế Huế, đang cần nhóm máu Rh+</p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3695), 9, 10000000, "Nguyễn Văn Đan", "Ông Đan hiện đang hôn mê nằm ở bệnh viện Quốc tế Huế, đang cần nhóm máu Rh+", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3696) },
                    { 2, "<p>Hiện gia đình cô không có khả năng tiếp tục liệu trình điều trị</p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3698), 8, 10000000, "Phan Thu Sương", "Cô Sương bị bệnh ung thư não", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3699) },
                    { 3, "<p>Gia đình khó khăn, không có khả năng điều trị cứu chữa cho cậu bé</p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3700), 7, 10000000, "Nguyễn Xuân Đoan", "Cháu Đoan (2010) hiện bị xuất huyết não", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3701) }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Content", "CreatedAt", "Description", "EndTime", "EventName", "ImageId", "StartTime", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "<p style=\"text-align: justify;\"><span style=\"background-color: rgb(255, 255, 255); font-family: Sans, Helvetica, tahoma, sans-serif; color: rgb(33, 37, 41); font-size: 16px;\">Được diễn ra trong 2 ngày 3 – 4/12 tại Bảo tàng Hà Nội, ngày hội hiến máu mong muốn truyền đi thông điệp “Chung tay hiến máu cứu người”. Đây đã trở thành nơi gặp gỡ, giao lưu và tôn vinh những người làm công tác tình nguyện.</span></p><p style=\"text-align: justify;\"><span style=\"background-color: rgb(255, 255, 255); font-family: Sans, Helvetica, tahoma, sans-serif; color: rgb(33, 37, 41); font-size: 16px;\">Phát biểu tại chương trình, PGS.TS Nguyễn Hà Thanh, Viện trưởng Viện Huyết học – Truyền máu Trung ương cho biết: Ngày hội hiến máu “Trái tim tình nguyện” hôm nay là sự kiện lớn đầu tiên mở đầu cho chuỗi các sự kiện hiến máu lớn dịp trước và sau Tết Nguyên đán 2023. Viện Huyết học – Truyền máu Trung ương đánh giá rất cao ý tưởng tổ chức ngày hội hiến máu “Trái tim tình nguyện” của Hội Thanh niên vận động hiến máu Hà Nội.</span></p><p><br></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3651), "Ngày hội hiến máu Trái tim tình nguyện: Cho đi giọt máu là cho đi niềm hi vọng sống", new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hiến máu nhân đạo tháng 3", 10, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3652) },
                    { 2, "<p><strong style=\"background-color: rgb(255, 255, 255); font-family: Sans, Helvetica, tahoma, sans-serif; color: rgb(33, 37, 41); font-size: 16px;\"><em>“Có rất nhiều cách để chia sẻ, cống hiến cho cộng đồng nhưng tôi nghĩ hiến máu là một việc làm rất ý nghĩa, bởi cho đi những giọt máu của mình là cho đi sự sống, cho đi niềm hi vọng đối với một ai đó, điều này vô cùng thiêng liêng và cao cả”</em>, nữ sinh Nguyễn Thị Thu Hiền, trường Cao đẳng Y tế Hà Nội chia sẻ.</strong></p><p><span style=\"background-color: rgb(255, 255, 255); font-family: Sans, Helvetica, tahoma, sans-serif; color: rgb(33, 37, 41); font-size: 16px;\">Hưởng ứng các hoạt động kỷ niệm Ngày Quốc tế tình nguyện 5/12, hôm nay 4/12, Viện Huyết học – Truyền máu Trung ương phối hợp với Trung tâm Tình nguyện Quốc gia, Hội Liên hiệp Thanh niên Việt Nam Thành phố Hà Nội, Hội Thanh niên vận động hiến máu Hà Nội và các đơn vị tổ chức ngày hội hiến máu “Trái tim tình nguyện” năm 2022.</span></p><p><span style=\"background-color: rgb(255, 255, 255); font-family: Sans, Helvetica, tahoma, sans-serif; color: rgb(33, 37, 41); font-size: 16px;\">Tham dự chương trình có PGS.TS Nguyễn Hà Thanh, Viện trưởng Viện Huyết học – Truyền máu Trung ương; TS Trần Ngọc Quế, Giám đốc Trung tâm Máu Quốc gia, Viện Huyết học – Truyền máu Trung ương; Bà Đỗ Thị Kim Hoa, Giám đốc Trung tâm Tình nguyện Quốc gia; Ông Nguyễn Đức Tiến, Phó Bí thư Thường trực Thành đoàn, Chủ tịch Hội Liên hiệp Thanh niên Việt Nam Thành phố Hà Nội cùng đại diện các cơ quan đơn vị liên quan.</span></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3654), "Sáng 22/11, tại Hà Nội, Trung ương Hội Chữ thập đỏ Việt Nam tổ chức Ngày hội hiến máu nhân đạo", new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngày hội hiến máu “Trái tim tình nguyện”", 11, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3655) },
                    { 3, "<p style=\"text-align: justify;\"><span style=\"background-color: rgb(255, 255, 255); font-family: Sans, Helvetica, tahoma, sans-serif; color: rgb(33, 37, 41); font-size: 16px;\">Được diễn ra trong 2 ngày 3 – 4/12 tại Bảo tàng Hà Nội, ngày hội hiến máu mong muốn truyền đi thông điệp “Chung tay hiến máu cứu người”. Đây đã trở thành nơi gặp gỡ, giao lưu và tôn vinh những người làm công tác tình nguyện.</span></p><p style=\"text-align: justify;\"><span style=\"background-color: rgb(255, 255, 255); font-family: Sans, Helvetica, tahoma, sans-serif; color: rgb(33, 37, 41); font-size: 16px;\">Phát biểu tại chương trình, PGS.TS Nguyễn Hà Thanh, Viện trưởng Viện Huyết học – Truyền máu Trung ương cho biết: Ngày hội hiến máu “Trái tim tình nguyện” hôm nay là sự kiện lớn đầu tiên mở đầu cho chuỗi các sự kiện hiến máu lớn dịp trước và sau Tết Nguyên đán 2023. Viện Huyết học – Truyền máu Trung ương đánh giá rất cao ý tưởng tổ chức ngày hội hiến máu “Trái tim tình nguyện” của Hội Thanh niên vận động hiến máu Hà Nội.</span></p><p><br></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3657), "Mỗi giọt máu hiến tặng góp phần thể hiện tinh thần tương thân, tương ái trong cộng đồng", new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngày hội hiến máu nhân đạo", 12, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3658) },
                    { 4, "<p><span style=\"background-color: rgb(255, 255, 255); font-size: 14px; font-family: Roboto, Arial, Helvetica, sans-serif; color: rgb(0, 0, 0);\">Máu rất cần thiết cho việc cấp cứu ngoại khoa, cấp cứu các trường hợp tai nạn giao thông, dùng điều trị đối với các bệnh về máu, cấp cứu nạn nhân trong các thảm họa, thiên tai…. Thông qua việc hiến máu giúp cho người bệnh cần máu điều trị tại các bệnh viện, nhiều người đã được cứu sống trở về với gia đình, người thân, bạn bè. Hiến máu cứu người là nghĩa cử cao đẹp, là nghĩa vụ thiêng liêng và trách nhiệm của mỗi người, thể hiện giá trị đạo đức tinh thần của người hiến máu “Mình vì mọi người”, “Tương thân tương ái” và thực hiện theo lời căn dặn của Chủ tịch Hồ Chí Minh “ Phải xuất phát từ tình thương yêu Nhân dân tha thiết mà góp phần bảo vệ sức khỏe của Nhân dân và làm mọi việc có thể làm được để giảm bớt đau thương cho họ” Với ý nghĩa đó: Để Ngày hội hiến máu diễn ra an toàn, hiệu quả, Ban Chỉ đạo vận động HMTN huyện Ngọc Lặc đã tích cực đẩy mạnh công tác vận động, tuyên truyền về hiến máu nhân đạo bằng nhiều hình thức; đồng thời, triển khai Kế hoạch tổ chức hiến máu tình nguyện đến từng xã, thị trấn, cơ quan, đơn vị trên địa bàn huyện.</span></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3660), "Ngày hội hiến máu Trái tim tình nguyện: Cho đi giọt máu là cho đi niềm hi vọng sống", new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngày hội hiến máu tình nguyện tháng 4", 13, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3661) },
                    { 5, "<p><strong style=\"background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-size: 14px; font-family: inherit;\">Hơn 1000 đơn vị máu được hiến tặng chỉ trong 2 buổi sáng Ngày hội hiến máu tình nguyện “GỬI TRAO NGUỒN SỐNG, VIẾT TIẾP THANH XUÂN</strong><span style=\"background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-size: 14px; font-family: Arial;\">”</span><strong style=\"background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-size: 14px; font-family: inherit;\">tại trường Đại học Mở TP. HCM diễn ra vào ngày 29 và 30 tháng 6.</strong></p><p><span style=\"background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-size: 14px; font-family: Arial;\">Vào sáng ngày 29 và 30 tháng 6/2019 tại trường Đại học Mở Thành phố Hồ Chí Minh, 371 Nguyễn Kiệm, Gò Vấp đã diễn Ngày hội hiến máu tình nguyện “GỬI TRAO NGUỒN SỐNG, VIẾT TIẾP THANH XUÂN”, do Đội tuyên truyền hiến máu tình nguyện Đại học Mở Thành phố Hồ Chí Minh kết hợp cùng Bệnh viên Truyền Máu Huyết Học tổ chức. Qua 2 ngày hội, sự kiện trên đã thu hút 715 người tham gia hiến máu với hơn 1000 đơn vị máu được bệnh viện tiếp nhận.</span></p><p><span style=\"background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-size: 14px; font-family: Arial;\">Ngay từ sáng sớm đã có nhiều bạn sinh viên đến để được hiến máu. Không chỉ có các bạn sinh viên trường Đại học Mở mà còn có các anh chị cựu sinh viên, cán bộ công nhân viên nhà trường và cả những bạn sinh viên trường khác cũng đến tham dự.</span></p><p><span style=\"background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-size: 14px; font-family: Arial;\">Không khí ngày hội luôn vui tươi và đầy sức sống cho đến tận lúc kết thúc. Từ người đi hiến, các y bác sĩ đến các thành viên đội Máu hỗ trợ trong ngày hội, ai cũng giữ nụ cười tươi tắn trên môi.</span></p><p><br></p>", new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3663), "Có thể nói, năm học 2018-2019 là năm học thành công của Đội tuyên truyền hiến máu tình nguyện", new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gửi trao nguồn sống, viết tiếp thanh xuân", 14, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 3, 29, 16, 12, 45, 768, DateTimeKind.Local).AddTicks(3663) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d4492c3-c15e-4986-bbd6-d6157c06dbe1", "23ba1d27-0638-48ce-a968-d03d6dee5d41" });

            migrationBuilder.InsertData(
                table: "Registers",
                columns: new[] { "Id", "BloodId", "CreatedAt", "HospitalId", "Ml", "Note", "QR", "Status", "TimeSign", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6660), 2, 200, "None", 15, 4, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6646), new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6661), "23ba1d27-0638-48ce-a968-d03d6dee5d41" },
                    { 2, 2, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6663), 3, 200, "None", 16, 4, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6662), new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6664), "23ba1d27-0638-48ce-a968-d03d6dee5d41" },
                    { 3, 3, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6666), 2, 200, "None", 17, 4, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6665), new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6667), "23ba1d27-0638-48ce-a968-d03d6dee5d41" },
                    { 4, 4, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6669), 3, 200, "None", 18, 4, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6669), new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6670), "23ba1d27-0638-48ce-a968-d03d6dee5d41" },
                    { 5, 2, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6672), 2, 200, "None", 19, 4, new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6671), new DateTime(2023, 3, 29, 16, 12, 45, 784, DateTimeKind.Local).AddTicks(6673), "23ba1d27-0638-48ce-a968-d03d6dee5d41" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HospitalId",
                table: "AspNetUsers",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ImageId",
                table: "Blogs",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Charities_ImageId",
                table: "Charities",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ImageId",
                table: "Events",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registers_BloodId",
                table: "Registers",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Registers_HospitalId",
                table: "Registers",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Registers_QR",
                table: "Registers",
                column: "QR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registers_UserId",
                table: "Registers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Charities");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BloodGroups");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}

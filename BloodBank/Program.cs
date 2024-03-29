
using Application.IService;
using Application.Service;
using Domain.Model.Users;
using Infrastructure.Data;
using Infrastructure.IRepository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MemoryBufferThreshold = Int32.MaxValue;
    options.ValueLengthLimit = Int32.MaxValue;
    options.MultipartBodyLengthLimit = Int64.MaxValue;
});

builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = Int64.MaxValue;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
              .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
              {
                  options.LoginPath = "/Auth";
                  options.LogoutPath = "/Auth/logout";
                  options.AccessDeniedPath = "/";
              });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Roles", policy =>
    {
        policy.RequireRole("HOSPITAL","STAFF","ADMIN");
    });
    options.AddPolicy("AllRoles", policy =>
    {
        policy.RequireRole("USER","HOSPITAL", "STAFF", "ADMIN");
    });
});
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IBloodGroupService, BloodGroupService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IBlogService,BlogService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IHospitalService,HospitalService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<ICharityService, CharityService>();
builder.Services.AddTransient<IChartService, ChartService>();
builder.Services.AddTransient<IChartRepository, ChartRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

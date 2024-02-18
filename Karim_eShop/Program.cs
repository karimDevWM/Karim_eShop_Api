using api.Karim_eshop.Business.Service.Email.Models;
using api.Karim_eshop.Business.Service.Email.Services;
using api.Karim_eshop.Common.Middleware;
using api.Karim_eshop.Data.Entity;
using api.Karim_eshop.Data.Entity.Model;
using api.Karim_eshop.IoC.Application;
using api.Karim_eshop.IoC.Tests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

if(builder.Environment.IsEnvironment("Test"))
{
    // Configure Database connection
    builder.Services.ConfigureDBContextTest();

    //Dependency Injection
    builder.Services.ConfigureInjectionDependencyRepositoryTest();

    builder.Services.ConfigureInjectionDependencyServiceTest();
}
else
{
    // Configure Database connexion
    builder.Services.ConfigureDBContext(configuration);

    //Dependency Injection
    builder.Services.ConfigureInjectionDependencyRepository();

    builder.Services.ConfigureInjectionDependencyService();
}



//// configure Authentication
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//        {
//            options.Audience = "karim_eshop-api";
//            options.Authority = "http://localhost:8010/";
//        }
//    );

// For Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<KarimeshopDbContext>()
    .AddDefaultTokenProviders();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.

builder.Services.Configure<IdentityOptions>(
    options => options.SignIn.RequireConfirmedEmail = true
);

// for forgot password
builder.Services.Configure<DataProtectionTokenProviderOptions>(
    opts => opts.TokenLifespan = TimeSpan.FromHours(10)
);

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
}
);

// Add Email Configs
var emailConfig = configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen
(
    option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[] {}
            }
        });
    }
);
// Configure HTTPS redirection with the HTTPS port
//builder.Services.AddHttpsRedirection(options =>
//{
//    options.HttpsPort = 443; // Specify your HTTPS port here
//});

//add cors
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.AllowAnyOrigin()
//                          .AllowAnyHeader()
//                          .AllowAnyMethod();
//                      });
//});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    });
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});

//app.UseCors(builder => builder
//    .SetPreflightMaxAge(TimeSpan.FromMinutes(10))
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//);

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }

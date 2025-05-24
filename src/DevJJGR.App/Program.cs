using System.Data;
using Donouts.Application.Behaviors;
using Donouts.Domain.Entities;
using Donouts.Infrastructure;
using Donouts.Persistance;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Data.SqlClient;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddMediatR(Donouts.Application.AssemblyReference.Assembly);

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(Donouts.Application.AssemblyReference.Assembly,
    includeInternalTypes: true);


builder.Services.AddCors(x => x.AddPolicy("Policy", x =>
{
    x.WithOrigins(
      builder.Configuration.GetValue<string>("endpoints:webapp")!,
      builder.Configuration.GetValue<string>("endpoints:webapp2")!,
      builder.Configuration.GetValue<string>("endpoints:webapp3")!
     )
     .AllowAnyHeader()
     .AllowAnyMethod();
}));


string connectionString = builder.Configuration.GetConnectionString("Database")!;


// Register IDbConnection
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    connectionString,
    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName).EnableRetryOnFailure())).AddHealthChecks();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
builder
    .Services
    .AddControllers()
.AddApplicationPart(Donouts.Presentation.AssemblyReference.Assembly);

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Donnuts webApi", Version = "V1" }); });
builder.Services.AddMvc();

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddSignalR(hubOptions =>
{
    hubOptions.EnableDetailedErrors = true;
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWTKey:ValidAudience"],
        ValidIssuer = builder.Configuration["JWTKey:ValidIssuer"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTKey:Secret"]!))
    };
});
builder.Services.AddHealthChecks().AddSqlServer(connectionString);
WebApplication app = builder.Build();
app.MapHealthChecks("/health");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Policy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{version}/[controller]");
app.Run();

public partial class Program
{
    
}
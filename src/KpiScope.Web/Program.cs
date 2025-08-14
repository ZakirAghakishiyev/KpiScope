using KpiScope.Infrastructure.Configuration;
using KpiScope.Infrastructure.Data;
using KpiScope.UseCases.Contributors.Create;
using KpiScope.Web.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KpiScope.Web.Login;
using KpiScope.Web;
using AutoWrapper;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate:
    "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File(
        path: "Logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 7,
        fileSizeLimitBytes: 10_000_000,
        rollOnFileSizeLimit: true,
        shared: true,
        flushToDiskInterval: TimeSpan.FromSeconds(1))
    .CreateLogger();

Log.Logger = logger;
builder.Host.UseSerilog(logger);
var loggerFactory = new SerilogLoggerFactory(Log.Logger);
var appLogger = loggerFactory.CreateLogger<Program>();

builder.Services.AddAutoMapper(_ => { }, typeof(Automapper).Assembly);

logger.Information("Starting web host");
    
builder.Services.Configure<MySecretsOptions>(
    builder.Configuration.GetSection("MySecrets"));
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("JwtSettings"));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.AddLoggerConfigs();
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        opt.JsonSerializerOptions.WriteIndented = true;
    });;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("Connection string: " + builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{    
    options.UseSqlServer(connectionString);
});
builder.Services.AddOptionConfigs(builder.Configuration, appLogger, builder);
builder.Services.AddServiceConfigs(appLogger, builder);
builder.Services.AddFastEndpoints()
                .SwaggerDocument(o =>
                {
                  o.ShortSchemaNames = true;
                })
                .AddCommandMiddleware(c =>
                {
                  c.Register(typeof(CommandLogger<,>));
                });

builder.Services.AddScoped<JwtTokenService>();
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterModule(new OrderAppModule());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "OrderApp",
        ValidAudience = "Users",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKeyForJwtTokenGeneration123456"))
    };
});
builder.AddServiceDefaults();

var app = builder.Build();

await app.UseAppMiddlewareAndSeedDatabase();
using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        // await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
    }
app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
{
    ShowStatusCode = true,
    UseCustomSchema = false,
}); 
// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();

app.Run();
public partial class Program { }

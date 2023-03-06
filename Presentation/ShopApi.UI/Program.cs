using Autofac.Extensions.DependencyInjection;
using Autofac;
using ShopApi.Application;
using ShopApi.Persistance;
using ShopApi.Persistance.Autofac;
using Autofac.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ShopApi.Infrastructure;
using Serilog;
using Serilog.Core;
using FluentValidation.AspNetCore;
using ShopApi.Application.Validators;
using ShopApi.Application.Validators.Products;
using ShopApi.Infrastructure.Filters;
using ShopApi.Infrastructure.Services.Storage.Local;
using ShopApi.Infrastructure.Services.Storage.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddPersistanceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddAplicationServices();

//select storage for files
builder.Services.AddStorage<AzureStorage>();
//builder.Services.AddStorage<LocalStorage>();

builder.Services.AddControllers(opt => opt.Filters.Add<ValidationFilter>())
    .AddFluentValidation(con => con.RegisterValidatorsFromAssemblyContaining<ProductCreateValidator>())
    .ConfigureApiBehaviorOptions(x => x.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
}));

//logging with serilog
Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Auidence"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
        };
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();
app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

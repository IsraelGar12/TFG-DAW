using System.Text;
using License.viewer.api.Models;
using License.viewer.api.Productos.Application;
using License.viewer.api.Productos.Infrastructure;
using License.viewer.api.Servicios.Application;
using License.viewer.api.Servicios.Infrastructure;
using License.viewer.api.Users.Application;
using License.viewer.api.Users.Infrastructure;
using License.viewer.api.Videojuegos.Application;
using License.viewer.api.Videojuegos.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateActor = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt: Issuer"],
        ValidAudience = builder.Configuration["Jwt: Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddSingleton<Jwt>(provider => provider.GetRequiredService<IConfiguration>().GetSection("Jwt").Get<Jwt>());
builder.Services.AddTransient<UsersSearcher, UsersSearcher>();
builder.Services.AddTransient<IUserRepository, MySqlUserRepository>();

builder.Services.AddTransient<VideojuegosSearcher, VideojuegosSearcher>();
builder.Services.AddTransient<IVideojuegosRepository, MySqlVideojuegosRepository>();
builder.Services.AddTransient<VideojuegosCreator>();

builder.Services.AddTransient<ProductosSearcher, ProductosSearcher>();
builder.Services.AddTransient<IProductosRepository, MySqlProductosRepository>();
builder.Services.AddTransient<ProductosCreator>();

builder.Services.AddTransient<ServiciosSearcher, ServiciosSearcher>();
builder.Services.AddTransient<IServiciosRepository, MySqlServiciosRepository>();

builder.Services.AddScoped<MySqlConnection>(_ => new MySqlConnection("Server=localhost;Database=Wallarock.viewer;Uid=admin;Pwd=admin;AllowZeroDateTime=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Agregado
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

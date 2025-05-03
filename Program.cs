using System.Reflection;
using JWTAndApi.Context;
using JWTAndApi.Interfaces;
using JWTAndApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "JWTAndApi",
        Version = "v1",
        Description = "Book APIs",
        Contact = new OpenApiContact()
        {
            Email = "oserinkaya@gmail.com",
            Name = "Oktay SERÝNKAYA",
            Url = new Uri("https://github.com/oktayserinkaya")
        },
        License = new OpenApiLicense()
        {
            Name = "MIT License",
            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
        }
    });
    //API ile ilgili bilgileri içerecek dosyanýn adýný oluþturduk
    //ProjeAdi.xml
    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    // bin/debug/net8.0 klasörünün yolu ile dosya adýný konbinledik
    // bin/debug/net8.0/ProjeAdi.xml
    var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
    
    // API ile ilgili bilgilendirmeleri bu dosyaya yükledik
    options.IncludeXmlComments(xmlCommentFullPath);
});

var sqlConnection = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(sqlConnection);
});
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

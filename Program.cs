using System.Reflection;
using System.Text;
using JWTAndApi.Context;
using JWTAndApi.Interfaces;
using JWTAndApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

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
            Name = "Oktay SER�NKAYA",
            Url = new Uri("https://github.com/oktayserinkaya")
        },
        License = new OpenApiLicense()
        {
            Name = "MIT License",
            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header Kullan. �rnek Bearer '{token}'"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    //API ile ilgili bilgileri i�erecek dosyan�n ad�n� olu�turduk
    //ProjeAdi.xml
    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    // bin/debug/net8.0 klas�r�n�n yolu ile dosya ad�n� konbinledik
    // bin/debug/net8.0/ProjeAdi.xml
    var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

    // API ile ilgili bilgilendirmeleri bu dosyaya y�kledik
    options.IncludeXmlComments(xmlCommentFullPath);
});

var sqlConnection = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(sqlConnection);
});
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(options =>
{
    // Burada, varsay�lan kimlik do�rulama �emalar�n� belirliyoruz (Hepsi JWT Bearer olacak)
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Kimlik do�rulama s�ras�nda kullan�lacak �ema
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Kimlik do�rulama ba�ar�s�z oldu�unda kullan�lacak �ema
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; // Di�er kimlik do�rulama i�lemlerinde kullan�lacak �ema
}).AddJwtBearer(options =>
{
    // JWT do�rulama i�in parametreleri belirliyoruz
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["TokenSettings:ValidIssuer"], // Token �n hangi issue taraf�ndan �retildi�i kontrol edilecek
        ValidAudience = builder.Configuration["TokenSettings:ValidAudience"], // Token hedef kitlesi
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenSettings:SecretKey"] ?? "")), // token imzas�n� do�rulamak i�in gizli
        ValidateIssuer = true, // Issuer kontrol edilsin mi?
        ValidateAudience = false, //Audience kontrol�
        ValidateLifetime = true, // Token s�resi kontrol�
        ValidateIssuerSigningKey = true // imza do�rulamas� yap�ls�n m�?
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthentication(); // her zaman �stte olacak

app.UseAuthorization();

app.MapControllers();

app.Run();

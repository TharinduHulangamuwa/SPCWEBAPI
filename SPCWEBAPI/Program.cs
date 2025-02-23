using Microsoft.EntityFrameworkCore;
using SPCWebAPI; // Ensure your DbContext (SPCDbContext) is located in the Data namespace.
using Microsoft.OpenApi.Models; // For Swagger customization if desired.

var builder = WebApplication.CreateBuilder(args);

// Add Database Context
builder.Services.AddDbContext<SPCWEBAPI.Data.SPCDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Controllers
builder.Services.AddControllers();

// Optionally, configure Swagger with additional metadata
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SPC Web API",
        Version = "v1",
        Description = "An API for managing suppliers, drugs, and order processing for SPC."
    });
});

// Uncomment and configure the authentication services if you plan to implement JWT or other auth schemes.
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = builder.Configuration["Jwt:Issuer"],
//         ValidAudience = builder.Configuration["Jwt:Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//     };
// });

var app = builder.Build();

// Enable Swagger in Development Environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// If using authentication, the order is important.
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

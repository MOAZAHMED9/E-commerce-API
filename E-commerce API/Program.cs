using E_commerce_API.Auth;
using E_commerce_API.Data;
using E_commerce_API.Middleware;
using E_commerce_API.Services.Audit;
using E_commerce_API.Services.Category;
using E_commerce_API.Services.Dashboard;
using E_commerce_API.Services.Order;
using E_commerce_API.Services.Product;
using E_commerce_API.Services.Review;
using E_commerce_API.Services.ShoppingCart;
using E_commerce_API.Services.TokenService;
using E_commerce_API.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Training_Center_Management_API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(option =>

    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));




builder.Services.AddScoped<IJwtService,JwtService>();
builder.Services.AddScoped<ICurrentUserService,CurrentUserService>();
builder.Services.AddScoped<ICategoryService,CategorySesvice>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthorizationHandler, CustomerOwnerOrAdminHandler>();
builder.Services.AddScoped<IDashboardService, DashboardService>();



builder.Services.AddAuthorization(options =>                       // تجهيو الpolice
{
    options.AddPolicy("CustomerOwner", policy =>
    {
        policy.RequireAuthenticatedUser();

        policy.AddRequirements(new CustomerOwnerOrAdminRequirement());
    });
});




builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("AuthPolicy", limiterOptions =>
    {
        limiterOptions.PermitLimit = 5;

        limiterOptions.Window = TimeSpan.FromMinutes(1);

        limiterOptions.QueueLimit = 0;                 //متخزنش طلب
    });

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});                    //   بولسي ال ليمت 





builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
                Array.Empty<string>()

        }
    });
});       //زرار ال authorize


builder.Services.AddHttpContextAccessor();


// علشان نشغل ال authourization
var jwtSettings = builder.Configuration.GetSection("Jwt");             // بيجيب قسم Jwt من الإعداداتjson          

//var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);    //بيحوّل المفتاح من نص إلى bytes، وبعدها ينشئ منه مفتاح يستخدم لتوقيع التوكن.
var jwtKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY_Ecommerce");


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)     //التاكد من اعداتات ال jwt
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!)),

                ClockSkew = TimeSpan.Zero
            };
    });




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRateLimiter();
app.UseAuthentication();
app.UseMiddleware<SecurityLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
/// عايزين نشوف الترتيب 
using DATN_ACV_DEV;
using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.Payload.Converter;
using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Payload.Response;
using DATN_ACV_DEV.Repository.Implement;
using DATN_ACV_DEV.Repository.Interface;
using DATN_ACV_DEV.Service.IServices;
using DATN_ACV_DEV.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer("Data Source=DESKTOP-ME11437\\SQLEXPRESS;Initial Catalog=DATN_ALB;Integrated Security=True"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<IAccountRepositories, AccountRepositories>();
builder.Services.AddScoped<IEmailServices, EmailServices>();
builder.Services.AddScoped<IVnPayServices, VnPayServices>();
builder.Services.AddScoped<IBillServices, BillServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();


builder.Services.AddTransient<IBaseRepositories<TbAccount>, BaseReposiroies<TbAccount>>();
builder.Services.AddTransient<IBaseRepositories<TbProduct>, BaseReposiroies<TbProduct>>();

builder.Services.AddTransient<IBaseRepositories<Role>, BaseReposiroies<Role>>();
builder.Services.AddTransient<IBaseRepositories<TbOrder>, BaseReposiroies<TbOrder>>();
builder.Services.AddTransient<IBaseRepositories<RefreshToken>, BaseReposiroies<RefreshToken>>();
builder.Services.AddTransient<IBaseRepositories<ConfirmEmail>, BaseReposiroies<ConfirmEmail>>();

builder.Services.AddScoped<IDbContext, DBContext>();
builder.Services.AddScoped<ResponseObject<ResponseRegister>>();
builder.Services.AddScoped<ResponseObject<Response_Product>>();

builder.Services.AddScoped<ResponseObject<ResponseBill>>();
builder.Services.AddScoped<ConverterAccount>();
builder.Services.AddScoped<Converter_Order>();
builder.Services.AddScoped<Converter_Product>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = false;
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:SecretKey").Value!))
        };

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

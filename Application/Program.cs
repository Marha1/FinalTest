using Application.Service;
using Infrastructure;
using Infrastructure.DAL.Implementations;
using Infrastructure.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FluentValidation; // Подключение AutoMapper

var builder = WebApplication.CreateBuilder(args);

// Чтение настроек из конфигурации
builder.Configuration.AddJsonFile("appsettings.json");

// Подключение к базе данных с использованием Npgsql
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация репозиториев
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<ISensorDataRepository, SensorDataRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); // Добавление IUserRepository

// Регистрация сервисов
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<BuildingService>();
builder.Services.AddScoped<SensorService>();
builder.Services.AddScoped<SensorDataService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddValidatorsFromAssemblyContaining<FinalTestDomain.Validations.UserValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<FinalTestDomain.Validations.BuildingValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<FinalTestDomain.Validations.SensorValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<FinalTestDomain.Validations.SensorDataValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<FinalTestDomain.Validations.NotificationValidation>();

// Регистрация AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Добавление поддержки HTTP контекста и автоматическая генерация API документации
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Настройка HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

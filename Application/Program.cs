using Application.Service;
using Infrastructure;
using Infrastructure.DAL.Implementations;
using Infrastructure.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Чтение настроек из конфигурации
builder.Configuration.AddJsonFile("appsettings.json");

// Подключение к базе данных с использованием Npgsql
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация сервисов и репозиториев
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<ISensorDataRepository, SensorDataRepository>();  // Добавление репозитория для SensorData
builder.Services.AddScoped<INotificationRepository, NotificationRepository>(); // Добавление репозитория для Notification

// Регистрация сервисов
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<BuildingService>();
builder.Services.AddScoped<SensorService>();
builder.Services.AddScoped<SensorDataService>(); 
builder.Services.AddScoped<NotificationService>();  

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
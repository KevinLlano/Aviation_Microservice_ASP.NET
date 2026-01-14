using training_service.config;
using training_service.data;
using training_service.repository;
using training_service.service;
using training_service.services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register DbContext with database connection
builder.Services.AddDbContext<TrainingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<InstructorRepository>();
builder.Services.AddScoped<LessonRepository>();

// Register services
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<InstructorService>();
builder.Services.AddScoped<LessonService>();

builder.Services.AddApiSecurity(); // Add API security configuration

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// sample data for development mode purposes
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<TrainingDbContext>();
        context.Database.EnsureCreated(); // Create database if it doesn't exist
        DataSeeder.SeedData(context);
    }
}

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

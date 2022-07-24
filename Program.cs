using YelpCampAPI;
using YelpCampAPI.Services;
using YelpCampAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<YelpCampContext>(builder.Configuration.GetConnectionString("cnYelpCamp"));

//Inyeccion de dependencias
builder.Services.AddScoped<ICampground, CampgroundService>();
builder.Services.AddScoped<IComment, CommentService>();
builder.Services.AddScoped<IUser, UserService>();

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

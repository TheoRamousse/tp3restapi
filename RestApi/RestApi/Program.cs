using RestApi.DataAccessLayer;
using RestApi.Models.Contexts;
using RestApi.Models.Dtos;
using RestApi.Models.Entities;
using RestApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieContext>();
builder.Services.AddScoped<IDal<GuestEntity>, SqLiteDal<GuestEntity>>();
builder.Services.AddScoped<IDal<MovieEntity>, SqLiteDal<MovieEntity>>();
builder.Services.AddScoped<IElementService<MovieDto, MovieEntity>, MovieService>();

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

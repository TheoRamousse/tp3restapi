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
builder.Services.AddScoped<IDal<GuestEntity>, GuestDal>();
builder.Services.AddScoped<IDal<MovieEntity>, MovieDal>();
builder.Services.AddScoped<IDal<RelationEntity>, RelationDal>();
builder.Services.AddScoped<IElementService<MovieDto, MovieEntity>, MovieService>();
builder.Services.AddScoped<IElementService<GuestDto, GuestEntity>, GuestService>();

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

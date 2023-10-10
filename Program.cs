using Microsoft.EntityFrameworkCore;
using movie_api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieContext>(opts =>
                opts.UseNpgsql(builder.Configuration.GetConnectionString(name: "MovieConnection")));

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

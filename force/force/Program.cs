
using force.Interfaces ;
using force.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
#pragma warning disable CS8604 // Posible argumento de referencia nulo  
var sqlConfig = new SqlConfiguration(builder.Configuration.GetConnectionString("connection")) ;
#pragma warning restore CS8604 // Posible argumento de referencia nulo


builder.Services.AddControllers() ;
builder.Services.AddSingleton(sqlConfig);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => 
{
  options.AddPolicy("bioforce", policyBuilder => {

    policyBuilder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials() ;
  });
}
);  

builder.Services.AddScoped<IJugador , RepoJugador>() ;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
      app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
    });
}
app.UseHttpsRedirection();

app.UseCors("bioforce");

app.MapControllers() ;

app.Run() ;
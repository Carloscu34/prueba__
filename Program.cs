using Microsoft.EntityFrameworkCore;

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole()
        .AddDebug()
        .SetMinimumLevel(LogLevel.Information);
});using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? cadena ="builder.Configuration.GetConnectionString("DefaultConnection");
if(cadena!=null){
    builder.Services.AddDbContext<ApiEmpresaContext>(options =>
     opt.UseMySQL(cadena));
}
builder.Services.AddControllers();

   
    //opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); ESTO ES PARA SQL SERVER
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

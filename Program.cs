using Microsoft.Extensions.Options;
using storageCRUD.Models;
using storageCRUD.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<StorageSettings>(builder.Configuration.GetSection(nameof(StorageSettings)));
builder.Services.AddSingleton<IStorageSettings>(d => d.GetRequiredService<IOptions<StorageSettings>>().Value);

builder.Services.AddSingleton<StorageServices>();

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

using Microsoft.EntityFrameworkCore;
using N5.Data;
using N5.Data.Interfaces;
using N5.Data.Repositories;
using N5.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using MediatR;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<N5ChallengeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("N5Challenge")));

builder.Services.AddScoped<ICRUDData<PermissionType>, PermissionTypeRepository>();
builder.Services.AddScoped<ICRUDData<Permission>, PermissionRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddMediatR(typeof(EntryPoint).Assembly);
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Open");
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();

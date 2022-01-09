using System.Text.Json.Serialization;
using AIHR.WorkloadCalculator.Service.Data;
using AIHR.WorkloadCalculator.Service.Services;
using AIHR.WorkloadCalculator.Service.Services.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Db");


builder.Services.AddDbContext<WorkloadCalculatorDbContext>(x => x.UseSqlite(connectionString));

builder.Services.AddCors(setup =>
{
    setup.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddScoped<IWorkloadCalculatorService,WorkloadCalculatorService>();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1",
        new OpenApiInfo { Description = "Workload Calculator API", Title = "AIHR Assessment", Version = "v1" });
});


var app = builder.Build();

await EnsureDbAsync(app.Services);

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();


static async Task EnsureDbAsync(IServiceProvider sp)
{
    await using var db = sp.CreateScope().ServiceProvider.GetRequiredService<WorkloadCalculatorDbContext>();
    await db.Database.MigrateAsync();
}
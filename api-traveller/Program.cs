using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using static api_traveller.Controllers.HoteisController;
using static api_traveller.Controllers.ViagensController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<api_traveller.Controllers.HoteisController.GulliverContext>(options => options.UseInMemoryDatabase("GulliverContext"));
builder.Services.AddScoped<api_traveller.Controllers.HoteisController.GulliverContext>();
builder.Services.AddDbContext<api_traveller.Controllers.ViagensController.GulliverContext>(options => options.UseInMemoryDatabase("GulliverContext"));
builder.Services.AddScoped<api_traveller.Controllers.ViagensController.GulliverContext>();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var app = builder.Build();
app.UseCors();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    api_traveller.Controllers.HoteisController.SeedData.Initialize(services);
    api_traveller.Controllers.ViagensController.SeedData.Initialize2(services);
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

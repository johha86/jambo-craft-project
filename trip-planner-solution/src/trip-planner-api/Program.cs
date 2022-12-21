using TripPlannerApi.Configurations;
using TripPlannerApi.DataAccessLayer;
using TripPlannerApi.Integration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var databaseSettings = builder.Configuration.GetSection("TripPlannerDatabase");
builder.Services.Configure<TripPlannerDatabaseSettings>(databaseSettings);

//  repositories
if (string.IsNullOrEmpty(databaseSettings["ConnectionString"]))
{
    builder.Services.AddSingleton<ICitiyRepository, FixedCityRepository>();
}
else
{
    builder.Services.AddSingleton<ICitiyRepository, CitiyRepository>();
}
builder.Services.AddSingleton<IWeatherRepository, RandomWeatherRepository>();

//  background services
builder.Services.AddHostedService<WeatherForcastBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

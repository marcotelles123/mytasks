using DbUp;
using MyTasks.API.Config;
using MyTasks.Infra;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddSingleton<IMyTasksRepository, MyTasksRepositoryPostgres>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();

    });
});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();


builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var upgrader = DeployChanges.To.PostgresqlDatabase(builder.Configuration.GetConnectionString("Default")).WithScriptsFromFileSystem("Scripts/DBCreation").LogToConsole().Build();

var result = upgrader.PerformUpgrade();

if (result.Successful)
{
    Console.WriteLine("Upgrade succeeded!");
}
else
{
    Console.WriteLine("Upgrade failed!");
}

upgrader = DeployChanges.To.PostgresqlDatabase(builder.Configuration.GetConnectionString("PostgresConnectionString")).WithScriptsFromFileSystem("Scripts/DBMigration").LogToConsole().Build();
result = upgrader.PerformUpgrade();

if (result.Successful)
{
    Console.WriteLine("Upgrade succeeded!");
}
else
{
    Console.WriteLine("Upgrade failed!");
}

var app = builder.Build();

app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

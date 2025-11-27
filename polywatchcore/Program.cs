using Microsoft.EntityFrameworkCore;
using polywatchcore.Services;
using Quartz;
using Serilog;

namespace polywatchcore;

public class Program
{
  public static async Task Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    Log.Logger = new LoggerConfiguration()
      .Enrich.FromLogContext()
      .WriteTo.Console()
      .WriteTo.SQLite("Data Source=polywatch-core.db")
      .CreateLogger();

    builder.Services.AddSerilog();

    builder.Services.AddQuartz();
    builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    builder.Services.AddDbContext<AppDbContext>(cfg => cfg.UseSqlite("Data Source=polywatch-core.db"));

    builder.Services.AddScoped<GDELTNewsService>();

    var app = builder.Build();

    await DoJobSetupAsync(await app.Services.GetRequiredService<ISchedulerFactory>().GetScheduler());

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();


    app.MapControllers();

    app.Run();
  }

  private static async Task DoJobSetupAsync(IScheduler scheduler)
  {
    await scheduler.ScheduleJob(
        JobBuilder.Create<GdeltImportJob>()
        .WithIdentity("GDELTImport", "imports")
        .Build(),
        TriggerBuilder.Create()
        .WithSimpleSchedule(x => x.WithIntervalInMinutes(15).RepeatForever())
        .Build()
        );
  }
}

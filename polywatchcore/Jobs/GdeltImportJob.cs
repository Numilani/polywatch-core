using polywatchcore.Services;
using Quartz;

public class GdeltImportJob(ILogger<GdeltImportJob> log, GDELTNewsService svc) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
      log.LogInformation("Fake GDELT Import (not implemented)");
    }
}

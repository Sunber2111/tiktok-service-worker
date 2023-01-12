using Confluent.Kafka;

namespace ServiceWorker;

public class Worker : BackgroundService
{
    private readonly IConsumer<string, string> _consumer;
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger, IConsumer<string, string> consumer)
    {
        _logger = logger;
        _consumer = consumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }

    public override void Dispose()
    {
        _consumer.Dispose();
        base.Dispose();
    }
}


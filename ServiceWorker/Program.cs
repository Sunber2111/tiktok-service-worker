using Elasticsearch.Net;
using Nest;
using ServiceWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var settings = new ConnectionSettings(pool)
            .DefaultIndex("post");
        var client = new ElasticClient(settings);

        services.AddSingleton(client);
    })
    .Build();

await host.RunAsync();


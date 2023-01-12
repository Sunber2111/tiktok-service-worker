using System.Text.Json.Serialization;

namespace Common.Kafka;

public record KafkaMessage<T>
{
    [JsonPropertyName("schema")] public SchemaPrimary Schema { get; set; } = new();
    [JsonPropertyName("payload")] public Payload<T> Payload { get; set; } = new();
}

public record SchemaPrimary
{
    [JsonPropertyName("type")] public string? Type { get; set; }

    [JsonPropertyName("fields")]
    public IReadOnlyCollection<FieldsPrimary> Fields { get; set; } = new List<FieldsPrimary>();

    [JsonPropertyName("optional")] public bool Optional { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
}

public record FieldsPrimary
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("fields")] public IReadOnlyCollection<FieldChild>? Fields { get; set; } = new List<FieldChild>();
    [JsonPropertyName("optional")] public bool Optional { get; set; }
    [JsonPropertyName("field")] public string? Field { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
}

public record FieldChild
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("optional")] public bool Optional { get; set; }
    [JsonPropertyName("field")] public string? Field { get; set; }
}

public record Payload<T>
{
    [JsonPropertyName("before")] public T? Before { get; set; }
    [JsonPropertyName("after")] public T? After { get; set; }
}

public record KeyIdentification
{
    [JsonPropertyName("payload")] public Identification? Payload { get; set; }
}

public record Identification
{
    [JsonPropertyName("Id")] public Guid Id { get; set; }
}


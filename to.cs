// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Value
{
    [JsonPropertyName("height")]
    public double Height { get; set; }

    [JsonPropertyName("rectanglelabels")]
    public List<string> Rectanglelabels { get; set; }

    [JsonPropertyName("rotation")]
    public int Rotation { get; set; }

    [JsonPropertyName("width")]
    public double Width { get; set; }

    [JsonPropertyName("x")]
    public double X { get; set; }

    [JsonPropertyName("y")]
    public double Y { get; set; }
}

public class Result
{
    [JsonPropertyName("from_name")]
    public string FromName { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("image_rotation")]
    public int ImageRotation { get; set; }

    [JsonPropertyName("original_height")]
    public int? OriginalHeight { get; set; }

    [JsonPropertyName("original_width")]
    public int? OriginalWidth { get; set; }

    [JsonPropertyName("to_name")]
    public string ToName { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("value")]
    public Value Value { get; set; }
}

public class Completion
{
    [JsonPropertyName("created_at")]
    public int? CreatedAt { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("lead_time")]
    public double LeadTime { get; set; }

    [JsonPropertyName("result")]
    public List<Result> Result { get; set; }
}

public class Data
{
    [JsonPropertyName("image")]
    public string Image { get; set; }
}

public class LabelStudioRoot
{
    [JsonPropertyName("completions")]
    public List<Completion> Completions { get; set; }

    [JsonPropertyName("data")]
    public Data Data { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }
}


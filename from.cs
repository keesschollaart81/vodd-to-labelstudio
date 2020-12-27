using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Size
{
    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }
}

public class Asset
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("state")]
    public int State { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("size")]
    public Size Size { get; set; }
}

public class BoundingBox
{
    [JsonPropertyName("height")]
    public double Height { get; set; }

    [JsonPropertyName("width")]
    public double Width { get; set; }

    [JsonPropertyName("left")]
    public double Left { get; set; }

    [JsonPropertyName("top")]
    public double Top { get; set; }
}

public class Point
{
    [JsonPropertyName("x")]
    public double X { get; set; }

    [JsonPropertyName("y")]
    public double Y { get; set; }
}

public class Region
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("boundingBox")]
    public BoundingBox BoundingBox { get; set; }

    [JsonPropertyName("points")]
    public List<Point> Points { get; set; }
}

public class VottRoot
{
    [JsonPropertyName("asset")]
    public Asset Asset { get; set; }

    [JsonPropertyName("regions")]
    public List<Region> Regions { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }
}


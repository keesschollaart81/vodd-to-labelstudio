using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

var sourcePath = new DirectoryInfo("/Users/Kees/Downloads/voc/");
var destinationpath = new DirectoryInfo("/Users/Kees/Projects/vott-to-labelstudio/result");

foreach (var file in destinationpath.GetFiles())
{
    file.Delete();
}

var index = 0;
foreach (var file in sourcePath.GetFiles())
{
    if (file.Extension != ".json") continue;

    using var filestream = file.OpenRead();
    var vottFile = await JsonSerializer.DeserializeAsync<VottRoot>(filestream);
    if (!vottFile.Regions.Any()) continue;

    var lsRoot = new LabelStudioRoot();
    lsRoot.Data = new Data();
    // lsRoot.Data.Image = $"http:\\/\\/localhost:8080\\/data\\/upload\\/" + vottFile.Asset.Name;
    lsRoot.Data.Image = $"gs://labelstudiokees/g4s/" + vottFile.Asset.Name;
    lsRoot.Completions = new List<Completion>();
    var completion = new Completion();
    completion.Result = new List<Result>();
    foreach (var region in vottFile.Regions)
    {
        var h = (region.BoundingBox.Height / vottFile.Asset.Size.Height) * 100f;
        var w = (region.BoundingBox.Width / vottFile.Asset.Size.Width) * 100f;
        var x = (region.BoundingBox.Left / vottFile.Asset.Size.Width) * 100f;
        var y = (region.BoundingBox.Top / vottFile.Asset.Size.Height) * 100f;

        completion.Result.Add(new Result
        {
            FromName = "label",
            ImageRotation = 0,
            OriginalHeight = vottFile.Asset.Size.Height,
            OriginalWidth = vottFile.Asset.Size.Width,
            ToName = "image",
            Type = "rectanglelabels",
            Value = new Value
            {
                Height = h,
                Rectanglelabels = region.Tags,
                Rotation = 0,
                Width = w,
                X = x,
                Y = y
            }
        });
    }
    lsRoot.Completions.Add(completion);

    var json = JsonSerializer.Serialize(lsRoot, new JsonSerializerOptions
    {
        IgnoreNullValues = true,
        WriteIndented = true
    });
    File.WriteAllText(destinationpath + "/" + index + ".json", json);

    Console.WriteLine(vottFile.Asset.Id);
    index++;
}

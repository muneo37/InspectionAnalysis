
public class ChartContents
{
    public ChartContents()
    {
    }

    public string? Type { get; set; }

    public string[] Labels { get; set; } = { "" };

    public string Options { get; set; } = "\"options\": {}";

    public IEnumerable<ChartItem>? Items { get; set; }
}

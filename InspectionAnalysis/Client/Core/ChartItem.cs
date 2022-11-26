using System.Drawing;

public class ChartItem
{
    public ChartItem(int [] data)
    {
        if (data is null)
            throw new ArgumentNullException("data");

        this.Data = data;
        Data = data;
    }

    public int[]? Data { get; set; }

    public string? Label { get; set; } = "ChartItem";

    public Color BackgroundColor { get; set; }

    public string? Options { get; set; }
 
    public override string ToString()
    {
        var str = "";
        if (this.Data != null)
        {
            str = "{" +
                String.Join(", ", new string[]
                    {
                                $"\"label\": \"{this.Label}\"",
                                $"\"data\": [{string.Join(", ", this.Data)}]",
                                $"\"backgroundColor\": \"rgba({this.BackgroundColor.R}, {this.BackgroundColor.G}, {this.BackgroundColor.B}, {this.BackgroundColor.A / 255.0})\"",
                   });
            if(Options != null)
            {
                str = str + "," + Options;
            }
            str += "}";
        }

        return str;
    }
}

namespace MaxNet.Models.Attachments.Keyboard.Buttons;

public record LinkButton : Button
{
    [JsonProperty("type")]
    public override required string Type { get; init; } = "link";

    [JsonProperty("text")]
    public override required string Text { get; init; }

    [JsonProperty("url")]
    public required string Url { get; init; }
}
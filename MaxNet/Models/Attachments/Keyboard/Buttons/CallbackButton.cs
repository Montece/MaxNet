namespace MaxNet.Models.Attachments.Keyboard.Buttons;

public record CallbackButton : Button
{
    [JsonProperty("payload")]
    public required string Payload { get; init; }

    [JsonProperty("intent")]
    public string Intent { get; init; } = "default";

    [JsonProperty("type")]
    public override required string Type { get; init; } = "callback";

    [JsonProperty("text")]
    public override required string Text { get; init; }
}
namespace MaxNet.Models.Attachments.Keyboard.Buttons;

public record RequestContactButton : Button
{
    [JsonProperty("text")]
    public override required string Text { get; init; }

    [JsonProperty("type")]
    public override required string Type { get; init; } = "request_contact";
}
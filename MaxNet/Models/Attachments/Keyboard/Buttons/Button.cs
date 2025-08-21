namespace MaxNet.Models.Attachments.Keyboard.Buttons;

public abstract record Button
{
    [JsonProperty("type")]
    public abstract required string Type { get; init; }

    [JsonProperty("text")]
    public abstract required string Text { get; init; }
}
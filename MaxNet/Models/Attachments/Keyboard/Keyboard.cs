using MaxNet.Models.Attachments.Keyboard.Buttons;

namespace MaxNet.Models.Attachments.Keyboard;

public record Keyboard
{
    [JsonProperty("buttons")]
    public required List<List<Button>> Buttons { get; init; }
}
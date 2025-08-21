namespace MaxNet.Models.Attachments.Keyboard.Buttons;

public record RequestGeoLocationButton : Button
{
    [JsonProperty("type")]
    public override required string Type { get; init; } = "request_geo_location";

    [JsonProperty("text")]
    public override required string Text { get; init; }

    [JsonProperty("quick")]
    public required bool Quick { get; init; }
}
using System.Diagnostics.CodeAnalysis;

namespace MaxNet.Utility.Json;

[SuppressMessage("ReSharper", "SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault")]
public sealed class UnixMillisDateTimeConverterNewtonsoft : JsonConverter<DateTimeOffset>
{
    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, DateTimeOffset value, JsonSerializer serializer) => writer.WriteValue(value.ToUnixTimeMilliseconds());
    
    /// <inheritdoc />
    public override DateTimeOffset ReadJson(JsonReader reader, Type objectType, DateTimeOffset existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return reader.TokenType switch
        {
            JsonToken.Integer => DateTimeOffset.FromUnixTimeMilliseconds((long)reader.Value!),
            JsonToken.String when long.TryParse((string)reader.Value!, out var ms) => DateTimeOffset.FromUnixTimeMilliseconds(ms),
            _ => throw new JsonSerializationException("Expected unix ms timestamp")
        };
    }
}
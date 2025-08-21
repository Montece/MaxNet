using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MaxNet.Enums.Messages;

[JsonConverter(typeof(StringEnumConverter))]
public enum TextFormat
{
    [EnumMember(Value = "markdown")]
    Markdown,

    [EnumMember(Value = "html")]
    Html
}
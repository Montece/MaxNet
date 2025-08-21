using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MaxNet.Enums.Messages;

[JsonConverter(typeof(StringEnumConverter))]
public enum MessageLinkType
{
    [EnumMember(Value = "reply")]
    Reply,

    [EnumMember(Value = "forward")]
    Forward
}
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MaxNet.Enums.Uploads;

[JsonConverter(typeof(StringEnumConverter))]
public enum UploadType
{
    [EnumMember(Value = "image")]
    Image,

    [EnumMember(Value = "video")]
    Video,

    [EnumMember(Value = "audio")]
    Audio,

    [EnumMember(Value = "file")]
    File
}
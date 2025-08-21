using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MaxNet.Enums.Chats;

[JsonConverter(typeof(StringEnumConverter))]
public enum SenderAction
{
    [EnumMember(Value = "typing_on")]
    TypingOn,

    [EnumMember(Value = "sending_photo")]
    SendingPhoto,

    [EnumMember(Value = "sending_video")]
    SendingVideo,

    [EnumMember(Value = "sending_audio")]
    SendingAudio,

    [EnumMember(Value = "sending_file")]
    SendingFile,

    [EnumMember(Value = "mark_seen")]
    MarkSeen
}
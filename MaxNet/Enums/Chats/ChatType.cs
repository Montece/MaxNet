using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace MaxNet.Enums.Chats;

/// <summary>
/// Тип чата
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ChatType
{
    /// <summary>
    /// Групповой чат
    /// </summary>
    [EnumMember(Value = "chat")]
    Chat
}
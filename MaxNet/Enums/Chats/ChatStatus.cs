using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MaxNet.Enums.Chats;

/// <summary>
/// Статус чата
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ChatStatus
{
    /// <summary>
    /// Бот является активным участником чата
    /// </summary>
    [EnumMember(Value = "active")]
    Active,

    /// <summary>
    /// Бот был удалён из чата
    /// </summary>
    [EnumMember(Value = "removed")]
    Removed,

    /// <summary>
    /// Бот покинул чат
    /// </summary>
    [EnumMember(Value = "left")]
    Left,

    /// <summary>
    /// Чат был закрыт
    /// </summary>
    [EnumMember(Value = "closed")]
    Closed,
}
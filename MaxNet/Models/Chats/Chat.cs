using MaxNet.Enums.Chats;
using MaxNet.Models.Images;
using MaxNet.Models.Messages;
using MaxNet.Models.Users;

namespace MaxNet.Models.Chats;

public record Chat
{
    [JsonProperty("chat_id")]
    public required long ChatId { get; init; }

    [JsonProperty("type")]
    public required ChatType Type { get; init; }

    [JsonProperty("status")]
    public required ChatStatus Status { get; init; }

    [JsonProperty("title")]
    public required string? Title { get; init; }

    [JsonProperty("icon")]
    public required Image? Icon { get; init; }

    [JsonProperty("last_event_time")]
    public required long LastEventTime { get; init; }

    [JsonProperty("participants_count")]
    public required int ParticipantsCount { get; init; }

    [JsonProperty("owner_id")]
    public long? OwnerId { get; init; }

    [JsonProperty("is_public")]
    public required bool IsPublic { get; init; }

    [JsonProperty("link")]
    public string? Link { get; init; }

    [JsonProperty("description")]
    public string? Description { get; init; }

    [JsonProperty("dialog_with_user")]
    public UserWithPhoto? DialogWithUser { get; init; }

    [JsonProperty("chat_message_id")]
    public string? ChatMessageId { get; init; }

    [JsonProperty("pinned_message")]
    public Message? PinnedMessage { get; init; }
}
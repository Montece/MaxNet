using MaxNet.Client.Abstraction;
using MaxNet.Enums.Chats;
using MaxNet.Models.ChatPins;
using MaxNet.Models.Chats;
using MaxNet.Models.Users;
using System.Globalization;

namespace MaxNet.Client.Modules;

public sealed class ChatsModule : IChatsModule
{
    public IMaxBotClient MaxBotClient { get; }

    public ChatsModule(MaxBotClient maxBotClient)
    {
        MaxBotClient = maxBotClient;
    }

    public Task<ChatList> GetChatsAsync(int count = 50, long? marker = null, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<ChatList>(HttpMethod.Get, "/chats", null, new Dictionary<string, string?>
        {
            ["count"] = count.ToString(CultureInfo.InvariantCulture),
            ["marker"] = marker?.ToString(CultureInfo.InvariantCulture)

        }, cancellationToken);
    }

    public Task<Chat> GetChatAsync(long chatId, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<Chat>(HttpMethod.Get, $"/chats/{chatId}", null, null, cancellationToken);
    }

    public Task<Chat> GetChatByLinkAsync(string chatLinkOrUsername, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<Chat>(HttpMethod.Get, $"/chats/{Uri.EscapeDataString(chatLinkOrUsername)}", null, null, cancellationToken);
    }

    public Task<Chat> EditChatAsync(long chatId, ChatPatch patch, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<Chat>(HttpMethod.Patch, $"/chats/{chatId}", patch, null, cancellationToken);
    }

    public Task<SimpleQueryResult> DeleteChatAsync(long chatId, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Delete, $"/chats/{chatId}", null, null, cancellationToken);
    }

    public Task<SimpleQueryResult> SendActionAsync(long chatId, SenderAction action, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Post, $"/chats/{chatId}/actions", new ActionRequestBody { Action = action }, null, cancellationToken);
    }

    public Task<GetPinnedMessageResult> GetPinnedMessageAsync(long chatId, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<GetPinnedMessageResult>(HttpMethod.Get, $"/chats/{chatId}/pin", null, null, cancellationToken);
    }

    public Task<SimpleQueryResult> PinMessageAsync(long chatId, PinMessageBody body, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Put, $"/chats/{chatId}/pin", body, null, cancellationToken);
    }

    public Task<SimpleQueryResult> UnpinMessageAsync(long chatId, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Delete, $"/chats/{chatId}/pin", null, null, cancellationToken);
    }

    public Task<ChatMember> GetMyMembershipAsync(long chatId, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<ChatMember>(HttpMethod.Get, $"/chats/{chatId}/members/me", null, null, cancellationToken);
    }

    public Task<SimpleQueryResult> LeaveChatAsync(long chatId, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Delete, $"/chats/{chatId}/members/me", null, null, cancellationToken);
    }

    public Task<ChatMembersList> GetMembersAsync(long chatId, long? marker = null, int? count = null, IEnumerable<long>? userIds = null, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<ChatMembersList>(HttpMethod.Get, $"/chats/{chatId}/members", null, new Dictionary<string, string?> { ["marker"] = marker?.ToString(CultureInfo.InvariantCulture), ["count"] = count?.ToString(CultureInfo.InvariantCulture), ["user_ids"] = userIds is null ? null : string.Join(",", userIds) }, cancellationToken);
    }

    public Task<SimpleQueryResult> AddMembersAsync(long chatId, IEnumerable<long> userIds, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Post, $"/chats/{chatId}/members", new UserIdsList { UserIds = userIds.ToArray() }, null, cancellationToken);
    }

    public Task<SimpleQueryResult> RemoveMemberAsync(long chatId, long userId, bool block = false, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Delete, $"/chats/{chatId}/members", null, new Dictionary<string, string?> { ["user_id"] = userId.ToString(CultureInfo.InvariantCulture), ["block"] = block ? "true" : "false" }, cancellationToken);
    }
}
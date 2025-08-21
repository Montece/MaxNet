using MaxNet.Enums.Chats;
using MaxNet.Models.ChatPins;
using MaxNet.Models.Chats;

namespace MaxNet.Client.Abstraction;

public interface IChatsModule : IModule
{
    Task<ChatList> GetChatsAsync(int count = 50, long? marker = null, CancellationToken cancellationToken = default);

    Task<Chat> GetChatAsync(long chatId, CancellationToken cancellationToken = default);

    Task<Chat> GetChatByLinkAsync(string chatLinkOrUsername, CancellationToken cancellationToken = default);

    Task<Chat> EditChatAsync(long chatId, ChatPatch patch, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> DeleteChatAsync(long chatId, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> SendActionAsync(long chatId, SenderAction action, CancellationToken cancellationToken = default);

    Task<GetPinnedMessageResult> GetPinnedMessageAsync(long chatId, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> PinMessageAsync(long chatId, PinMessageBody body, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> UnpinMessageAsync(long chatId, CancellationToken cancellationToken = default);

    Task<ChatMember> GetMyMembershipAsync(long chatId, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> LeaveChatAsync(long chatId, CancellationToken cancellationToken = default);

    Task<ChatMembersList> GetMembersAsync(long chatId, long? marker = null, int? count = null, IEnumerable<long>? userIds = null, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> AddMembersAsync(long chatId, IEnumerable<long> userIds, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> RemoveMemberAsync(long chatId, long userId, bool block = false, CancellationToken cancellationToken = default);
}
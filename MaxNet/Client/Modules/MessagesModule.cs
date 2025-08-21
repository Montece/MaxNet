using MaxNet.Client.Abstraction;
using MaxNet.Models.Messages;
using MaxNet.Models.Videos;
using System.Globalization;

namespace MaxNet.Client.Modules;

public sealed class MessagesModule : IMessagesModule
{
    public IMaxBotClient MaxBotClient { get; }

    public MessagesModule(MaxBotClient maxBotClient)
    {
        MaxBotClient = maxBotClient;
    }

    public Task<MessageList> GetMessagesAsync(long? chatId = null, IEnumerable<string>? messageIds = null, long? from = null, long? to = null, int? count = null, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<MessageList>(HttpMethod.Get, "/messages", null, new Dictionary<string, string?>
        {
            ["chat_id"] = chatId?.ToString(CultureInfo.InvariantCulture),
            ["message_ids"] = messageIds is null ? null : string.Join(",", messageIds),
            ["from"] = from?.ToString(CultureInfo.InvariantCulture),
            ["to"] = to?.ToString(CultureInfo.InvariantCulture),
            ["count"] = count?.ToString(CultureInfo.InvariantCulture)
        }, cancellationToken);
    }

    public Task<Message> GetMessageByIdAsync(string messageId, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<Message>(HttpMethod.Get, $"/messages/{Uri.EscapeDataString(messageId)}", null, null, cancellationToken);
    }

    public Task<SendMessageResult> SendMessageAsync(NewMessageBody body, long? chatId = null, long? userId = null, bool disableLinkPreview = false, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SendMessageResult>(HttpMethod.Post, "/messages", body, new Dictionary<string, string?>
        {
            ["chat_id"] = chatId?.ToString(CultureInfo.InvariantCulture),
            ["user_id"] = userId?.ToString(CultureInfo.InvariantCulture),
            ["disable_link_preview"] = disableLinkPreview ? "true" : null
        }, cancellationToken);
    }

    public Task<SimpleQueryResult> EditMessageAsync(string messageId, NewMessageBody body, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Put, "/messages", body, new Dictionary<string, string?> { ["message_id"] = messageId }, cancellationToken);
    }

    public Task<SimpleQueryResult> DeleteMessageAsync(string messageId, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Delete, "/messages", null, new Dictionary<string, string?> { ["message_id"] = messageId }, cancellationToken);
    }

    public Task<VideoAttachmentDetails> GetVideoDetailsAsync(string videoToken, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<VideoAttachmentDetails>(HttpMethod.Get, $"/videos/{Uri.EscapeDataString(videoToken)}", null, null, cancellationToken);
    }

    public Task<SimpleQueryResult> AnswerOnCallbackAsync(string callbackId, CallbackAnswer answer, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Post, "/answers", answer, new Dictionary<string, string?> { ["callback_id"] = callbackId }, cancellationToken);
    }
}
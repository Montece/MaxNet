using MaxNet.Models.Messages;
using MaxNet.Models.Videos;

namespace MaxNet.Client.Abstraction;

public interface IMessagesModule : IModule
{
    Task<MessageList> GetMessagesAsync(long? chatId = null, IEnumerable<string>? messageIds = null, long? from = null, long? to = null, int? count = null, CancellationToken cancellationToken = default);

    Task<Message> GetMessageByIdAsync(string messageId, CancellationToken cancellationToken = default);

    Task<SendMessageResult> SendMessageAsync(NewMessageBody body, long? chatId = null, long? userId = null, bool disableLinkPreview = false, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> EditMessageAsync(string messageId, NewMessageBody body, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> DeleteMessageAsync(string messageId, CancellationToken cancellationToken = default);

    Task<VideoAttachmentDetails> GetVideoDetailsAsync(string videoToken, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> AnswerOnCallbackAsync(string callbackId, CallbackAnswer answer, CancellationToken cancellationToken = default);
}
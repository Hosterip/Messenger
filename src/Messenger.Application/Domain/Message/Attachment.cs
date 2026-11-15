using ErrorOr;

namespace Messenger.Application.Domain;

public readonly record struct Metadata(

    // Width and Height are in pixels
    int? Width,
    int? Height,
    long? Duration); // Stored in milliseconds

public sealed class Attachment
{
    private Attachment()
    {
    }

    private Attachment(
        string url,
        string previewUrl,
        long fileSize,
        string fileName,
        string filePath,
        string mimeType,
        Metadata metadata,
        Message message)
    {
        this.Id = Guid.NewGuid();
        this.Url = url;
        this.PreviewUrl = previewUrl;
        this.FileSize = fileSize;
        this.FileName = fileName;
        this.FilePath = filePath;
        this.MimeType = mimeType;
        this.Metadata = metadata;
        this.Message = message;
        this.MessageId = message.Id;
    }

    public Guid Id { get; private init; }
    public string Url { get; private set; }
    public string? PreviewUrl { get; private set; }
    public long FileSize { get; private set; }
    public string FileName { get; private set; }
    public string FilePath { get; private set; }
    public string MimeType { get; private set; }
    public Metadata Metadata { get; private set; }
    public Message Message { get; private init; }
    public Guid MessageId { get; private init; }

    public static ErrorOr<Attachment> Create(
        in string url,
        in string previewUrl,
        in long fileSize,
        in string fileName,
        in string filePath,
        in string mimeType,
        in Metadata metadata,
        in Message message)
    {
        // Initializing Attachment
        var attachment = new Attachment(
            url,
            previewUrl,
            fileSize,
            fileName,
            filePath,
            mimeType,
            metadata,
            message);

        return attachment
            .ToErrorOr();
    }
}
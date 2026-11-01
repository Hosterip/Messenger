using ErrorOr;

namespace Messenger.Application.Domain;

public readonly record struct Metadata(
    // Width and Height are in pixels
    int? Width,
    int? Height,
    long? Duration // Stored in milliseconds
    );

public sealed class Attachment
{
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
    
    private Attachment () {}

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
        Id = Guid.NewGuid();
        Url = url;
        PreviewUrl = previewUrl;
        FileSize = fileSize;
        FileName = fileName;
        FilePath = filePath;
        MimeType = mimeType;
        Metadata = metadata;
        Message = message;
        MessageId = message.Id;
    }

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
            url: url,
            previewUrl: previewUrl,
            fileSize: fileSize,
            fileName: fileName,
            filePath: filePath,
            mimeType: mimeType,
            metadata: metadata,
            message: message);
        
        return attachment
            .ToErrorOr();
    }
}
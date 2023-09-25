using Resort.Domain.SharedKernel;

namespace Resort.Domain.Document;

public class Document: AggregateRoot<Guid>
{
    private Document()
    {
        
    }

    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Extension { get; private set; }
    public long Size { get; private set; }
    public string Path { get; private set; }

    public Document(Guid id, string name, string type, string extension, long size, string path)
        : base(id)
    {
        Name = name;
        Type = type;
        Extension = extension;
        Size = size;
        Path = path;
    }
}
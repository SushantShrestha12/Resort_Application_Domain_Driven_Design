using MediatR;
using Resort.Domain.Document;
using Resort.Infrastructure;

namespace Resort.Application.Documents;

public class DocumentCreateRequest: IRequest<Document>
{
    public string Name { get;  set; }
    public string Type { get;  set; }
    public string Extension { get;  set; }
    public long Size { get;  set; }
    public string Path { get;  set; }
}

public class DocumentCreateRequestHandler : IRequestHandler<DocumentCreateRequest, Document>
{
    private readonly ResortDbContext _context;

    public DocumentCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Document> Handle(DocumentCreateRequest request, CancellationToken cancellationToken)
    {
        Guid documentId = new Guid();
        Document document = new Document(documentId, request.Name, request.Type,
            request.Extension, request.Size, request.Path);

        _context.Documents.Add(document);
        await _context.SaveChangesAsync(cancellationToken);

        return document;
    }
}

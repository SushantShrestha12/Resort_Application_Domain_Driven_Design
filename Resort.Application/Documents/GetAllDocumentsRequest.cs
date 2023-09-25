using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Document;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class GetAllDocumentsRequest : IRequest<List<Document>>
{
    
}

public class GetAllDocumentRequestHandler : IRequestHandler<GetAllDocumentsRequest, List<Document>>
{
    private readonly  ResortDbContext _context;

    public GetAllDocumentRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Document>> Handle(GetAllDocumentsRequest request, CancellationToken cancellationToken)
    {
        return await _context.Documents.ToListAsync();
    }
}
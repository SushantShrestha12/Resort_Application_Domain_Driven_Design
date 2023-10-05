using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Documents;
using Resort.Application.Firms;
using Resort.UI.Contracts.Tokens;

namespace Resort.UI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly AccessTokenExpireCheck _accessTokenExpireCheck;

    public DocumentsController(IMediator mediator, AccessTokenExpireCheck accessTokenExpireCheck)
    {
        _accessTokenExpireCheck = accessTokenExpireCheck;
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IResult> UploadDocument(IFormFile file)
    {
        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();

        if (!tokenNotExpired) return Results.BadRequest("Token Expired");
        
        var fileName = Path.GetFileName(file.FileName);
        var fileType = file.ContentType;
        var fileExtension = Path.GetExtension(fileName);
        var fileSize = file.Length;
        var filePath = Path.Combine("/Users/sushantshrestha/desktop/ResortClient", fileName);
        
         using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var command = new DocumentCreateRequest
        {
            Name = fileName,
            Type = fileType,
            Extension = fileExtension,
            Size = fileSize,
            Path = filePath
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
    
    [HttpGet]
    public async Task<IResult> GetDocument()
    {
        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();

        if (!tokenNotExpired) return Results.BadRequest("Token Expired");
        
        var result = await _mediator.Send(new GetAllDocumentsRequest());
        return Results.Ok(result);
    }
}
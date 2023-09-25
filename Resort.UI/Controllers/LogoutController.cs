using Microsoft.AspNetCore.Mvc;
using Resort.Domain;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class LogoutController: ControllerBase
{
    // private const string AccessSecretKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI1YzU0ZjMzNi1kNGZmLTRmY2QtYTFkZi0zNzU2NWY5NzAwMmYiLCJ1bmlxdWVfbmFtZSI6IlN1c2hhbnQiLCJlbWFpbCI6IlN1c2hhbnQiLCJqdGkiOiJiZDQxZjhmMS1hYzkwLTRkZTMtYjBiMy1mNDc3N2JhZDUyMDMiLCJuYmYiOjE2OTUzODIzNjQsImV4cCI6MTY5NTM4Mjk2NCwiaWF0IjoxNjk1MzgyMzY0LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUxOTQiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUxOTQifQ.qLslxPCZQHbsXiRNnbLsIbhxj6ZPIYCH3eFwYhfiOis";

    
    [HttpPost]
    public async Task<bool> Logout()
    {
        // TokenBlackList tokenBlackList = new TokenBlackList();
        // tokenBlackList.BlacklistToken(AccessSecretKey);
        return true;
    }
}
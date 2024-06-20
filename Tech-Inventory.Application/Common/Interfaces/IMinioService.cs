using Microsoft.AspNetCore.Http;
using Tech_Inventory.Application.Common.Helpers;

namespace Tech_Inventory.Application.Common.Interfaces;

public interface IMinioService
{
    Task<string> PutObject(IFormFile file);
    Task<bool> RemoveObject(string token);
    Task<GetObjectDto> GetObject(string token);

}

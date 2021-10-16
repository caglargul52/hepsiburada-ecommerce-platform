using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommercePlatform.Application.Interfaces.Services
{
    public interface IFileService
    {
        Task<List<string>> ReadFileAsync(string path);
    }
}

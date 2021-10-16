using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ECommercePlatform.Application.Interfaces.Services;

namespace ECommercePlatform.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public async Task<List<string>> ReadFileAsync(string path)
        {
            var list = new List<string>();

            try
            {
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using var streamReader = new StreamReader(fileStream, Encoding.UTF8);
                string line;

                while ((line = await streamReader.ReadLineAsync()) != null)
                {
                    list.Add(line);
                }

                return list;
            }
            catch
            {
                return list;
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace SocialNetwork.Common.Helpers
{
    public static class FileConvertor
    {
        public static async Task<byte[]> ConvertImageToByte(this IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Helpers.FileHelper
{
    public static class ImageHelper
    {
        public static string UploadPicture(this IFormFile file, string webRootPath)
        {
            var path = "/images/" + Guid.NewGuid().ToString() + file.FileName;
            using (var fileStream = new FileStream(webRootPath + path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return path;
        }
    }
}

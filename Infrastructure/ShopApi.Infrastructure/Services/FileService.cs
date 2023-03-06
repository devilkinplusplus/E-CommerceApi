using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Infrastructure.Services
{
    public class FileService 
    {
       
        private async Task<string> FileRenameAsync(string path ,string fileName)
        {
            string newFileName = await Task.Run<string>(async () =>
            {
                string extension = Path.GetExtension(fileName);
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                DateTime datetimenow = DateTime.UtcNow;
                string datetimeutcnow = datetimenow.ToString("yyyyMMddHHmmss");
                string newFileName = $"{datetimeutcnow}{NameOperation.CharacterRegulatory(oldName)}{extension}";

                if (File.Exists($"{path}\\{newFileName}"))
                    return await FileRenameAsync(path, newFileName);
                else
                    return newFileName;
            });
            return newFileName;
        }
        
    }
}

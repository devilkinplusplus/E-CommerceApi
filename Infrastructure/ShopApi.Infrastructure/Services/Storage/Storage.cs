using ShopApi.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Infrastructure.Services.Storage
{
    public class Storage
    {
        protected delegate bool HasFile(string pathOrContainerName, string fileName);
        protected async Task<string> FileRenameAsync(string pathOrContainerName, string fileName,HasFile hasFileMethod)
        {
            string newFileName = await Task.Run<string>(async () =>
            {
                string extension = Path.GetExtension(fileName);
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                DateTime datetimenow = DateTime.UtcNow;
                string datetimeutcnow = datetimenow.ToString("yyyyMMddHHmmss");
                string newFileName = $"{datetimeutcnow}{NameOperation.CharacterRegulatory(oldName)}{extension}";

                if (hasFileMethod(pathOrContainerName, newFileName))
                    return await FileRenameAsync(pathOrContainerName, newFileName,hasFileMethod);
                else
                    return newFileName;
            });
            return newFileName;
        }
    }
}

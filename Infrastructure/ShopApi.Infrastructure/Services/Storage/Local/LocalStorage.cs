using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShopApi.Application.Abstractions.Storage;
using ShopApi.Application.Abstractions.Storage.Local;
using ShopApi.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment) => _webHostEnvironment = webHostEnvironment;

        public async Task DeleteAsync(string path, string fileName) => File.Delete($"{path}\\{fileName}");

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName) => File.Exists($"{path}\\{fileName}");

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            //eger bele bir path yoxdursa yarat
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> data = new();
            foreach (IFormFile file in files)
            {
                string newFileName = await FileRenameAsync(path, file.FileName, HasFile);
                string fullPath = Path.Combine(uploadPath, newFileName);

                await CopyFileAsync(fullPath, file);
                data.Add((newFileName, path));
            }

            return data;
        }




        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1048 * 1048, false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }

    }
}

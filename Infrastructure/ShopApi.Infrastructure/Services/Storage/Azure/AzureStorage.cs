using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShopApi.Application.Abstractions.Storage.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : Storage, IAzureStorage
    {
        private readonly BlobServiceClient _blobServiceClient; //azure accountuna bağlanmaq üçün 
        private BlobContainerClient _blobContainerClient; //azure containerində fayl əməliyyatları üçün
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }

        public async Task DeleteAsync(string container, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string container)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
            return _blobContainerClient.GetBlobs().Select(x => x.Name).ToList();
        }

        public bool HasFile(string container, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
            return _blobContainerClient.GetBlobs().Any(x => x.Name == fileName);
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string container, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainerName)> data = new();

            foreach (IFormFile file in files)
            {
                string newFileName = await FileRenameAsync(container, file.Name, HasFile);
                BlobClient blobClient = _blobContainerClient.GetBlobClient(newFileName);
                await blobClient.UploadAsync(file.OpenReadStream());
                data.Add((newFileName, $"{container}/{newFileName}"));
            }
            return data;

        }
    }
}

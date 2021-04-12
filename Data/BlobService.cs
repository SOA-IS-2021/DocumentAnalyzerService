using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using DocumentAnalyzerService.Models;
using DocumentAnalyzerService.Services;

namespace DocumentAnalyzerService.Data
{
    /**
     * @source: https://blog.docubear.com/c-how-to-read-and-write-to-azure-blob-storage/
     */
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobServiceClient;
 
        public BlobService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }
 
        public async Task<bool> DoesBlobExists(string fileName, BlobContainer container)
        {
            var containerClient = GetContainerClient(container);
            var blobClient = containerClient.GetBlobClient(fileName);
 
            return await blobClient.ExistsAsync();
        }

        public ICollection<string> GetFilesNames(BlobContainer container)
        {
            var containerClient = GetContainerClient(container);
            var filesNames = containerClient.GetBlobs().Select(blobItem => blobItem.Name).ToList();
            return filesNames;
        }

        public async Task UploadFileBlobAsync(byte[] content, string fileName, BlobContainer container)
        {
            using (Stream stream = new MemoryStream(content))
            {
                var containerClient = GetContainerClient(container);
                var blobClient = containerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(stream);
            }
        }
 
        public async Task<byte[]> GetFileBlobAsync(string fileName, BlobContainer container)
        {
            var containerClient = GetContainerClient(container);
            var blobClient = containerClient.GetBlobClient(fileName);
 
            if (await blobClient.ExistsAsync())
            {
                var response = await blobClient.DownloadAsync();
 
                using (var stream = new MemoryStream())
                {
                    response.Value.Content.CopyTo(stream);
 
                    return stream.ToArray();
                }
            }
            else
            {
                return null;
            }
        }
 
        private BlobContainerClient GetContainerClient(BlobContainer container)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(container.ToString());
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;
        }
 
        public async Task DeleteFromBlob(string fileName, BlobContainer container)
        {
            var containerClient = GetContainerClient(container);
            var blobClient = containerClient.GetBlobClient(fileName);
            if (await blobClient.ExistsAsync())
            {
                await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            }
        }
    }
}
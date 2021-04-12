using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentAnalyzerService.Models;

namespace DocumentAnalyzerService.Services
{
    public interface IBlobService
    {
        Task UploadFileBlobAsync(byte[] content, string fileName, BlobContainer container);
        Task<byte[]> GetFileBlobAsync(string fileName, BlobContainer container);
        Task<bool> DoesBlobExists(string fileName, BlobContainer container);
        ICollection<string> GetFilesNames(BlobContainer container);
        Task DeleteFromBlob(string fileName, BlobContainer container);
    }
}
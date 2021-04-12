using System.Collections.Generic;
using DocumentAnalyzerService.Models;

namespace DocumentAnalyzerService.Services.Interfaces
{
    // Uploads/downloads files to/from the Azure Object Storage
    public interface IFilePublisher
    {
        // Upload file
        public void UploadFile(string fileName, byte[] file);

        // Download file
        public FileProcessed GetFile(string fileName);

        // Gets all files names
        public List<string> GetFilesNames();
    }
}
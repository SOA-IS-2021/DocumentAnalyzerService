using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DocumentAnalyzerService.Services
{
    // Uploads/downloads files to/from the Azure Object Storage
    public interface IFilePublisher
    {
        // Upload file
        public void UploadFile(Blob file);

        // Download file
        public Blob GetFile(string fileName);

        // Gets all files names
        public List<string> GetFilesNames();
    }
}
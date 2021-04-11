using System.Reflection.Metadata;

namespace DocumentAnalyzerService.Services
{
    // Uploads/downloads files to/from the Azure Object Storage
    public interface IFilePublisher
    {
        public void UploadFile(Blob file);

        public Blob GetFile(string fileName);
    }
}
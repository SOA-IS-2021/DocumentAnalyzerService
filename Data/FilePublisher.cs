using System.Collections.Generic;
using System.Reflection.Metadata;
using DocumentAnalyzerService.Services;

namespace DocumentAnalyzerService.Data
{
    public class FilePublisher: IFilePublisher
    {
        public void UploadFile(Blob file)
        {
            throw new System.NotImplementedException();
        }
        
        public List<string> GetFilesNames()
        {
            throw new System.NotImplementedException();
        }

        public Blob GetFile(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}
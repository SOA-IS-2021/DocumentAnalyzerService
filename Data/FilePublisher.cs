using System;
using System.Collections.Generic;
using Azure.Storage.Blobs;
using DocumentAnalyzerService.Models;
using DocumentAnalyzerService.Services;
using DocumentAnalyzerService.Services.Interfaces;

namespace DocumentAnalyzerService.Data
{
    public class FilePublisher: IFilePublisher
    {
        private const BlobContainer BlobContainer = Models.BlobContainer.documents;
        private const string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=documentanalyzer2;AccountKey=35oiYj9BMx99zwV+Wk4nAlnIUlTWLOENmnfGYp7Gij/QrTc4lXjTEPYjdEZsK49HUmVceLSdEiDcWl8sEJoEyA==;EndpointSuffix=core.windows.net";
        private readonly BlobService blobService = new(new BlobServiceClient(ConnectionString));
        
        /*
         * Uploads the file data to the BlobService
         */
        public void UploadFile(string fileName, byte[] file)
        {
            blobService.UploadFileBlobAsync(file, fileName, BlobContainer);
        }
        
        /*
         * Gets the names of all files in the DB
         */
        public List<string> GetFilesNames()
        {
            return blobService.GetFilesNames(BlobContainer) as List<string>;
        }

        /*
         * Downloads an specific file by its name
         */
        public FileProcessed GetFile(string fileName)
        {
            var data = blobService.DoesBlobExists(fileName, BlobContainer).Result;
            Console.WriteLine(data);
            return null;
        }
    }
}
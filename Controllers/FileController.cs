using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection.Metadata;
using DocumentAnalyzerService.Data;
using DocumentAnalyzerService.Models;

namespace DocumentAnalyzerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private static List<File> files;
        
        private readonly ILogger<FileController> _logger;
        
        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        [Route("/employees-in-file")]
        public string GetEmployeesInFile(string fileName)
        {
            return new DbManager().GetProcessedFile(fileName);
        }
        
        [HttpGet]
        [Route("/files")]
        public List<string> GetFiles()
        {
            return new FilePublisher().GetFilesNames();
        }
        
        [HttpPost]
        [Route("/file-processed")]
        public void PostProcessedFile(File file)
        {
            new DbManager().PostProcessedFile(file);
        }
        
        [HttpPost]
        [Route("/file")]
        public void PostFile(Blob file)
        {
            new FilePublisher().UploadFile(file);
        }
    }
}
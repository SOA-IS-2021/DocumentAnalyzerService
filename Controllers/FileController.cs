using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using DocumentAnalyzerService.Data;
using DocumentAnalyzerService.Models;

namespace DocumentAnalyzerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private static List<FileProcessed> files;
        
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
        [Route("/employees-names")]
        public List<Employee> GetEmployeesNames()
        {
            return new DbManager().GetEmployees();
        }
        
        [HttpGet]
        [Route("/processed-files-names")]
        public List<string> GetFilesNames()
        {
            return new FilePublisher().GetFilesNames();
        }

        [HttpPost]
        [Route("/file")]
        public void PostFile(File file)
        {
            var data = Encoding.UTF8.GetBytes(file.Data);
            new FilePublisher().UploadFile(file.Name, data);
        }
    }
}
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentAnalyzerService;
using edu.stanford.nlp.ie.crf;
using System.IO;
using System.Xml.Serialization;
using NLP_Demo.Models;


namespace DocumentAnalyzerServices
{
    public class Program
    {

        


        public static void Main(string[] args)
        {
            //Biblioteca
            string classifiersDirecrory = Environment.CurrentDirectory + @"\stanford-ner-2016-10-31\classifiers";
            CRFClassifier classifier = CRFClassifier.getClassifierNoExceptions(Path.Combine(classifiersDirecrory, "english.muc.7class.distsim.crf.ser.gz"));

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

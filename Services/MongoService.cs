using System;
using DocumentAnalyzerService.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DocumentAnalyzerService.Services
{
    public class MongoService
    {
        public static readonly MongoService Instance = new MongoService();
        
        // your connection string
        private const string ConnectionString = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false";

        // Private constructor
        private MongoService() { }
        
        /**
         * Finds the file that matches the fileName
         */
        public string FindProcessedFile(string fileName)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("analyzerdb");
            var files = db.GetCollection<BsonDocument>("files");

            var filter = Builders<BsonDocument>.Filter.Eq("fileName", fileName);
            var @event = files.Find(filter);
            var result = @event.First();
            return result[2].ToJson();
        }

        /**
         * Saves the processed file to Mongo DB
         */
        public void InsertProcessedFile(FileProcessed fileProcessed)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("analyzerdb");
            var files = db.GetCollection<FileProcessed>("files");
            
            files.InsertOne(fileProcessed);
        }
    }
}
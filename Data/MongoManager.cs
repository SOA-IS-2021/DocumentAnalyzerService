﻿using System;
using System.Threading.Tasks;
using DocumentAnalyzerService.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DocumentAnalyzerService.Data
{
    public class MongoManager
    {
        public static readonly MongoManager Instance = new MongoManager();
        
        // your connection string
        private const string ConnectionString = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false";

        // Private constructor
        private MongoManager() { }
        
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
            return @event.First().ToJson();
        }

        /**
         * Saves the processed file to Mongo DB
         */
        public void SaveProcessedFile(File file)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("analyzerdb");
            var files = db.GetCollection<BsonDocument>("files");
        }
    }
}
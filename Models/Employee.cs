﻿namespace DocumentAnalyzerService.Models
{
    public class Employee
    {
        public Employee(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
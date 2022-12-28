using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBTest{

    public class Student 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        public string FirstName {get; set;}
        public string LastName{get ; set;}
        public string Education{get;set;}
    }

    class Program 
    {
        static void Main (string [] args)
        {
              
              List<Student> list =new List<Student>();

              var _mongoClient= new MongoClient("mongodb://localhost:27017");
              var db = _mongoClient.GetDatabase("Transflower");
              var collections = db.GetCollection<Student>("Students");

              collections.Find(_ => true).ToList().ForEach(student => 
              {
                Console.WriteLine(student.Id);
                Console.WriteLine(student.FirstName);
                Console.WriteLine(student.LastName);
                Console.WriteLine(student.Education);
              });
        }
    }
}
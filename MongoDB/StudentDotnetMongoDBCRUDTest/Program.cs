using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SMCRUD
{
    public class Student
    {
        public ObjectId Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Education { get; set; }

    }

    public class Program
    {

        protected static IMongoClient? client;
        protected static IMongoDatabase? database;

        public static Student GetStudent()
        {
            Console.WriteLine("Please Enter Student First Name");
            string? firstName = Console.ReadLine();

            Console.WriteLine("Please Enter Student Last name");
            string? lastName = Console.ReadLine();

            Console.WriteLine("Please Enter Studenmt Education");
            string? education = Console.ReadLine();

            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Education = education
            };
            return student;
        }

        public static void CRUDwithMongoDB()
        {
            client = new MongoClient();
            database = client.GetDatabase("Transflower");
            var collection = database.GetCollection<Student>("Students");

            Console.WriteLine("Pless Select Your option From Following \n1 -Insert\n2 - Update\n3 -Delete\n4 -All\n");
            string? UserSelection = Console.ReadLine();

            switch (UserSelection)
            {
                case "1":
                    //Insert
                    collection.InsertOne(GetStudent());
                    break;

                case "2":
                    //Update 
                    var obj1 = GetStudent();
                    collection.FindOneAndUpdate<Student>  
                        (   Builders<Student>.Filter.Eq("FirstName", obj1.FirstName),  
                            Builders<Student>.Update.Set("LastName", obj1.LastName).Set("Education", obj1.Education));  
                    break; 

                case "3":
                    //Find and Delete
                    Console.WriteLine("Please Enter the first name to delete the record(so called document) : ");
                    var deleteFirstName = Console.ReadLine();
                    collection.DeleteOne(s => s.FirstName == deleteFirstName);
                    break;

                case "4":
                    //Read All Existing Documents
                    var all = collection.Find(new BsonDocument());
                    Console.WriteLine();
                    foreach (var i in all.ToEnumerable())
                    {
                        Console.WriteLine(i.Id + " " + i.FirstName + "\t" + i.LastName + "\t" + i.Education);
                    }
                    break;

                default:
                    Console.WriteLine("Please Choose Cprrect Option");
                    break;
            }

            //To Continue Program
            Console.WriteLine("\n----------------------------\nPress Y for continue..\n");
            string? userChoice = Console.ReadLine();

            if (userChoice == "Y" || userChoice == "y")
            {
                CRUDwithMongoDB();
            }
        }

        static void Main(string[] args)
        {
            CRUDwithMongoDB();
        }
    }


}

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace SerializationTest
{

    // decorator-------typescript
    //annotation-------java
    //attributes-------c#
    //metadata---------data about data , extra information about an entity products
    [Serializable]
    public class Product
    {
        public int Likes { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            //First Part : Creating Collection

            Product theProduct = new Product();
            //Real World Object
            //Entity 1

            theProduct.Id = 34;
            theProduct.Title = "Gerbera";
            theProduct.Description = "Weeding Flower";
            theProduct.UnitPrice = 5;
            theProduct.Quantity = 126;
            theProduct.Likes = 4000;
            theProduct.ImageUrl = "/inage/gerbera.jpeg";

            //Entity 2
            Product theProduct1 = new Product();

            theProduct1.Id = 30;
            theProduct1.Title = "Tulip";
            theProduct1.Description = "Best Flower";
            theProduct1.Quantity = 200;
            theProduct1.Likes = 2000;
            theProduct1.ImageUrl = "/image/tulip.jpeg";


            //Container : consist of two product instance 
            List<Product> products = new List<Product>();

            products.Add(theProduct);
            products.Add(theProduct1);

            //Property Initilizer syntax
            products.Add(new Product { Id = 35, Title = "Carnation", Description = "White wash Flower", UnitPrice = 10, Quantity = 10000, Likes = 54000, ImageUrl = "/images/gerbera.jpg" });
            products.Add(new Product { Id = 35, Title = "Lily", Description = "Delicate Flower", UnitPrice = 10, Quantity = 10000, Likes = 54000, ImageUrl = "/images/lily.jpg" });
            products.Add(new Product { Id = 35, Title = "Lotus", Description = "Worship Flower", UnitPrice = 10, Quantity = 10000, Likes = 54000, ImageUrl = "/images/lotus.jpg" });
            products.Add(new Product { Id = 35, Title = "Marigold", Description = "Festival Flower", UnitPrice = 10, Quantity = 10000, Likes = 54000, ImageUrl = "/images/marigold.jpg" });
            products.Add(new Product { Id = 35, Title = "Rose", Description = "Valentine Flower", UnitPrice = 10, Quantity = 10000, Likes = 54000, ImageUrl = "/images/rose.jpg" });
            products.Add(new Product { Id = 35, Title = "Tulip", Description = "Kashmir Flower", UnitPrice = 10, Quantity = 10000, Likes = 54000, ImageUrl = "/images/tulip.jpg" });
            products.Add(new Product { Id = 35, Title = "Auster", Description = "Beautiful   Flower", UnitPrice = 10, Quantity = 10000, Likes = 54000, ImageUrl = "/images/auster.jpg" });


            //Presentation Logic
            foreach (Product product in products)
            {
                //bind your data with console output stream
                //Dynamic data binding with console UI
                Console.WriteLine($" Flower : {product.Title} : {product.Description} : {product.Likes}");
            }

            //store all these flowers into files
            //Persistance : Serialization
            //store state of object into file
            //file should be binary
            //while dealing with system resources
            //file ,stream, database, socket, external web API
            //etc.
            //Use Exception Handling

            //Logic for Serialization

            //Second part : Serialization Using Bainary Files

            try
            {
                Stream stream = new FileStream("products.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                BinaryFormatter formatter = new BinaryFormatter();
                // first parameter------------destination
                // second parameter ----------data
                formatter.Serialize(stream, products);
                stream.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }

            //Logic for Deserialization
            Console.WriteLine("After Deserialization, retrived products....");
            try
            {
                BinaryFormatter formater = new BinaryFormatter();
                Stream stream = new FileStream("products.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                List<Product> productsFromFile = (List<Product>)formater.Deserialize(stream);

                foreach (Product product in productsFromFile)
                {
                    Console.WriteLine($" Flower : {product.Title} : {product.Description} : {product.Likes}");
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            finally { }




            //Third Part : Serialization Using Json File
            //cross platform data storage using universal file format : JSON
            //JSON : Javascript Object Nation (JSON)
            //JSON file is independent of any technology
            //Java application , Javascript application , c++, .NET framework,
            //Mobile application 
            //Inbuilt GoogleApp  -------Spreadsheet -------

            //[
            //   {id:23, title:"Gerbera", description:"best flower "},
            //   {id:23, title:"Gerbera", description:"best flower "},
            //   {id:23, title:"Gerbera", description:"best flower "}
            //]

            try
            {

                // dynamic data type variable
                var option = new JsonSerializerOptions { IncludeFields = true };
                var productJson = JsonSerializer.Serialize<List<Product>>(products, option);
                string FileName = "products.json";
                File.WriteAllText(FileName, productJson);


                //Deserialization from JSON file
                string jsonString = File.ReadAllText(FileName);
                List<Product> jsonProducts = JsonSerializer.Deserialize<List<Product>>(jsonString);
                Console.WriteLine("Deserializing data from json file");

                foreach (Product product in jsonProducts)
                {
                    Console.WriteLine($"{product.Title} : {product.Description}");
                }


            }
            catch (Exception e)
            {
                throw e;
            }
            finally { }








            Console.WriteLine("Hello, World!");

        }
    }
}



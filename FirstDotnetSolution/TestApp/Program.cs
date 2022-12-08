using CatalogLib;
using OrderProcessingLib;
using CRMLib;
using MySqlDBManagerLib;



Console.WriteLine("Showing Products Result....");
Product p1=new Product();
p1.Id=11;
p1.Title="Roses";
p1.Description="Valentine Flowers";
p1.UnitPrice=25;
p1.StockAvailalbe=500;
p1.ImageUrl="http://TransFlowers/logo.jpeg";

Console.WriteLine(p1.Title + " " + p1.Description + "  "+ p1.StockAvailalbe + "  "+p1.ImageUrl);




Console.WriteLine("Showing Orders Result....");
Orders o1=new Orders();
o1.OrderId=45;
o1.OrderDate=new DateTime(2022,12,8);  // yyyy-mm-dd
o1.Customer="Microsoft";
o1.TotalAmount=670000;
o1.Status="approved";

Console.WriteLine(o1.Customer + " " + o1.OrderDate + "  "+ o1.TotalAmount + o1.Status);



Console.WriteLine("Showing Customers Result....");
Customers c1=new Customers();
c1.ID=564;
c1.FirstName="Salil";
c1.Lastname="Mankar";
c1.Email="salil.mankar@gmail.com";
c1.ContactNumber="9886745376";

Console.WriteLine(c1.FirstName + " "+ c1.Lastname);






Console.WriteLine("Showing MySqlDBManager Result....");
// Creating table
//MySQLDBManager.CreateTable();



// Inserting data into table
//MySQLDBManager.Insert("Akash","Ajab","M.Tech");
//MySQLDBManager.Insert("Akshay","Tanpure","B.COM");
//MySQLDBManager.Insert("Rohit","Gore","B.Tech");


//Updating into students
//MySQLDBManager.Update(1,"Rushikesh ","Chikane "," BE");

//deleting from students
//MySQLDBManager.Delete(6);

//Showing studentslist from students
//MySQLDBManager.ShowAllStudents();

//show student by id
MySqlDBManager.ShowStudentById(1);
MySqlDBManager.ShowStudentById(3);
MySqlDBManager.ShowStudentById(4);

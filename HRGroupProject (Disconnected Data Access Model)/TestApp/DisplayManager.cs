using DAL;
using BOL;
namespace UI;

public class DisplayManager
{

    public static void ShowMainMenu()
    {
        Console.WriteLine("Transflower Option");
        Console.WriteLine();
        Console.WriteLine("Choose Option :");
        Console.WriteLine();
        Console.WriteLine("0.***Exit***");
        Console.WriteLine("1.Department");
        Console.WriteLine("2.Employee");
        Console.WriteLine("3.Roles");
        Console.WriteLine();
        Console.WriteLine("Enter Your Choice :");

    }

    public static void ShowDepartmentMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Choose Option :");
        Console.WriteLine();
        Console.WriteLine("0.***Exit***");
        Console.WriteLine("1.Show All Departments");
        Console.WriteLine("2.Show Department by Id");
        Console.WriteLine("3.Insert Departmet ");
        Console.WriteLine("4.Update Employee");
        Console.WriteLine("5.Delet Department");
        Console.WriteLine();
        Console.WriteLine("Enter Your Choice");
        Console.WriteLine("-------------------------");

    }






    // Department Fubctions

    public static void ShowAllDepartments()
    {
        List<Department> allDepartments = UIManager.GetAllDept();

        Console.WriteLine("Available Departments in Transflower ");
        foreach (Department dept in allDepartments)
        {

            Console.WriteLine(dept.Id + " " + dept.Name + " " + dept.Location);

        }

    }

    public static void ShowDepartmentById()
    {
        Console.WriteLine("Enter Department Id to be find");
        int id = int.Parse(Console.ReadLine());
        Department dept = UIManager.GetById(id);
        Console.WriteLine("department details");
        Console.WriteLine(dept.Id + " " + dept.Name + " " + dept.Location);
    }
 
   public static void InertDepartment()
   {
       Department dept =new Department();
       Console.WriteLine("Enter Departname");
       dept.Name=Console.ReadLine();
       Console.WriteLine("Enter Department Location");
       dept.Location=Console.ReadLine();
       UIManager.InsertDepartment(dept);
       Console.WriteLine("Department Added Successfully");
   }
    public static void DeleteDipartment()
    {
        Console.WriteLine("***Department Deletion***");
        ShowAllDepartments();
        Console.WriteLine("Enter Department Id to be Removed");
        int id = int.Parse(Console.ReadLine());
        UIManager.DeleteDipartment(id);

    }
    
    public static void UpdateDepartment()
    {
        Console.WriteLine("**Update Department**");
        ShowAllDepartments();
        Department dept=new Department();
        Console.WriteLine("Enter Department Id to be Updated");
        dept.Id =int.Parse(Console.ReadLine());
        Console.WriteLine(dept.Id+" "+dept.Name+" "+dept.Location);  
        Console.WriteLine("Enter FirstName");
        dept.Name=Console.ReadLine();
        Console.WriteLine("Enter Location");
        dept.Location=Console.ReadLine();
        UIManager.UpdateDepartment(dept);
    }



}


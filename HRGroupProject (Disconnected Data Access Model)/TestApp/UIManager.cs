namespace UI;
using BOL;
using DAL;

public class UIManager
{
    

    public static List<Department> GetAllDept()
    {
        return DBManager.GetAllDepartments();
    }

    public static Department GetById(int Id)
    {
        return DBManager.GetbyId(Id);
    }
    
    public static bool InsertDepartment(Department dept)
    {
        return DBManager.Insert(dept);
    }
    
    public static void UpdateDepartment(Department dept)
    {
        DBManager.Update(dept);
    }
       public static bool DeleteDipartment(int departmentId)
    {
       return DBManager.Delete(departmentId);
    }

    











}
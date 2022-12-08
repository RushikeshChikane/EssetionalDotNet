namespace MySqlDBManagerLib;
using MySql.Data.MySqlClient;
public class MySqlDBManager
{
        
    public static string conString = @"server=localhost; user=root; database=classicmodels; port=3306; password=password";


    public static bool CreateTable()
    {
        //code for creating table student
        bool status = false;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            /* DDL Command */
            string query = "CREATE TABLE students (studentid INT NOT NULL PRIMARY KEY AUTO_INCREMENT," +
                         " firstName VARCHAR(25)," +
                         " lastName VARCHAR(55)," +
                         " qualification VARCHAR(55)" +
                         ")";
            Console.WriteLine(query);
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);

        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public static bool Insert(string fname, string lname, string qual)
    {

        bool status = false;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            //DDL command

            string query = "INSERT INTO students (firstName, lastName, qualification) values('" + fname +
                                                                  "', '" + lname + "', '" + qual + "')";

            Console.WriteLine(query);
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            status = true;


        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

     public static bool Update(int id, string fname, string lname, string qual){

      bool status=false;
        
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            /* Update Command */
           string query="UPDATE students SET firstName= '"+fname+ "',"+
                        "lastName=  '"+lname+ "',"+
                        "qualification=  '"+qual+"'"+
                         " WHERE studentid=  "+id;
            Console.WriteLine(query);
            MySqlCommand cmd=new MySqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();  
            status=true;
        }
        catch(Exception ee){
            Console.WriteLine(ee.Message);
        }
        finally{
            con.Close();
        }
        return status;
    }

    public static bool Delete(int id){

        bool status=false;

        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{

            string query ="DELETE FROM students Where studentid ="+id;
            Console.WriteLine(query);
            MySqlCommand cmd=new MySqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();
            status=true;

        }catch(Exception ee){
            Console.WriteLine(ee.Message);
        }
        finally{
            con.Close();
        }
        return status;
    }

    public static void ShowAllStudents(){
        MySqlConnection con=new MySqlConnection();
        try{
            con.ConnectionString=conString;
            con.Open();
            string query = "SELECT * FROM students";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                {
                    //Console.WriteLine(rdr[0]+" -- "+rdr[1]+" -- "+rdr[2]+" -- "+rdr[4]);
                    Console.WriteLine(rdr["studentid"]+"***" + rdr["firstName"]+" -- "+rdr["lastName"]+" -- "+rdr["qualification"]+"'");
                }
                rdr.Close();
            }

        catch(Exception ee){
            Console.WriteLine("Exception :  "+ee.Message);
        }

        finally{
            con.Close();
        }

    }

    public static void ShowStudentById(int id){
        bool status = false;
        MySqlConnection con=new MySqlConnection();
        try{

            con.ConnectionString=conString;
            con.Open();
             string query = "select * from students where studentid="+id;
             MySqlCommand cmd=new MySqlCommand(query,con);
             MySqlDataReader rdr =cmd.ExecuteReader();
             if(rdr.Read()){
                Console.WriteLine(rdr["studentid"]+"  "+rdr["firstName"]+"  "+rdr["lastName"]+"  "+rdr["qualification"]);
             }
             con.Close();


        }
        catch(Exception ee){
            Console.WriteLine(ee.Message);
        }
        finally{
            con.Close();
        }

    }
}

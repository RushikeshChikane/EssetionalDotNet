using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using BOL;
namespace DAL;
public class DBManager
{
    private static string connetionString = string.Empty;
    private static object dt;

    static DBManager()
    {
        connetionString = "server=localhost;port=3306;user=root;password=password;database=transflower";
    }

    public static List<Department> GetAllDepartments()
    {
        List<Department> deparmnets = new List<Department>();
        //Disconnected Data Acces Architecture
        //by apply desing pattern
        //observer in object model
        //disconnected
        //connection, command, adapater, dataset, datarow
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connetionString;

        string query = "select * from departments";
        MySqlCommand cmd = new MySqlCommand(query, con as MySqlConnection);
        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);

        try
        {
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            foreach (DataRow datarow in dt.Rows)
            {
                int id = int.Parse(datarow["id"].ToString());
                string name = datarow["name"].ToString();
                string location = datarow["location"].ToString();

                Department dept = new Department
                {
                    Id = id,
                    Name = name,
                    Location = location
                };
                deparmnets.Add(dept);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        { }
        return deparmnets;
    }

    public static Department GetbyId(int id)
    {
        Department department = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connetionString;

        string query = "select * from departments where id=" + id;
        MySqlCommand cmd = new MySqlCommand(query, con as MySqlConnection);

        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);

            DataTable dt = ds.Tables[0];

            DataColumn[] keycolumn = new DataColumn[1];
            keycolumn[0] = dt.Columns["id"];
            dt.PrimaryKey = keycolumn;

            DataRow datarow = ds.Tables[0].Rows.Find(id);

            id = int.Parse(datarow["id"].ToString());
            string name = datarow["name"].ToString();
            string location = datarow["location"].ToString();

            department = new Department
            {
                Id = id,
                Name = name,
                Location = location,
            };
        }
        catch (Exception e)
        {
            throw e;
        }
        return department;

    }

    public static bool Delete(int departmentId)
    {
        bool status = false;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connetionString;
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "select * from departments";
        cmd.Connection = con;
        MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);

        DataSet ds = new DataSet();

        try
        {
            MySqlCommandBuilder cmdbldr = new MySqlCommandBuilder(da);

            da.Fill(ds);

            DataColumn[] keycolumns = new DataColumn[1];
            keycolumns[0] = ds.Tables[0].Columns["Id"];
            ds.Tables[0].PrimaryKey = keycolumns;

            DataRow datarow = ds.Tables[0].Rows.Find(departmentId);
            datarow.Delete();
            da.Update(ds);
            status = true;
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;

    }

    public static bool Insert(Department dept)
    {
        bool status = false;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connetionString;

        string query = "insert into departments (name,location)" +
                      " values('" + dept.Name + "','" + dept.Location + "')";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con as MySqlConnection;
        cmd.CommandText = query;

        MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
        DataSet ds = new DataSet();
        try
        {

            MySqlCommandBuilder cmdbldr = new MySqlCommandBuilder(da);
            MySqlCommand deletCommand = cmdbldr.GetDeleteCommand();
            string strDeleteCommand = deletCommand.CommandText;

            da.Fill(ds);

            DataRow newRow = ds.Tables[0].NewRow();
            newRow["id"] = dept.Id;
            newRow["name"] = dept.Name;
            newRow["Location"] = dept.Location;

            ds.Tables[0].Rows.Add(newRow);

            da.Update(ds);
            status = true;

        }
        catch (Exception e)
        {
            throw e;
        }


        return status;
    }

    public static bool Update(Department dept)
    {
        bool status = false;
        List<Department> allCustomers = new List<Department>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connetionString;

        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "update departments set name='" + dept.Name + "' , location ='" + dept.Location + "' where id=" + dept.Id;
        cmd.Connection = con as MySqlConnection;

        MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
        DataSet ds = new DataSet();
        try
        {
            MySqlCommandBuilder cmdbldr = new MySqlCommandBuilder(da);
            da.Fill(ds);

            DataColumn[] KeyColumn = new DataColumn[1];
            KeyColumn[0] = ds.Tables[0].Columns["id"];
            ds.Tables[0].PrimaryKey = KeyColumn;

            DataRow datarow = ds.Tables[0].Rows.Find(dept.Id);
            datarow["name"] = dept.Name;
            datarow["location"] = dept.Location;

            da.Update(ds);
        }
        catch (Exception e)
        {
            throw e;
        }

        return status;
    }



}

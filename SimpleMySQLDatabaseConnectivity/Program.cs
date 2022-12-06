using MySql.Data.MySqlClient;
using System;

//connecting with database.
String conStr ="server = localhost ; uid=root ;password =password; database=classicmodels ";

// creating object
MySqlConnection con = new MySqlConnection();


try {
    con.ConnectionString =conStr;
    con.Open();
    String query ="Select * from employees";
    MySqlCommand cmd =new MySqlCommand(query,con);
    MySqlDataReader rdr = cmd.ExecuteReader();

    while(rdr.Read()){
        Console.WriteLine(rdr[0]+" -- "+rdr[1]+" -- "+rdr[2]+" -- "+rdr[4]);
    }
    rdr.Close();

}catch(Exception ee){
    Console.WriteLine(ee.Message);

}
finally{
    con.Close();
}
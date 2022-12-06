using MySql.Data.MySqlClient;
using System;

MySqlConnection conn = new MySqlConnection();

conn.ConnectionString = "server=localhost;user=root;database=classicmodels;port=3306;password=password";



MySqlCommand cmd = new MySqlCommand();

try{
     Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "DROP PROCEDURE IF EXISTS add_emp";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DROP TABLE IF EXISTS emp";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE emp (" +
                                  "empno INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY," + 
                                  "first_name VARCHAR(20), last_name VARCHAR(20), birthdate DATE)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE PROCEDURE add_emp(" +
                                  "IN fname VARCHAR(20), IN lname VARCHAR(20), IN bday DATETIME, OUT empno INT)" +
                                  "BEGIN INSERT INTO emp(first_name, last_name, birthdate) " +
                                  "VALUES(fname, lname, DATE(bday)); SET empno = LAST_INSERT_ID(); END";

                cmd.ExecuteNonQuery();              

}
catch(MySqlException ex){
    Console.WriteLine("Error "+ ex.Number+"has occured:"+ex.Message);
}
conn.Close();



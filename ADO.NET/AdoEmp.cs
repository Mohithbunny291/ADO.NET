using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADO.NET
{
    internal class AdoEmp
    {
                
            static SqlConnection Connect()
            {
             //   SqlConnection c = new SqlConnection();
             //   c.ConnectionString = "Data Source=MOHITH-REDDY-EL;Initial Catalog=SampleMphasis;Integrated Security=True;Encrypt=False";//set
                SqlConnection connection = new SqlConnection("Data Source=MOHITH-REDDY-EL;Initial Catalog=SampleMphasis;Integrated Security=True;Encrypt=False");
                return connection;
            }
        public static void SelectEmp()
        {// connection
            SqlConnection c = Connect();
            c.Open();//must in connected data access
                     // select * , we are Command class
            SqlCommand command = new SqlCommand();
            command.Connection = c;// assign connection to command
                                   //what type of command normal query or SP
            command.CommandType = CommandType.Text;//query
            command.CommandText = "select * from t9";// all info best ExecuteReader(),returns datareader
            SqlDataReader reader = command.ExecuteReader();// reader is result
                                                           // check for row , then read from reader object one at a time
            if (reader.HasRows)
            {
                while (reader.Read() == true)
                {
                    Console.WriteLine("{0}\t {1}", reader[0], reader[1]);
                    //reader is one row at time
                }
            }
            c.Close();
            //SqlDataAdapter Obj = new SqlDataAdapter();
            //Obj.u
        }
            
        //public static void InsertEmp()
        //{
        //    SqlConnection c = Connect();
        //    c.Open();
        //    // next command for insert query
        //    SqlCommand command = new SqlCommand();
        //    //connection must be assigned to command
        //    command.Connection = c;
        //    command.CommandType = CommandType.Text;
        //    command.CommandText = "insert into t9 values (2,'Ram')";
        //    command.ExecuteNonQuery();// for all DML
        //    Console.WriteLine("Done");
        //    c.Close();// connected data access

            
        //}
        public static void InsertEmp()
        {
            SqlConnection c = Connect();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = c;
            command.CommandType = CommandType.Text;

            command.CommandText = "insert into t9 values(@id, @name);";

            SqlParameter pmId = new SqlParameter("@id", SqlDbType.Int);
            pmId.SourceColumn = "id";
            Console.WriteLine("enter id");

            pmId.Value = Convert.ToInt32(Console.ReadLine());//15 
            
            command.Parameters.Add(pmId);
            

            SqlParameter pmName = new SqlParameter("@name", SqlDbType.VarChar, 15, "name");
            //  pmName.Direction= ParameterDirection.Input;
            Console.WriteLine("enter your name");
            pmName.Value = Console.ReadLine();
            
            command.Parameters.Add(pmName);
            command.ExecuteNonQuery();
            c.Close();

        }

    }
    }

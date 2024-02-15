using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // DataSet, DataTable, DataRow, DataColumn.
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader, SqlDataAdapter, SqlCommandBuilder, SqlParameter.
using System.Configuration;

namespace ADO.NET
{
    internal class AdoNetDisconnected
    {


        static SqlConnection Connect()
        {
            string str = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = str;
            return conn;
        }


        

        public static void DmlByDataAdapter()
        {
            string empQuery = "select * from employees";
            using (SqlConnection conn = Connect())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empQuery, conn);
               
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);

                DataTable dt = ds.Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    Console.WriteLine("{0}\t{1}\t\t {2}\t\t\t {3}\t\t\t {4}\t\t{5}", item[0],item[1], item[2], item[3], item[4], item[5]);
                }

            }
        }

        public static void AdoNetDisConInsertEmp()
        {
            using(SqlConnection conn = Connect())
            {
                string query = "SELECT * FROM EMPLOYEES";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlDataAdapter);
                
            //int Id = Convert.ToInt32(Console.ReadLine());
            string FirstName = Console.ReadLine();
            string LastName = Console.ReadLine();
            string Gender = Console.ReadLine();
            string City = Console.ReadLine();
            string IsActive = Console.ReadLine();
            
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataRow dr = dataSet.Tables[0].NewRow();
                
                //dr[0] = Id;
                dr[1] = FirstName;
                dr[2] = LastName;
                dr[3] = Gender;
                dr[4] = City;
                dr[5] = IsActive;
                dataSet.Tables[0].Rows.Add(dr);
            sqlDataAdapter.Update(dataSet);
            
            //dataRow["FirstName"] = FirstName;
            //dataRow["LastName"] = LastName;
            //dataRow["Gender"] = Gender;
            //dataRow["City"] = City;
            //dataRow["IsActive"] = IsActive;

            //dt.Rows.Add(dataRow);
            }
            
        }

        public static void AdoNetDisConUpdateEmp(int EmpId)
        {
            using(SqlConnection conn = Connect())
            {
                SqlCommand sqlCommand = new SqlCommand("Select * from Employees", conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Employees");

                DataTable dataTable = dataSet.Tables["Employees"];

                DataRow[] foundRows = dataTable.Select($"Id = {EmpId}");

                DataRow dataRow = foundRows[0];

                Console.WriteLine("Enter Status of Employee");
                String StatusUpdate = Console.ReadLine();

               

                dataRow["IsActive"] = StatusUpdate;
                sqlDataAdapter.Update(dataSet, "Employees");
            }
        }

        public static void AdoNetDisConDelete(int empId)
        {
            using(SqlConnection conn = Connect())
            {
                SqlCommand sqlCommand = new SqlCommand("Select * from Employees", conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Employees");

                DataTable dataTable = dataSet.Tables["Employees"];

                DataRow dataRow = dataTable.Select($"Id = {empId}").FirstOrDefault();
                if ( dataRow != null )
                {
                    dataRow.Delete();

                    sqlDataAdapter.Update(dataSet, "Employees");
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    internal class AdoNetConnectioned
    {
        public static SqlConnection Connection()
        {
            SqlConnection conn = null;
            String str = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            conn = new SqlConnection(str);
            return conn;
        }

        // 1
        public static void AdoNetConnRead()
        {
            using (SqlConnection connection = new SqlConnection
                                                (ConfigurationManager.ConnectionStrings["ConnString"].ToString())) 
            {
                connection.Open();


                String cmd = "SELECT * FROM EMPLOYEES;";
                SqlCommand sqlCommand = new SqlCommand(cmd, connection); //connection.CreateCommand();
                //sqlCommand.CommandText = cmd;                
                
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                }
            }
        }

        // 3
        public static int AdoNetConnExeScalar()
        {
            SqlConnection connection = Connection();
            connection.Open();


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT COUNT(*) FROM EMPLOYEES";
            
            Object obj = sqlCommand.ExecuteScalar();
           

            connection.Close();
            
            return Convert.ToInt32(obj);
        }

        // 4.
        public static void AdoNetConnInsertEmployee()
        {
            using(SqlConnection connection =  Connection())
            {
                connection.Open();

                String query = "INSERT INTO EMPLOYEES (FirstName, LastName, Gender, City, IsActive) " +
                    "VALUES( @FirstName, @LastName, @Gender, @City, @IsActive);";

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = query;

                Console.WriteLine("Enter FirstName");
                String FirstName = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);

                Console.WriteLine("Enter LastName");
                String LastName = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@LastName", LastName);

                Console.WriteLine("Enter Gender");
                String Gender = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Gender", Gender);

                Console.WriteLine("Enter City");
                String City = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", City);

                Console.WriteLine("Enter IsActive");
                String IsActive = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@IsActive", IsActive);

                sqlCommand.ExecuteNonQuery();
            }
        }

        // 5
        public static void AdoNetConnUpdateEmpById(int empId)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            connection.Open();

            //string UpdateQuery = "UPDATE Employees " +
            //    "SET /*FirstName = @Firstname,*/ " +
            //        //"LastName = @Lastname, " +
            //        //"Gender = @Gender, " +
            //        //"City = @City, " +
            //        "IsActive = @IsActive" +
            //        "WHERE Id = @Id";

            string UpdateQuery = "Update Employees set IsActive = @IsActive where Id = @Id";

            SqlCommand sqlCommand = new SqlCommand(UpdateQuery, connection);
            //Console.WriteLine("Enter Fname");
            //string FName = Console.ReadLine();
            //sqlCommand.Parameters.AddWithValue("@FirstName", FName);

            //Console.WriteLine("Enter Lname");
            //string LName = Console.ReadLine();
            //sqlCommand.Parameters.AddWithValue("@LastName", LName);

            Console.WriteLine("Status Of The Employee");
            String Status = Console.ReadLine();
            sqlCommand.Parameters.AddWithValue("@Id", empId);
            sqlCommand.Parameters.AddWithValue("@IsActive", Status);
            Console.WriteLine("Status Updated to " + Status + " For the Employee ");

            sqlCommand.ExecuteNonQuery();

        }

        // 6.
        public static void AdoNetConnDeleteEmpById(int EmpId)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            sqlConnection.Open();

            string DeleQuery = "Delete from Employees where Id = @Id";
            SqlCommand sqlCommand = new SqlCommand(DeleQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Id", EmpId);
            sqlCommand.ExecuteNonQuery();
        }

        // 2
        public static DataTable AdoNetConnGetEmployees(string filterCity)
        {
            using (SqlConnection connection = Connection())
            {
                connection.Open();

                // Use StringBuilder to dynamically construct the SQL query
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("SELECT * FROM Employees");

                if (!string.IsNullOrEmpty(filterCity))
                {
                    // Add a WHERE clause based on the provided filter
                    queryBuilder.Append(" WHERE City = @FilterCity");
                }

                using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                {
                    // Add parameter if necessary
                    if (!string.IsNullOrEmpty(filterCity))
                    {
                        command.Parameters.AddWithValue("@FilterCity", filterCity);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        return dataTable;
                    }
                }
            }
        }

    }
}

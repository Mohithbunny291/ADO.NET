using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //AdoEmp.InsertEmp();
            //AdoEmp.SelectEmp();

            // Ado.NetConnected 

            //1. AdoNetDisconnected.DmlByDataAdapter();

            //3. int totalEmp = AdoNetConnectioned.AdoNetConnExeScalar();
            //Console.WriteLine(totalEmp);

            // 4.
            // AdoNetConnectioned.AdoNetConnInsertEmployee();

            // 5.
            // AdoNetConnectioned.AdoNetConnUpdateEmpById(21);

            // 6.
            // AdoNetConnectioned.AdoNetConnDeleteEmpById(22);


            //2. AdoNetConnectioned.AdoNetConnRead();

            //Console.WriteLine("Enter City Name Of The Employee");
            //String findDetailsByCity = Console.ReadLine();

            //DataTable cityName = AdoNetConnectioned.AdoNetConnGetEmployees(findDetailsByCity);

            //PrintDataTable(cityName);

            //Ado.NetDisConnected

            // 7.

            //AdoNetDisconnected.DmlByDataAdapter();

            // 8.

            // AdoNetDisconnected.AdoNetDisConInsertEmp();

            // 9.

            // AdoNetDisconnected.AdoNetDisConUpdateEmp(2);

            // 10.

            AdoNetDisconnected.AdoNetDisConDelete(26);

            
        }

        //2. static void PrintDataTable(DataTable dataTable)
        //{
        //    if(dataTable.Rows.Count == 0)
        //    {
        //        Console.WriteLine("Record Not Found");
        //        return;
        //    }
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        foreach (DataColumn col in dataTable.Columns)
        //        {
        //            Console.Write($"{col.ColumnName}: {row[col]} | ");
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}

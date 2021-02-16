//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using ClosedXML.Excel;
//using System.Data.SqlClient;
//using System.Data;
//using System.Configuration;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using System.IO;

//namespace OpenEmrAutomation
//{
//    class DemoTest
//    {
//        [Test]
//        public void TM()
//        {
//            string path = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
//            StreamReader reader = new StreamReader(path + "/testdata/app.json");
//            string data = reader.ReadToEnd();

//            dynamic jdata = JsonConvert.DeserializeObject(data);

//            object[] main = new object[jdata["validcred"].Count];

//            for(int i=0;i<main.Length;i++)
//            {
//                object[] temp = new object[jdata["validcred"][i].Count];
//                for(int j=0;j<temp.Length;j++)
//                {
//                    temp[j] = Convert.ToString(jdata["validcred"][i][j]); 
//                }
//                main[i] = temp;
//            }
//            Console.WriteLine(main);
//        }

//        [Test]
//        public void DBFirstCellReadTest()
//        {
//            string path = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")); 
//            StreamReader reader = new StreamReader(path+"/testdata/app.json");
//            string data = reader.ReadToEnd();

//            dynamic jdata= JsonConvert.DeserializeObject(data);
//            string connectionstring = Convert.ToString(jdata["pipedb"]);

//           // string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand("select * from Persons", con);

//            con.Open();

//            string cell = Convert.ToString(command.ExecuteScalar());

//            con.Close();

//        }

//        [Test]
//        public void DBUpdateDeleteInsertTest()
//        {
//            string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand("update persons set id=5 where id=1", con);

//            con.Open();

//            int rowAffected = command.ExecuteNonQuery();

//            con.Close();

//        }


//        public DataTable GetSelectStatementIntoDataTable(string query)
//        {
//            string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand(query, con);

//            DataTable dt = new DataTable();

//            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
//            dataAdapter.Fill(dt);

//            return dt;
//        }
//        [Test]
//        public void DBExecuteReaderTest()
//        {
//            string name = "bala";
//            string colName = "FirstName";
//            string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand("select * From persons", con);

//            con.Open();

//            SqlDataReader reader= command.ExecuteReader();
//            bool check = false;
//            while (reader.Read())
//            {
//                if(reader[colName].ToString().Contains(name))
//                {
//                    check = true;
//                    break;
//                }
//            }
//            Console.WriteLine(check);
//            con.Close();

//        }

//            [Test]
//        public void DBSelectTest()
//        {
//            string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand("select * From persons", con);

//            DataTable dt = new DataTable();

//            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
//            dataAdapter.Fill(dt);

//            //for(int i=0;i<dt.Rows.Count;i++)
//            //{
//            //    for(int j=0;j<dt.Columns.Count;j++)
//            //    {
//            //        Console.WriteLine(dt.Rows[i][j]);
//            //    }
//            //}

//            foreach(DataRow row in dt.Rows)
//            {
//                Console.WriteLine(row[0]);
//                Console.WriteLine(row[1]);
//                Console.WriteLine(row["age"]);
//            }
            

//            //Console.WriteLine(dt.Rows.Count);
//            //Console.WriteLine(dt.Columns.Count);

//        }












//        [Test]
//        public void ExcelRead()
//        {
//            XLWorkbook book = new XLWorkbook(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\OpenEmrData.xlsx");
//            var sheet = book.Worksheet("InvalidCredentialTestData");
//            var range = sheet.RangeUsed();
//            int rowCount = range.RowCount(); //5
//            int colCount = range.ColumnCount(); //4
//            Console.WriteLine(rowCount);
//            Console.WriteLine(colCount);
//            object[] main = new object[rowCount - 1]; //number of test case
//            for (int r = 2;r<= rowCount;r++)
//            {
//                object[] temp = new object[colCount]; //number of parameter
//                for(int c=1;c<=colCount;c++)
//                {
//                    string cellValue = range.Cell(r, c).GetString();
//                    Console.WriteLine(cellValue);
//                    temp[c-1] = cellValue;
//                }

//                main[r-2] = temp;
//            }

//            book.Dispose();
//        }

//        //bala
//        //john
//        //peter
//        //public static object[] jj()
//        //{
//        //    object[] main = new object[3];
//        //    main[0] = "bala";
//        //    main[1] = "john";
//        //    main[2] = "kkk";
//        //    return main;
//        //}

//        //[Test,TestCaseSource("jj")]
//        //public void TestMethod(string name)
//        //{

//        //}
        

//        //john,john123 --> one object[] --> 0 
//        //peter, peter123 --> one object[] --> 1 
//        //mark,mark123
//        //public static object[] jj()
//        //{
//        //    object[] temp1 = new object[2]; //number of parameter
//        //    temp1[0] = "john";
//        //    temp1[1] = "john123";

//        //    object[] temp2 = new object[2];
//        //    temp2[0] = "peter";
//        //    temp2[1] = "peter123";

//        //    object[] temp3 = new object[2];
//        //    temp3[0] = "mark";
//        //    temp3[1] = "mark123";

//        //    object[] main = new object[3]; //number of test case
//        //    main[0] = temp1;
//        //    main[1] = temp2;
//        //    main[2] = temp3;

//        //    return main;
//        //}

//        //[Test, TestCaseSource("jj")]
//        //public void TestMethod(string username,string password)
//        //{
//        //    Console.WriteLine(username+password);
//        //}
//    }
//}

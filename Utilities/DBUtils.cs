using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OpenEmrAutomation.Utilities
{
    public class DBUtils
    {
        private static string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";

        public string FirstCellValue(string query)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            string cell = Convert.ToString(command.ExecuteScalar());

            con.Close();

            return cell;
        }

        public int UpdateDeleteInsertQuery(string query)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            int rowAffected = command.ExecuteNonQuery();

            con.Close();

            return rowAffected;
        }


        public static DataTable GetSelectStatementIntoDataTable(string query)
        {
           SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand command = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dt);

            return dt;
        }
    }
}

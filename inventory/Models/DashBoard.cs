using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    public class DashBoardPurchasePerDay
    {
        public string CurrentDate { get; set; }
        public string SellerId { get; set; }
    }

    public class DashBoardPurchasePerMonth
    {
        public string StartDateOfMonth { get; set; }
        public string SellerId { get; set; }

        public string @startDateOfLastMonth { get; set; }
    }

    public class DashBoardPurchaseOrderPerDay
    {
        public string CurrentDate { get; set; }
        public string SellerId { get; set; }
    }


    public class DashBoardPurchaseOrderPerMonth
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SellerId { get; set; }
    }


    public class DashBoardFastestMovingProductsPerMonth
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SellerId { get; set; }
    }



    public class DashBoardPurchasePerMonthBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();
       
            public DataTable postPurchasePerMonthToDb(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
            {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetPurchasePerMonth";

            command.Parameters.AddWithValue("@SellerId", objDashBoardPurchasePerMonth.SellerId);    

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }
    }

    public class DashBoardPurchaseOrderPerDayBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();
  
        public DataTable postPurchasePerOrderDb(DashBoardPurchaseOrderPerDay objDashBoardPurchaseOrderPerDay)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetPurchaseOrderPerDay";

            command.Parameters.AddWithValue("@SellerId", objDashBoardPurchaseOrderPerDay.SellerId);

            
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }
    }
    

    public class FastestMovingProductsPerMonthBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();

        public DataTable postFastestMovingProductsToDb(string SellerId)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetFastestMovingProductsPerMonth";

            command.Parameters.AddWithValue("@SellerId", SellerId);
          

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }



        public DataTable getPurchaseAmountPerWeek(string sellerId)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetPurchaseAmountByWeek";

            command.Parameters.AddWithValue("@SellerId", sellerId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }

        public DataTable getPurchaseAmountPerWeekByVendor(string sellerId)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetPurchaseAmountByWeekAndVendor";

            command.Parameters.AddWithValue("@SellerId", sellerId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }

        public DataTable getPurchaseAmountPerMonth(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetPurchaseAmountByMonth";

            command.Parameters.AddWithValue("@SellerId", objDashBoardPurchasePerMonth.SellerId);
            command.Parameters.AddWithValue("@StartDateOfMonth", objDashBoardPurchasePerMonth.StartDateOfMonth);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }

        public DataTable getPurchaseAmountPerMonthByVendors(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetPurchaseAmountByMonthByVendor";

            command.Parameters.AddWithValue("@SellerId", objDashBoardPurchasePerMonth.SellerId);
            command.Parameters.AddWithValue("@StartDateOfMonth", objDashBoardPurchasePerMonth.StartDateOfMonth);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }


        public DataTable getHighestValueProductsByMonth(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_HighestValue_Products_By_Current_Month";

            command.Parameters.AddWithValue("@SellerId", objDashBoardPurchasePerMonth.SellerId);
            command.Parameters.AddWithValue("@CurrentMonthDate", objDashBoardPurchasePerMonth.StartDateOfMonth);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }

        public DataTable getHighestValueProductsByLastMonth(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_HighestValue_Products_By_Current_Last_Month";

            command.Parameters.AddWithValue("@SellerId", objDashBoardPurchasePerMonth.SellerId);
            command.Parameters.AddWithValue("@CurrentMonthDate", objDashBoardPurchasePerMonth.StartDateOfMonth);
            command.Parameters.AddWithValue("@startDateOfLastMonth", objDashBoardPurchasePerMonth.startDateOfLastMonth);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }



        public DataTable getTopProductsBySellerId(int sellerId)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_TopProductsBySellerId";

            command.Parameters.AddWithValue("@SellerId", sellerId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }

    }




}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    
    public class vendorView
    {
            public int vendorId { get; set; }
            public string sellerId { get; set; }
    }

    public class vendorViewBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();
        public DataTable postAllViewData(vendorView vendorViewData)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Vendor_Mapped_Data";
            command.Parameters.AddWithValue("@vendorId", vendorViewData.vendorId);
            command.Parameters.AddWithValue("@SellerId", vendorViewData.sellerId.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            ;

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }
    }
}
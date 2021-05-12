using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    public class StockIn
    {
     public int StockInItemId { get; set; }
     public int PurchaseOrderId { get; set; }
     public int PurchaseOrderItemId { get; set; }
     public int ProductVarientId { get; set; }
     public int ReferenceId { get; set; }
     public int QuantityReceived { get; set; }
     public int QuantityOrdered { get; set; }
     public int Discount { get; set; }
     public int SellingPrice { get; set; }
     public string BarCode { get; set; }
     public int SellerId { get; set; }
     public int IsActive { get; set; }
    }

    public class StockInBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();

        public DataTable getAllData(int id)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_getAllStockInData";
            command.Parameters.AddWithValue("@SellerId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }

        public string postStockInItemsToDb(List<StockIn> stockInData)
        {
           

            for (int i = 0; i < stockInData.Count; i++)
            {

                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Mst_InsertStockInItems", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StockInItemId", stockInData[i].StockInItemId);
                cmd.Parameters.AddWithValue("@PurchaseOrderId", stockInData[i].PurchaseOrderId);
                cmd.Parameters.AddWithValue("@PurchaseOrderItemId", stockInData[i].PurchaseOrderItemId);
                cmd.Parameters.AddWithValue("@ProductVarientId", stockInData[i].ProductVarientId);
                cmd.Parameters.AddWithValue("@ReferenceId", stockInData[i].ReferenceId);

                if (stockInData[i].QuantityOrdered == stockInData[i].QuantityReceived)
                {              
                    stockInData[i].IsActive = 1;
                    cmd.Parameters.AddWithValue("@IsActive", stockInData[i].IsActive);
                }
                else
                {
                    stockInData[i].IsActive = 0;
                    cmd.Parameters.AddWithValue("@IsActive", stockInData[i].IsActive);
                }
                cmd.Parameters.AddWithValue("@QuantityReceived", stockInData[i].QuantityReceived);
                cmd.Parameters.AddWithValue("@Discount", stockInData[i].Discount);
                cmd.Parameters.AddWithValue("@SellingPrice", stockInData[i].SellingPrice);

                cmd.Parameters.AddWithValue("@BarCode", stockInData[i].BarCode);
                cmd.Parameters.AddWithValue("@SellerId", stockInData[i].SellerId);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return "ok";
        }
    }
}
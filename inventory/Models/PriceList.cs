using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace inventory.Models
{
    public class PriceList
    {
      public int PriceListId { get; set; }
      public int SellerId { get; set; }
      public int  ProductId { get; set; }
      public int CategoryId { get; set; }
      public int SubCategoryId { get; set; }
      public int BrandId { get; set; }
      public int BuyingPrice { get; set; }
      public int FinalPrice { get; set; }
      public int ReferenceId { get; set; }
      public int Discount { get; set; }
      public int ProductVarientId { get; set; }
      public string  AvailableQuantity { get; set; }
      public string Quantity { get; set; }
      public int VendorId { get; set; }

    }

    public class PriceListBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();

        public DataTable getAllData(int id)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getAllPriceListData";
            command.Parameters.AddWithValue("@SellerId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }



        public string postPriceListToDb(PriceList priceListData)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_insertPriceListMaster", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@PriceListId", priceListData.PriceListId);
            cmd.Parameters.AddWithValue("@SellerId", priceListData.SellerId);
            cmd.Parameters.AddWithValue("@ProductId", priceListData.ProductId);

            cmd.Parameters.AddWithValue("@CategoryId", priceListData.CategoryId);
            cmd.Parameters.AddWithValue("@SubCategoryId", priceListData.SubCategoryId);
            cmd.Parameters.AddWithValue("@BrandId", priceListData.BrandId);

            cmd.Parameters.AddWithValue("@BuyingPrice", priceListData.BuyingPrice);
            cmd.Parameters.AddWithValue("@FinalPrice", priceListData.FinalPrice);
            cmd.Parameters.AddWithValue("@ReferenceId", priceListData.ReferenceId);

            cmd.Parameters.AddWithValue("@Discount", priceListData.Discount);
            cmd.Parameters.AddWithValue("@ProductVarientId", priceListData.ProductVarientId);
            cmd.Parameters.AddWithValue("@AvailableQuantity", priceListData.AvailableQuantity);
            cmd.Parameters.AddWithValue("@Quantity", priceListData.Quantity);
            cmd.Parameters.AddWithValue("@VendorId", priceListData.VendorId);

            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
        }


        public string updatePriceListToDb(PriceList priceListData, int PriceListId)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_updatePriceListMaster", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PriceListId", PriceListId);
            cmd.Parameters.AddWithValue("@SellerId", priceListData.SellerId);
            cmd.Parameters.AddWithValue("@ProductId", priceListData.ProductId);

            cmd.Parameters.AddWithValue("@CategoryId", priceListData.CategoryId);
            cmd.Parameters.AddWithValue("@SubCategoryId", priceListData.SubCategoryId);
            cmd.Parameters.AddWithValue("@BrandId", priceListData.BrandId);

            cmd.Parameters.AddWithValue("@BuyingPrice", priceListData.BuyingPrice);
            cmd.Parameters.AddWithValue("@FinalPrice", priceListData.FinalPrice);
            cmd.Parameters.AddWithValue("@ReferenceId", priceListData.ReferenceId);

            cmd.Parameters.AddWithValue("@Discount", priceListData.Discount);
            cmd.Parameters.AddWithValue("@ProductVarientId", priceListData.ProductVarientId);
            cmd.Parameters.AddWithValue("@AvailableQuantity", priceListData.AvailableQuantity);
            cmd.Parameters.AddWithValue("@Quantity", priceListData.Quantity);

            cmd.Parameters.AddWithValue("@VendorId", priceListData.VendorId);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
        }
      
    }

}
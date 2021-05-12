using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    public class PurchaseProductItems
    {
        public int PurchaseProductId { get; set; }
        public int PurchaseProductsItemId { get; set; }
        public int SellerId { get; set; }
        public string VendorCode { get; set; }
        public int BrandId { get; set; }
        public int ProductId { get; set; }
        public string Discount { get; set; }
        public string FinalPrice { get; set; }
        public int MRP { get; set; }
        public int Quantity { get; set; }
        public int RequiredQuantity { get; set; }
        public string Unit { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int categoryid { get; set; }

    }

    public class PurchaseProductItemsBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();

        public string postPurchaseProductsItemToDb(List<PurchaseProductItems> purchaseProductsItemData, int PurchaseProductId,int SellerId,string VendorCode)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_insertPurchaseProductItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
 

            for (int i = 0; i < purchaseProductsItemData.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PurchaseProductId", PurchaseProductId);

                cmd.Parameters.AddWithValue("@SellerId",SellerId);
                cmd.Parameters.AddWithValue("@VendorCode",VendorCode);

                cmd.Parameters.AddWithValue("@BrandId", purchaseProductsItemData[i].BrandId);
                cmd.Parameters.AddWithValue("@ProductId", purchaseProductsItemData[i].ProductId);

                cmd.Parameters.AddWithValue("@Discount", Convert.ToDouble(purchaseProductsItemData[i].Discount));
                cmd.Parameters.AddWithValue("@FinalPrice", Convert.ToDouble(purchaseProductsItemData[i].FinalPrice));
                cmd.Parameters.AddWithValue("@MRP", purchaseProductsItemData[i].MRP);
                cmd.Parameters.AddWithValue("@Quantity", purchaseProductsItemData[i].Quantity);
                cmd.Parameters.AddWithValue("@RequiredQuantity", purchaseProductsItemData[i].RequiredQuantity);
                cmd.Parameters.AddWithValue("@Unit", purchaseProductsItemData[i].Unit);
                cmd.Parameters.AddWithValue("@id", purchaseProductsItemData[i].id);
                cmd.Parameters.AddWithValue("@name", purchaseProductsItemData[i].name);
                cmd.Parameters.AddWithValue("@CategoryId", purchaseProductsItemData[i].categoryid);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            return "ok";
        }


    }
}
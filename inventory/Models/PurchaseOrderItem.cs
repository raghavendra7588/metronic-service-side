using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    public class PurchaseOrderItem
    {
        public int PurchaseOrderId { get; set; }
        public int PurchaseOrderItemId { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public int BuyingPrice { get; set; }
        public int FinalPrice { get; set; }
        public int ReferenceId { get; set; }
        public int Discount { get; set; }
        public string availableQuantity { get; set; }
        public string Quantity { get; set; }
        public int ProductVarientId { get; set; }
        //  public string[] categoryId { get; set; }
    }

    public class PurchaseOrderItemBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();


        public string postPurchaseOrderItemToDb(List<PurchaseOrderItem> purchaseOrderItemData, int purchaseOrderId)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_insertPurchaseOrderItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //string strCategoryId = string.Empty;

            //for (int j = 0; j < purchaseOrderItemData[0].categoryId.Length; j++)
            //{
            //    strCategoryId = purchaseOrderItemData[0].categoryId[j].ToString() + ",";
            //}
            //strCategoryId = strCategoryId.Remove(strCategoryId.Length - 1, 1);

            for (int i = 0; i < purchaseOrderItemData.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PurchaseOrderId", purchaseOrderId);
                cmd.Parameters.AddWithValue("@SellerId", purchaseOrderItemData[i].SellerId);
                //cmd.Parameters.AddWithValue("@CategoryId", strCategoryId);
                cmd.Parameters.AddWithValue("@CategoryId", purchaseOrderItemData[i].CategoryId);
                cmd.Parameters.AddWithValue("@ProductId", purchaseOrderItemData[i].ProductId);
                cmd.Parameters.AddWithValue("@SubCategoryId", purchaseOrderItemData[i].SubCategoryId);
                cmd.Parameters.AddWithValue("@BrandId", purchaseOrderItemData[i].BrandId);
                cmd.Parameters.AddWithValue("@BuyingPrice", purchaseOrderItemData[i].BuyingPrice);
                cmd.Parameters.AddWithValue("@FinalPrice", purchaseOrderItemData[i].FinalPrice);
                cmd.Parameters.AddWithValue("@ReferenceId", purchaseOrderItemData[i].ReferenceId);
                cmd.Parameters.AddWithValue("@Discount", purchaseOrderItemData[i].Discount);

                cmd.Parameters.AddWithValue("@PurchaseQuantity", purchaseOrderItemData[i].availableQuantity);
                cmd.Parameters.AddWithValue("@Quantity", purchaseOrderItemData[i].Quantity);
                cmd.Parameters.AddWithValue("@ProductVarientId", purchaseOrderItemData[i].ProductVarientId);


                cmd.ExecuteNonQuery();
            }
            conn.Close();
            return "ok";
        }

    }

}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    public class PurchaseProducts
    {
        public int PurchaseProductId { get; set; }
        public int SellerId { get; set; }
        public string VendorCode { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public int AddressId { get; set; }
        public string DeliveryType { get; set; }
        public string PaymentType { get; set; }
        public string DeliveryTime { get; set; }
    
        public string VendorName { get; set; }
    
        public List<PurchaseProductItems> items { get; set; }

    }

    public class PurchaseProductsBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();

        public PurchaseProducts PostProductItems(PurchaseProducts objPurchaseProducts)
        {
            PurchaseProducts objResultReturn = new PurchaseProducts();
            PurchaseProductItemsBL ObjPurchaseProductItemsBL = new PurchaseProductItemsBL();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_insertPurchaseProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SellerId", objPurchaseProducts.SellerId);
            cmd.Parameters.AddWithValue("@VendorCode", objPurchaseProducts.VendorCode);
            cmd.Parameters.AddWithValue("@OrderNo", objPurchaseProducts.OrderNo);
            cmd.Parameters.AddWithValue("@OrderDate", objPurchaseProducts.OrderDate);

            cmd.Parameters.AddWithValue("@DeliveryDate", objPurchaseProducts.DeliveryDate);
            cmd.Parameters.AddWithValue("@AddressId", objPurchaseProducts.AddressId);
            cmd.Parameters.AddWithValue("@DeliveryType", objPurchaseProducts.DeliveryType);
            cmd.Parameters.AddWithValue("@PaymentType", objPurchaseProducts.PaymentType);
            cmd.Parameters.AddWithValue("@DeliveryTime", objPurchaseProducts.DeliveryTime);
            cmd.Parameters.AddWithValue("@VendorName", objPurchaseProducts.VendorName);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            conn.Close();
            int id = (int)cmd.Parameters["@id"].Value;
            objResultReturn.PurchaseProductId = id;
            objResultReturn.OrderNo = objPurchaseProducts.OrderNo;

            ObjPurchaseProductItemsBL.postPurchaseProductsItemToDb(objPurchaseProducts.items, id, objPurchaseProducts.SellerId, objPurchaseProducts.VendorCode);
            return objResultReturn;

        }
    }
}
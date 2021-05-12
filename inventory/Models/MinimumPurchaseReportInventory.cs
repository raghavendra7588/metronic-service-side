using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace inventory.Models
{
    public class MinimumPurchaseReportInventory
    {
        public string categoryId { get; set; }
        public string subcategoryId { get; set; }
        public string brandId { get; set; }
        public string productId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string sellerId { get; set; }
    }

    public class MinimumPurchaseReportInventoryBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();

        public DataTable postAllData(MinimumPurchaseReportInventory purchaseReportInventory)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            //string sql = BuildQuery(purchaseReportInventory.sellerId, purchaseReportInventory.subcategoryId, purchaseReportInventory.brandId, purchaseReportInventory.productId, purchaseReportInventory.startDate, purchaseReportInventory.endDate);
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_Minimum_Purchase_Report";

          
            command.Parameters.AddWithValue("@SellerId", purchaseReportInventory.sellerId);
            command.Parameters.AddWithValue("@SubCategoryId", purchaseReportInventory.subcategoryId);
            command.Parameters.AddWithValue("@BrandId", purchaseReportInventory.brandId);
            command.Parameters.AddWithValue("@ProductId", purchaseReportInventory.productId);
            command.Parameters.AddWithValue("@OrderDate", purchaseReportInventory.startDate);
            command.Parameters.AddWithValue("@DeliveryDate", purchaseReportInventory.endDate);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");

            DataTable table = new DataTable();
            DataTable itemsTable = fileData.Tables[0];
            DataTable MinimumTable = fileData.Tables[1];

            conn.Close();
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("BrandName", typeof(string));
            table.Columns.Add("VarientName", typeof(string));


            table.Columns.Add("BuyingPrice", typeof(string));
            table.Columns.Add("Discount", typeof(int));
            table.Columns.Add("ProductVarientId", typeof(string));
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("TotalQuantityOrder", typeof(int));

            table.Columns.Add("TotalFinalPrice", typeof(int));
            table.Columns.Add("TotalDiscountPrice", typeof(int));
            table.Columns.Add("FinalPurchaseAmount", typeof(int));

            table.Columns.Add("VendorName", typeof(string));
            table.Columns.Add("OrderNo", typeof(string));


            for (int i = 0; i < itemsTable.Rows.Count; i++)
            {

                string ProductName = itemsTable.Rows[i]["ProductName"].ToString();
                string BrandName = itemsTable.Rows[i]["BrandName"].ToString();
                string VarientName = itemsTable.Rows[i]["Varient"].ToString();
               
                string BuyingPrice = itemsTable.Rows[i]["BuyingPrice"].ToString();
                string Discount = itemsTable.Rows[i]["Discount"].ToString();
                string ProductVarientId = itemsTable.Rows[i]["ProductVarientId"].ToString();

                string ProductId = itemsTable.Rows[i]["ProductId"].ToString();               
                string OrderNo = itemsTable.Rows[i]["OrderNo"].ToString();
                string VendorName = itemsTable.Rows[i]["name"].ToString();

                int totalQuantityOrder = 0;
                int totalFinalPrice = 0;
                int totalDiscountPrice = 0;
                int finalPurchaseAmount = 0;
               
                for (int j = 0; j < MinimumTable.Rows.Count; j++)
                {
                    if (ProductVarientId == MinimumTable.Rows[j]["ProductVarientId"].ToString())
                    {
                                            
                         BuyingPrice = MinimumTable.Rows[j]["MinBuying"].ToString();
                         Discount = MinimumTable.Rows[j]["MinDiscount"].ToString();
                                        
                        totalQuantityOrder += Convert.ToInt32(itemsTable.Rows[i]["PurchaseQuantity"].ToString());
                        totalFinalPrice += Convert.ToInt32(itemsTable.Rows[i]["FinalPrice"].ToString());
                        totalDiscountPrice += Convert.ToInt32(itemsTable.Rows[i]["Discount"].ToString());
                        finalPurchaseAmount = totalFinalPrice - totalDiscountPrice;
                        
                    }
                }
                table.Rows.Add(ProductName, BrandName, VarientName, BuyingPrice,
                     Discount, ProductVarientId, ProductId,
                    totalQuantityOrder, totalFinalPrice, totalDiscountPrice,
                    finalPurchaseAmount, VendorName, OrderNo);
            }
            return table;
        }



        public DataTable createReportData(DataTable dt)
        {
            DataTable table = new DataTable();

            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("Varient", typeof(string));


            table.Columns.Add("BuyingPrice", typeof(string));
            table.Columns.Add("Discount", typeof(int));
            table.Columns.Add("ProductVarientId", typeof(string));
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("TotalQuantityOrder", typeof(int));

            table.Columns.Add("TotalFinalPrice", typeof(int));
            table.Columns.Add("TotalDiscountPrice", typeof(int));
            table.Columns.Add("FinalPurchaseAmount", typeof(int));

            table.Columns.Add("VendorName", typeof(string));
            table.Columns.Add("OrderNo", typeof(string));
         

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string strProductName = dt.Rows[i]["ProductName"].ToString();
                string strBrandName = dt.Rows[i]["BrandName"].ToString();
                string strVarientName = dt.Rows[i]["Varient"].ToString();
                string strVendorName = dt.Rows[i]["name"].ToString();
                string strBuyingPrice = dt.Rows[i]["BuyingPrice"].ToString();
                string strDiscount = dt.Rows[i]["Discount"].ToString();
                string strProductVarientId = dt.Rows[i]["ProductVarientId"].ToString();

                string strProductId = dt.Rows[i]["ProductId"].ToString();
                string strFinalPrice = dt.Rows[i]["FinalPrice"].ToString();
                string strPurchaseQuantity = dt.Rows[i]["PurchaseQuantity"].ToString();
                string strOrderNo = dt.Rows[i]["OrderNo"].ToString();

                int totalQuantityOrder = 0;
                int totalFinalPrice = 0;
                int totalDiscountPrice = 0;
                int finalPurchaseAmount = 0;
                int totalOrderNo = 0;
                int intBuyingPrice = 0;
                int intDiscount = 0;
                int tempMinimumCalculation = 0;
                int minimumCalculation = 0;
                    
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (strProductVarientId == dt.Rows[j]["ProductVarientId"].ToString())
                    {
                        totalQuantityOrder += (Convert.ToInt32(dt.Rows[j]["PurchaseQuantity"].ToString())/2);
                        totalFinalPrice += Convert.ToInt32(dt.Rows[j]["FinalPrice"].ToString());
                        totalDiscountPrice += Convert.ToInt32(dt.Rows[j]["Discount"].ToString());
                        finalPurchaseAmount = totalFinalPrice - totalDiscountPrice;
                     

                        //intBuyingPrice = Convert.ToInt32(dt.Rows[j]["BuyingPrice"].ToString());
                        //intDiscount = Convert.ToInt32(dt.Rows[j]["Discount"].ToString());
                        
                        //minimumCalculation = intBuyingPrice - intDiscount;
                        //if (tempMinimumCalculation < minimumCalculation)
                        //{
                        //    tempMinimumCalculation = minimumCalculation;
                        //    strVendorName= dt.Rows[j]["name"].ToString();
                        //    strOrderNo= dt.Rows[j]["OrderNo"].ToString();
                        //    strBuyingPrice = dt.Rows[j]["BuyingPrice"].ToString();
                        //    strDiscount = dt.Rows[j]["Discount"].ToString();                            
                        //}
                    }
                }
                table.Rows.Add(strProductName, strBrandName, strVarientName, strBuyingPrice,
                     strDiscount, strProductVarientId, strProductId,
                    totalQuantityOrder, totalFinalPrice, totalDiscountPrice,
                    finalPurchaseAmount, strVendorName, strOrderNo);
            }

           // table = table.DefaultView.ToTable(true, "ProductVarientId", "ProductName", "Brand", "Varient", "VendorName", "OrderNo", "TotalOrderNo", "BuyingPrice", "ProductId", "Discount", "FinalPrice", "PurchaseQuantity", "TotalQuantityOrder", "TotalFinalPrice", "TotalDiscountPrice", "FinalPurchaseAmount");
            return table;
        }

    }
}

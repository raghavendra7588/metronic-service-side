using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    public class ProductsVendorWisePurchaseReport
    {

        public string categoryId { get; set; }
        public string subcategoryId { get; set; }
        public string brandId { get; set; }
        public string productId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string sellerId { get; set; }
        public string vendorId { get; set; }
    }

    public class ProductsVendorWisePurchaseReportBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();

        public DataTable postAllData(ProductsVendorWisePurchaseReport objProductsVendorWisePurchaseReport)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            //string sql = BuildQuery(purchaseReportInventory.sellerId, purchaseReportInventory.subcategoryId, purchaseReportInventory.brandId, purchaseReportInventory.productId, purchaseReportInventory.startDate, purchaseReportInventory.endDate);
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ProductVendor_Wise_Purchase_Report";


            command.Parameters.AddWithValue("@SellerId", objProductsVendorWisePurchaseReport.sellerId);
            command.Parameters.AddWithValue("@SubCategoryId", objProductsVendorWisePurchaseReport.subcategoryId);
            command.Parameters.AddWithValue("@BrandId", objProductsVendorWisePurchaseReport.brandId);
            command.Parameters.AddWithValue("@ProductId", objProductsVendorWisePurchaseReport.productId);
            command.Parameters.AddWithValue("@OrderDate", objProductsVendorWisePurchaseReport.startDate);
            command.Parameters.AddWithValue("@DeliveryDate", objProductsVendorWisePurchaseReport.endDate);
            command.Parameters.AddWithValue("@VendorId", objProductsVendorWisePurchaseReport.vendorId);
            command.Parameters.AddWithValue("@CategoryId", objProductsVendorWisePurchaseReport.categoryId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }


        public DataTable postBrandVendorData(ProductsVendorWisePurchaseReport objProductsVendorWisePurchaseReport)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
           
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BrandVendor_Wise_Purchase_Report";


            command.Parameters.AddWithValue("@SellerId", objProductsVendorWisePurchaseReport.sellerId);
            command.Parameters.AddWithValue("@SubCategoryId", objProductsVendorWisePurchaseReport.subcategoryId);
            command.Parameters.AddWithValue("@BrandId", objProductsVendorWisePurchaseReport.brandId);
            command.Parameters.AddWithValue("@CategoryId", objProductsVendorWisePurchaseReport.categoryId);
            command.Parameters.AddWithValue("@OrderDate", objProductsVendorWisePurchaseReport.startDate);
            command.Parameters.AddWithValue("@DeliveryDate", objProductsVendorWisePurchaseReport.endDate);
            command.Parameters.AddWithValue("@VendorId", objProductsVendorWisePurchaseReport.vendorId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
           
            return firstTable;
 
        }


     


        public DataTable postProductVendorOrderWiseData(ProductsVendorWisePurchaseReport objProductsVendorWisePurchaseReport)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ProductVendorOrderWisePurchaseReport";


            command.Parameters.AddWithValue("@SellerId", objProductsVendorWisePurchaseReport.sellerId);
            command.Parameters.AddWithValue("@BrandId", objProductsVendorWisePurchaseReport.brandId);
            command.Parameters.AddWithValue("@OrderDate", objProductsVendorWisePurchaseReport.startDate);
            command.Parameters.AddWithValue("@DeliveryDate", objProductsVendorWisePurchaseReport.endDate);
            command.Parameters.AddWithValue("@VendorId", objProductsVendorWisePurchaseReport.vendorId);
            command.Parameters.AddWithValue("@ProductId", objProductsVendorWisePurchaseReport.productId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable dt = fileData.Tables[0];
            DataTable orderTable = fileData.Tables[1];

            DataTable table = new DataTable();

            table.Columns.Add("BrandName", typeof(string));
            table.Columns.Add("BrandID", typeof(string));
            table.Columns.Add("ProductID", typeof(string));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("Varient", typeof(string));

            table.Columns.Add("BuyingPrice", typeof(string));
            table.Columns.Add("Discount", typeof(int));

            table.Columns.Add("TotalBuyingPrice", typeof(string));
            table.Columns.Add("TotalDiscount", typeof(int));
            table.Columns.Add("ProductVarientId", typeof(string));
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("TotalQuantityOrder", typeof(int));


            table.Columns.Add("TotalFinalPrice", typeof(int));
            table.Columns.Add("FinalPurchaseAmtAns", typeof(int));
            table.Columns.Add("OrderNo", typeof(int));
            table.Columns.Add("OrderDate", typeof(string));
            table.Columns.Add("TotalOrderAmtAns", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                string strBrandName = dt.Rows[i]["BrandName"].ToString();
                string strBrandd = dt.Rows[i]["BrandIDD"].ToString();

                string strProductID = dt.Rows[i]["ProductIDD"].ToString();
                string strProductNamee = dt.Rows[i]["ProductName"].ToString();

                string strVarientName = dt.Rows[i]["Varient"].ToString();

                string strBuyingPrice = dt.Rows[i]["BuyingPrice"].ToString();
                string strDiscount = dt.Rows[i]["Discount"].ToString();
                string strProductVarientId = dt.Rows[i]["ProductVarientId"].ToString();

                string strProductId = dt.Rows[i]["ProductIDD"].ToString();
                string strOrderNo = dt.Rows[i]["OrderNo"].ToString();


                int intProductID = Convert.ToInt32(dt.Rows[i]["ProductIDD"].ToString());
                int intOrderNo = Convert.ToInt32(dt.Rows[i]["OrderNo"].ToString());
                string strVarient = dt.Rows[i]["Varient"].ToString();

                int totalQuantityOrder = 0;
                int totalFinalPrice = 0;
                int totalDiscountPrice = 0;
                int finalPurchaseAmount = 0;

                int totalBuyingPrice = 0;
                int totalOrderAmt = 0;
                string strOrderDate = "";

                for (int j = 0; j < orderTable.Rows.Count; j++)
                {
              
                    if (intOrderNo == Convert.ToInt32(orderTable.Rows[j]["OrderNo"].ToString()))
                    {

                        strOrderNo = orderTable.Rows[j]["OrderNo"].ToString();
                        strOrderDate= orderTable.Rows[j]["OrderDate"].ToString();
                        
            
                        totalOrderAmt+= Convert.ToInt32(orderTable.Rows[j]["FinalPrice"].ToString());

                        if (intProductID == Convert.ToInt32(orderTable.Rows[j]["ProductId"].ToString()) &&
                        strVarient == orderTable.Rows[j]["Varient"].ToString())
                        {
                            totalQuantityOrder += Convert.ToInt32(orderTable.Rows[j]["PurchaseQuantity"].ToString());
                            totalFinalPrice += Convert.ToInt32(orderTable.Rows[j]["FinalPrice"].ToString());
                            totalBuyingPrice = totalBuyingPrice + Convert.ToInt32(orderTable.Rows[j]["BuyingPrice"].ToString()) * Convert.ToInt32(orderTable.Rows[j]["PurchaseQuantity"].ToString());
                            totalDiscountPrice = totalDiscountPrice + Convert.ToInt32(orderTable.Rows[j]["Discount"].ToString()) * Convert.ToInt32(orderTable.Rows[j]["PurchaseQuantity"].ToString());
                            finalPurchaseAmount = totalBuyingPrice - totalDiscountPrice;
                           // finalPurchaseAmount = totalFinalPrice;
                        }
                    }
                }
                table.Rows.Add(strBrandName, strBrandd, strProductID, strProductNamee,strVarientName, strBuyingPrice, strDiscount,
                totalBuyingPrice,totalDiscountPrice, strProductVarientId,
                strProductId,
                totalQuantityOrder, totalFinalPrice,
                finalPurchaseAmount, strOrderNo, strOrderDate, totalOrderAmt);
            }


           return table;


        

        }



        public DataTable postBrandVendorOrderWiseData(ProductsVendorWisePurchaseReport objProductsVendorWisePurchaseReport)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BrandVendorOrderWisePurchaseReport";


            command.Parameters.AddWithValue("@SellerId", objProductsVendorWisePurchaseReport.sellerId);
            command.Parameters.AddWithValue("@BrandId", objProductsVendorWisePurchaseReport.brandId);
            command.Parameters.AddWithValue("@OrderDate", objProductsVendorWisePurchaseReport.startDate);
            command.Parameters.AddWithValue("@DeliveryDate", objProductsVendorWisePurchaseReport.endDate);
            command.Parameters.AddWithValue("@VendorId", objProductsVendorWisePurchaseReport.vendorId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable dt = fileData.Tables[0];
            DataTable orderTable = fileData.Tables[1];

            DataTable table = new DataTable();

            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("BrandID", typeof(string));


            table.Columns.Add("Varient", typeof(string));
            table.Columns.Add("BuyingPrice", typeof(string));
            table.Columns.Add("Discount", typeof(int));
            table.Columns.Add("ProductVarientId", typeof(string));
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("TotalQuantityOrder", typeof(int));

            table.Columns.Add("TotalFinalPrice", typeof(int));
            table.Columns.Add("TotalDiscountPrice", typeof(int));
            table.Columns.Add("FinalPurchaseAmountAns", typeof(int));


            table.Columns.Add("TotalBuyingPrice", typeof(int));

            table.Columns.Add("OrderNo", typeof(int));
            table.Columns.Add("OrderDate", typeof(string));
            table.Columns.Add("TotalOrderAmtAns", typeof(int));
            table.Columns.Add("varientCount", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                string strBrandName = dt.Rows[i]["BrandName"].ToString();
                string strBrandd = dt.Rows[i]["BrandIDD"].ToString();

                string strVarientName = dt.Rows[i]["Varient"].ToString();
               
                string strBuyingPrice = dt.Rows[i]["BuyingPrice"].ToString();
                string strDiscount = dt.Rows[i]["Discount"].ToString();
                string strProductVarientId = dt.Rows[i]["ProductVarientId"].ToString();

                string strProductId = dt.Rows[i]["ProductId"].ToString();
                string strOrderNo = dt.Rows[i]["OrderNo"].ToString();
               

                int intBrandId = Convert.ToInt32(dt.Rows[i]["BrandIDD"].ToString());
                int intOrderNo = Convert.ToInt32(dt.Rows[i]["OrderNo"].ToString());

                string currentVarient = (dt.Rows[i]["Varient"].ToString());
                int totalQuantityOrder = 0;
                int totalFinalPrice = 0;
                int totalDiscountPrice = 0;
                int finalPurchaseAmount = 0;
   
                int totalBuyingPrice = 0;
                int totalOrderAmt = 0;
                string strOrderDate = "";
                int varientCnt = 0;

             

                for (int j = 0; j < orderTable.Rows.Count; j++)
                {
                    if (intOrderNo == Convert.ToInt32(orderTable.Rows[j]["OrderNo"].ToString()))
                    {

                        strOrderNo = orderTable.Rows[j]["OrderNo"].ToString();
                        strOrderDate = orderTable.Rows[j]["OrderDate"].ToString();
                        totalOrderAmt += Convert.ToInt32(orderTable.Rows[j]["FinalPrice"].ToString());

                        if (intBrandId == Convert.ToInt32(orderTable.Rows[j]["BrandId"].ToString()))
                        {

                            varientCnt++;
                            totalQuantityOrder += Convert.ToInt32(orderTable.Rows[j]["PurchaseQuantity"].ToString());
                            totalFinalPrice += Convert.ToInt32(orderTable.Rows[j]["FinalPrice"].ToString());
                            totalBuyingPrice = totalBuyingPrice + Convert.ToInt32(orderTable.Rows[j]["BuyingPrice"].ToString()) * Convert.ToInt32(orderTable.Rows[j]["PurchaseQuantity"].ToString());
                            totalDiscountPrice = totalDiscountPrice + Convert.ToInt32(orderTable.Rows[j]["Discount"].ToString()) * Convert.ToInt32(orderTable.Rows[j]["PurchaseQuantity"].ToString());
                            finalPurchaseAmount = totalBuyingPrice - totalDiscountPrice;

                          
                        }
    
                       

                    }
                }
                table.Rows.Add(strBrandName, strBrandd, strVarientName, strBuyingPrice,
                strDiscount, strProductVarientId, strProductId,
                totalQuantityOrder, totalFinalPrice, totalDiscountPrice,
                finalPurchaseAmount, totalBuyingPrice, strOrderNo, strOrderDate, totalOrderAmt, varientCnt);
            }




      
           return table;
        }

   




        

        public DataTable createReportData(DataTable dt)
        {
            DataTable table = new DataTable();

            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("Brand", typeof(string));


            table.Columns.Add("ProductNamee", typeof(string));
            table.Columns.Add("BrandID", typeof(string));

            table.Columns.Add("Varient", typeof(string));


            table.Columns.Add("BuyingPrice", typeof(string));
            table.Columns.Add("Discount", typeof(int));
            table.Columns.Add("ProductVarientId", typeof(string));
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("TotalQuantityOrder", typeof(int));

            table.Columns.Add("TotalFinalPrice", typeof(int));
            table.Columns.Add("TotalDiscountPrice", typeof(int));
            table.Columns.Add("FinalPurchaseAmount", typeof(int));

            table.Columns.Add("BrandTotal", typeof(int));
            table.Columns.Add("TotalOrder", typeof(int));
            table.Columns.Add("TotalBuyingPrice", typeof(int));



            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string strProductName =dt.Rows[i]["ProductName"].ToString();
                string strBrandName = dt.Rows[i]["BrandName"].ToString();

                string strProductNamee = dt.Rows[i]["ProductNamee"].ToString();
                string strBrandd = dt.Rows[i]["BrandIDD"].ToString();

                string strVarientName = dt.Rows[i]["Varient"].ToString();
                string strVendorName = dt.Rows[i]["name"].ToString();
                string strBuyingPrice = dt.Rows[i]["BuyingPrice"].ToString();
                string strDiscount = dt.Rows[i]["Discount"].ToString();
                string strProductVarientId = dt.Rows[i]["ProductVarientId"].ToString();

                string strProductId = dt.Rows[i]["ProductId"].ToString();
                string strFinalPrice = dt.Rows[i]["FinalPrice"].ToString();
                string strPurchaseQuantity = dt.Rows[i]["PurchaseQuantity"].ToString();
                string strOrderNo = dt.Rows[i]["OrderNo"].ToString();
                int intBrandId= Convert.ToInt32(dt.Rows[i]["BrandIDD"].ToString());

                int totalQuantityOrder = 0;
                int totalFinalPrice = 0;
                int totalDiscountPrice = 0;
                int finalPurchaseAmount = 0;
                int totalOrderNo = 0;
                int totalBuyingPrice = 0;

                int brandWiseTotal = 0;

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (strProductVarientId == dt.Rows[j]["ProductVarientId"].ToString())
                    {
                       
                      

                        if (intBrandId == Convert.ToInt32(dt.Rows[j]["BrandIDD"].ToString()))
                        {
                            totalQuantityOrder += Convert.ToInt32(dt.Rows[j]["PurchaseQuantity"].ToString());
                            totalFinalPrice += Convert.ToInt32(dt.Rows[j]["FinalPrice"].ToString());
                            totalBuyingPrice = totalBuyingPrice+ Convert.ToInt32(dt.Rows[j]["BuyingPrice"].ToString()) * Convert.ToInt32(dt.Rows[j]["PurchaseQuantity"].ToString());
                            totalDiscountPrice = totalDiscountPrice + Convert.ToInt32(dt.Rows[j]["Discount"].ToString()) * Convert.ToInt32(dt.Rows[j]["PurchaseQuantity"].ToString());
                            finalPurchaseAmount = totalBuyingPrice - totalDiscountPrice;
                            totalOrderNo++; 
                            brandWiseTotal += ((Convert.ToInt32(dt.Rows[j]["FinalPrice"].ToString()))); 

                        }
                     
                    }
                }
                    table.Rows.Add(strProductName, strBrandName, strProductNamee, strBrandd, strVarientName, strBuyingPrice,
                    strDiscount, strProductVarientId, strProductId,
                    totalQuantityOrder, totalFinalPrice, totalDiscountPrice,
                    finalPurchaseAmount, brandWiseTotal, totalOrderNo, totalBuyingPrice);
            }

            // table = table.DefaultView.ToTable(true, "ProductVarientId", "ProductName", "Brand", "Varient", "VendorName", "OrderNo", "TotalOrderNo", "BuyingPrice", "ProductId", "Discount", "FinalPrice", "PurchaseQuantity", "TotalQuantityOrder", "TotalFinalPrice", "TotalDiscountPrice", "FinalPurchaseAmount");
            return table;
        }




        public DataTable createBrandVendorWiseReportData(DataTable dt)
        {
            DataTable table = new DataTable();

            
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("BrandID", typeof(string));

            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("SubCategory", typeof(string));
            table.Columns.Add("Varient", typeof(string));


            table.Columns.Add("BuyingPrice", typeof(string));
            table.Columns.Add("Discount", typeof(int));
            table.Columns.Add("ProductVarientId", typeof(string));
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("TotalQuantityOrder", typeof(int));

            table.Columns.Add("TotalFinalPrice", typeof(int));
            table.Columns.Add("TotalDiscountPrice", typeof(int));
            table.Columns.Add("FinalPurchaseAmount", typeof(int));

            table.Columns.Add("BrandTotal", typeof(int));
            table.Columns.Add("TotalOrder", typeof(int));
            table.Columns.Add("TotalBuyingPrice", typeof(int));



            for (int i = 0; i < dt.Rows.Count; i++)
            {

              
                string strBrandName = dt.Rows[i]["BrandName"].ToString();            
                string strBrandd = dt.Rows[i]["BrandIDD"].ToString();

                string strCategoryName = dt.Rows[i]["CategoryName"].ToString();
          
                string strSubCategoryName = dt.Rows[i]["SubCategoryName"].ToString();
      

                string strVarientName = dt.Rows[i]["Varient"].ToString();
                string strVendorName = dt.Rows[i]["name"].ToString();
                string strBuyingPrice = dt.Rows[i]["BuyingPrice"].ToString();
                string strDiscount = dt.Rows[i]["Discount"].ToString();
                string strProductVarientId = dt.Rows[i]["ProductVarientId"].ToString();

                string strProductId = dt.Rows[i]["ProductId"].ToString();
                string strFinalPrice = dt.Rows[i]["FinalPrice"].ToString();
                string strPurchaseQuantity = dt.Rows[i]["PurchaseQuantity"].ToString();
                string strOrderNo = dt.Rows[i]["OrderNo"].ToString();
                int intBrandId = Convert.ToInt32(dt.Rows[i]["BrandIDD"].ToString());

                int totalQuantityOrder = 0;
                int totalFinalPrice = 0;
                int totalDiscountPrice = 0;
                int finalPurchaseAmount = 0;
                int totalOrderNo = 0;
                int totalBuyingPrice = 0;

                int brandWiseTotal = 0;

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (intBrandId == Convert.ToInt32(dt.Rows[j]["BrandIDD"].ToString()))
                    {
                       

                            totalQuantityOrder += Convert.ToInt32(dt.Rows[j]["PurchaseQuantity"].ToString());
                            totalFinalPrice += Convert.ToInt32(dt.Rows[j]["FinalPrice"].ToString());
                            totalBuyingPrice = totalBuyingPrice + Convert.ToInt32(dt.Rows[j]["BuyingPrice"].ToString()) * Convert.ToInt32(dt.Rows[j]["PurchaseQuantity"].ToString());
                            totalDiscountPrice = totalDiscountPrice + Convert.ToInt32(dt.Rows[j]["Discount"].ToString()) * Convert.ToInt32(dt.Rows[j]["PurchaseQuantity"].ToString());
                            finalPurchaseAmount = totalBuyingPrice - totalDiscountPrice;
                            totalOrderNo++;
                            brandWiseTotal += ((Convert.ToInt32(dt.Rows[j]["BuyingPrice"].ToString())));

                    }
                }
                table.Rows.Add(strBrandName, strBrandd, strCategoryName, strSubCategoryName, strVarientName, strBuyingPrice,
                strDiscount, strProductVarientId, strProductId,
                totalQuantityOrder, totalFinalPrice, totalDiscountPrice,
                finalPurchaseAmount, brandWiseTotal, totalOrderNo, totalBuyingPrice);
            }

        
            return table;
        }

    }
}
 

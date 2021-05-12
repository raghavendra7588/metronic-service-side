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
    public class ProductVendorWisePurchaseReport
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

    public class ProductVendorWisePurchaseReportBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();

        public DataTable getData(int id)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getPurchaseReportById";
            command.Parameters.AddWithValue("@PurchaseOrderId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }


        public DataTable postAllData(PurchaseReportInventory purchaseReportInventory)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            string sql = BuildQuery(purchaseReportInventory.sellerId, purchaseReportInventory.subcategoryId, purchaseReportInventory.brandId, purchaseReportInventory.productId, purchaseReportInventory.startDate, purchaseReportInventory.endDate);

            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = sql;



            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }

        public static string BuildQuery(string SellerID, string subCategoryId, string brandId, string productId, string deliveryDate, string orderDate)
        {
            string MethodResult = "";
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(" select 'ProductNameDummy' as ProductName,'BrandNameDummy' as BrandName,'VarientNameDummy' as Varient,Mst_PurchaseOrderItem.BuyingPrice, Mst_PurchaseOrderItem.ProductVarientId, Mst_PurchaseOrderItem.ProductId,Mst_PurchaseOrderItem.FinalPrice, Mst_PurchaseOrderItem.Discount,Mst_PurchaseOrderItem.PurchaseQuantity from Mst_PurchaseOrderItem, Mst_PurchaseOrder, Mst_Vendor");
                List<string> Clauses = new List<string>();
                Clauses.Add("Mst_PurchaseOrder.PurchaseOrderId = Mst_PurchaseOrderItem.PurchaseOrderId");
                Clauses.Add("Mst_PurchaseOrder.SellerId=" + Convert.ToInt32(SellerID));

                if (subCategoryId != "ALL")
                {
                    Clauses.Add("Mst_PurchaseOrderItem.SubCategoryId IN(" + subCategoryId + ")");
                }
                if (brandId != "ALL")
                {
                    Clauses.Add("Mst_PurchaseOrderItem.BrandId IN(" + brandId + ")");
                }
                if (productId != "ALL")
                {
                    Clauses.Add("Mst_PurchaseOrderItem.ProductId IN(" + productId + ")");
                }
                if (orderDate != "ALL")
                {
                    Clauses.Add("Mst_PurchaseOrder.OrderDate>='" + orderDate + "'");
                }

                if (deliveryDate != "ALL")
                {
                    Clauses.Add("Mst_PurchaseOrder.DeliveryDate<='" + deliveryDate + "'");
                }

                bool FirstPass = true;

                if (Clauses != null && Clauses.Count > 0)
                {
                    foreach (string Clause in Clauses)
                    {
                        if (FirstPass)
                        {
                            sb.Append(" WHERE ");
                            FirstPass = false;
                        }
                        else
                        {
                            sb.Append(" AND ");
                        }
                        sb.Append(Clause);
                    }
                }
                MethodResult = sb.ToString();
            }
            catch (Exception ex)
            {
                //ex.HandleException()
            }
            return MethodResult + "  order by Mst_PurchaseOrderItem.ProductVarientId ASC";
        }

        public DataTable createReportData(DataTable dt)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("Varient", typeof(string));

            table.Columns.Add("BuyingPrice", typeof(string));
            table.Columns.Add("ProductVarientId", typeof(string));

            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("Discount", typeof(int));
            table.Columns.Add("PurchaseQuantity", typeof(int));

            table.Columns.Add("TotalQuantityOrder", typeof(int));

            table.Columns.Add("TotalFinalPrice", typeof(int));
            table.Columns.Add("TotalDiscountPrice", typeof(int));
            table.Columns.Add("FinalPurchaseAmount", typeof(int));


            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string strProductName = dt.Rows[i]["ProductName"].ToString();
                string strBrandName = dt.Rows[i]["BrandName"].ToString();
                string strVarientName = dt.Rows[i]["Varient"].ToString();

                string strBuyingPrice = dt.Rows[i]["BuyingPrice"].ToString();
                string strDiscount = dt.Rows[i]["Discount"].ToString();
                string strProductVarientId = dt.Rows[i]["ProductVarientId"].ToString();

                string strProductId = dt.Rows[i]["ProductId"].ToString();
                string strFinalPrice = dt.Rows[i]["FinalPrice"].ToString();
                string strPurchaseQuantity = dt.Rows[i]["PurchaseQuantity"].ToString();

                int totalQuantityOrder = 0;
                int totalFinalPrice = 0;
                int totalDiscountPrice = 0;
                int finalPurchaseAmount = 0;

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (strProductVarientId == dt.Rows[j]["ProductVarientId"].ToString())
                    {
                        totalQuantityOrder += Convert.ToInt32(dt.Rows[j]["PurchaseQuantity"].ToString());
                        totalFinalPrice += Convert.ToInt32(dt.Rows[j]["FinalPrice"].ToString());
                        totalDiscountPrice += Convert.ToInt32(dt.Rows[j]["Discount"].ToString());
                        finalPurchaseAmount = totalFinalPrice - totalDiscountPrice;
                    }
                }
                table.Rows.Add(strProductName, strBrandName, strVarientName, strBuyingPrice, strProductVarientId, strProductId, strDiscount, strPurchaseQuantity,
                    totalQuantityOrder, totalFinalPrice, totalDiscountPrice,
                    finalPurchaseAmount);
            }

            table = table.DefaultView.ToTable(true, "ProductVarientId", "ProductName", "Brand", "Varient", "BuyingPrice", "ProductId", "Discount", "PurchaseQuantity", "TotalQuantityOrder", "TotalFinalPrice", "TotalDiscountPrice", "FinalPurchaseAmount");
            return table;
        }

    }

}
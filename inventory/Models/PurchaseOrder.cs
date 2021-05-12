using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    public class PurchaseOrder
    {

        public int PurchaseOrderId { get; set; }
        public int SellerId { get; set; }
        public string VendorId { get; set; }
        public string vendorName { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public string ReferenceNo { get; set; }
        public string BillingId { get; set; }
        public string ShippingId { get; set; }
        public string Remarks { get; set; }
        public string ItemValue { get; set; }
        public string TaxAmount { get; set; }
        public string Taxable { get; set; }
        public string CESSAmount { get; set; }
        public string DocAmount { get; set; }
        public string AdvanceAmount { get; set; }
        public string AdvanceLedger { get; set; }      
        public string BatchNumber { get; set; }
        public string paymentTerms { get; set; }
        public List<PurchaseOrderItem> items { get; set; }
    }

    public class GetPurchaseOrder
    {
        public string sellerId { get; set; }
        public int vendorId { get; set; }
    }

    public class GetPurchaseOrderItem
    {
        public string sellerId { get; set; }
        public int vendorId { get; set; }
        public int PurchaseOrderId { get; set; }
        public string orderNo { get; set; }

    }


    public class PurchaseOrderBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();



        public DataTable getData(GetPurchaseOrder objGetPurchaseOrder)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetPurchaseOrderBySellerId";
            command.Parameters.AddWithValue("@SellerId", objGetPurchaseOrder.sellerId);
            command.Parameters.AddWithValue("@VendorId", objGetPurchaseOrder.vendorId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }

        //public DataTable geItemData(GetPurchaseOrderItem objGetPurchaseOrderItem)
        //{

        //    SqlCommand command = new SqlCommand();
        //    SqlConnection conn = new SqlConnection(strConn);
        //    command.Connection = conn;
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.CommandText = "GetAllPurchaseOrderItemData";
        //    command.Parameters.AddWithValue("@PurchaseOrderId", objGetPurchaseOrderItem.PurchaseOrderId);
        //    command.Parameters.AddWithValue("@VendorId", objGetPurchaseOrderItem.vendorId);
        //    command.Parameters.AddWithValue("@SellerId", objGetPurchaseOrderItem.sellerId);
        //    command.Parameters.AddWithValue("@OrderNo", objGetPurchaseOrderItem.orderNo);
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    conn.Open();

        //    DataSet fileData = new DataSet();
        //    adapter.Fill(fileData, "fileData");

        //    DataTable finalTable = new DataTable();
        //    DataTable stockInTable = fileData.Tables[0];
        //    DataTable purchaseOrderItemTable = fileData.Tables[1];

        //    conn.Close();
        //    finalTable.Columns.Add("StockInItemId", typeof(int));
        //    finalTable.Columns.Add("PurchaseOrderItemId", typeof(int));
        //    finalTable.Columns.Add("PurchaseOrderId", typeof(int));

        //    finalTable.Columns.Add("ProductVarientId", typeof(int));
        //    finalTable.Columns.Add("ReferenceId", typeof(int));

        //    finalTable.Columns.Add("SubCategoryId", typeof(string));
        //    finalTable.Columns.Add("BrandID", typeof(string));
        //    finalTable.Columns.Add("ProductId", typeof(string));

        //    finalTable.Columns.Add("Quantity", typeof(string));
        //    finalTable.Columns.Add("PurchaseQuantity", typeof(int));
        //    finalTable.Columns.Add("QuantityReceived", typeof(int));

        //    finalTable.Columns.Add("Discount", typeof(string));
        //    finalTable.Columns.Add("SellingPrice", typeof(int));
        //    finalTable.Columns.Add("Barcode", typeof(string));
        //    finalTable.Columns.Add("BuyingPrice", typeof(int));


        //    for (int i = 0; i < purchaseOrderItemTable.Rows.Count; i++)
        //    {
        //        int PurchaseOrderItemId= Convert.ToInt32(purchaseOrderItemTable.Rows[i]["PurchaseOrderItemId"].ToString());
        //        bool flag = false;

        //        int StockInItemId = 0;
        //        int PurchaseOrderId= 0;
        //        int ProductVarientId= 0; 
        //        int ReferenceId = 0;
        //        string SubCategoryId;
        //        string BrandID;
        //        string ProductId;
        //        string Quantity = ""; 
        //        int PurchaseQuantity = 0;
        //        int QuantityReceived = 0;
        //        int Discount = 0;
        //        int SellingPrice = 0;
        //        int BuyingPrice = 0;
        //        string BarCode="NULL";



        //        for (int j = 0; j < stockInTable.Rows.Count; j++)
        //        {
        //            if (PurchaseOrderItemId == Convert.ToInt32(stockInTable.Rows[j]["PurchaseOrderItemId"].ToString()))
        //            {
        //                // edit 
        //                PurchaseOrderItemId = Convert.ToInt32(stockInTable.Rows[i]["PurchaseOrderItemId"].ToString());
        //                StockInItemId = Convert.ToInt32(stockInTable.Rows[j]["StockInItemId"].ToString());
        //                PurchaseOrderId= Convert.ToInt32(stockInTable.Rows[j]["PurchaseOrderId"].ToString());
        //                ProductVarientId = Convert.ToInt32(stockInTable.Rows[j]["ProductVarientId"].ToString());
        //                ReferenceId = Convert.ToInt32(stockInTable.Rows[j]["ReferenceId"].ToString());

        //                QuantityReceived = Convert.ToInt32(stockInTable.Rows[j]["QuantityReceived"].ToString());
        //                Discount = Convert.ToInt32(stockInTable.Rows[j]["Discount"].ToString());
        //                SellingPrice = Convert.ToInt32(stockInTable.Rows[j]["SellingPrice"].ToString());
        //                BarCode = (stockInTable.Rows[j]["BarCode"].ToString());
        //                //BuyingPrice= Convert.ToInt32(stockInTable.Rows[j]["BuyingPrice"].ToString());
        //                flag = true;

        //            }

        //        }

        //        if (flag==false)
        //        {
        //            PurchaseOrderItemId = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["PurchaseOrderItemId"].ToString());                   
        //            PurchaseOrderId = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["PurchaseOrderId"].ToString());
        //            ProductVarientId = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["ProductVarientId"].ToString());
        //            ReferenceId = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["ReferenceId"].ToString());                    
        //            Discount = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["Discount"].ToString());
        //            BuyingPrice = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["BuyingPrice"].ToString());
        //            StockInItemId = 0;
        //            SellingPrice = 0;
        //            QuantityReceived = 0;
        //            BarCode = "NULL";

        //        }
        //        SubCategoryId = purchaseOrderItemTable.Rows[i]["SubCategoryId"].ToString();
        //        BrandID = purchaseOrderItemTable.Rows[i]["BrandId"].ToString();
        //        ProductId = purchaseOrderItemTable.Rows[i]["ProductId"].ToString();
        //        Quantity = (purchaseOrderItemTable.Rows[i]["Quantity"].ToString());
        //        PurchaseQuantity = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["PurchaseQuantity"].ToString());


        //        if (PurchaseQuantity != QuantityReceived)
        //        {
        //            finalTable.Rows.Add(StockInItemId, PurchaseOrderItemId, PurchaseOrderId, ProductVarientId, ReferenceId,
        //                SubCategoryId, BrandID, ProductId,
        //         Quantity, PurchaseQuantity, QuantityReceived, Discount, SellingPrice, BarCode, BuyingPrice);
        //        }

        //    }
        //    return finalTable;
        //}

        public DataTable geItemData(GetPurchaseOrderItem objGetPurchaseOrderItem)
        {

            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetAllPurchaseOrderItemData";
            command.Parameters.AddWithValue("@PurchaseOrderId", objGetPurchaseOrderItem.PurchaseOrderId);
            command.Parameters.AddWithValue("@VendorId", objGetPurchaseOrderItem.vendorId);
            command.Parameters.AddWithValue("@SellerId", objGetPurchaseOrderItem.sellerId);
            command.Parameters.AddWithValue("@OrderNo", objGetPurchaseOrderItem.orderNo);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");

            DataTable finalTable = new DataTable();
            DataTable stockInTable = fileData.Tables[0];
            DataTable purchaseOrderItemTable = fileData.Tables[1];

            conn.Close();
            finalTable.Columns.Add("StockInItemId", typeof(int));
            finalTable.Columns.Add("PurchaseOrderItemId", typeof(int));
            finalTable.Columns.Add("PurchaseOrderId", typeof(int));

            finalTable.Columns.Add("ProductVarientId", typeof(int));
            finalTable.Columns.Add("ReferenceId", typeof(int));

            finalTable.Columns.Add("SubCategoryId", typeof(string));
            finalTable.Columns.Add("BrandID", typeof(string));
            finalTable.Columns.Add("ProductId", typeof(string));


            finalTable.Columns.Add("SubCategoryIDD", typeof(string));
            finalTable.Columns.Add("BrandIDD", typeof(string));
            finalTable.Columns.Add("ProductIDD", typeof(string));

            finalTable.Columns.Add("Quantity", typeof(string));
            finalTable.Columns.Add("PurchaseQuantity", typeof(int));
            finalTable.Columns.Add("QuantityReceived", typeof(int));

            finalTable.Columns.Add("Discount", typeof(string));
            finalTable.Columns.Add("SellingPrice", typeof(int));
            finalTable.Columns.Add("Barcode", typeof(string));
            finalTable.Columns.Add("BuyingPrice", typeof(int));


            for (int i = 0; i < purchaseOrderItemTable.Rows.Count; i++)
            {
                int PurchaseOrderItemId = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["PurchaseOrderItemId"].ToString());
                bool flag = false;

                int StockInItemId = 0;
                int PurchaseOrderId = 0;
                int ProductVarientId = 0;
                int ReferenceId = 0;
                string SubCategoryId;
                string BrandID;
                string ProductId;

                string SubCategoryIDD;
                string BrandIDD;
                string ProductIDD;

                string Quantity = "";
                int PurchaseQuantity = 0;
                int QuantityReceived = 0;
                int Discount = 0;
                int SellingPrice = 0;
                int BuyingPrice = 0;
                string BarCode = "NULL";



                for (int j = 0; j < stockInTable.Rows.Count; j++)
                {
                    if (PurchaseOrderItemId == Convert.ToInt32(stockInTable.Rows[j]["PurchaseOrderItemId"].ToString()))
                    {
                        // edit 
                        PurchaseOrderItemId = Convert.ToInt32(stockInTable.Rows[i]["PurchaseOrderItemId"].ToString());
                        StockInItemId = Convert.ToInt32(stockInTable.Rows[j]["StockInItemId"].ToString());
                        PurchaseOrderId = Convert.ToInt32(stockInTable.Rows[j]["PurchaseOrderId"].ToString());
                        ProductVarientId = Convert.ToInt32(stockInTable.Rows[j]["ProductVarientId"].ToString());
                        ReferenceId = Convert.ToInt32(stockInTable.Rows[j]["ReferenceId"].ToString());

                        QuantityReceived = Convert.ToInt32(stockInTable.Rows[j]["QuantityReceived"].ToString());
                        Discount = Convert.ToInt32(stockInTable.Rows[j]["Discount"].ToString());
                        SellingPrice = Convert.ToInt32(stockInTable.Rows[j]["SellingPrice"].ToString());
                        BarCode = (stockInTable.Rows[j]["BarCode"].ToString());
                        //BuyingPrice= Convert.ToInt32(stockInTable.Rows[j]["BuyingPrice"].ToString());
                        flag = true;

                    }

                }

                if (flag == false)
                {
                    PurchaseOrderItemId = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["PurchaseOrderItemId"].ToString());
                    PurchaseOrderId = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["PurchaseOrderId"].ToString());
                    ProductVarientId = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["ProductVarientId"].ToString());
                    ReferenceId = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["ReferenceId"].ToString());
                    Discount = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["Discount"].ToString());
                    BuyingPrice = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["BuyingPrice"].ToString());
                    StockInItemId = 0;
                    SellingPrice = 0;
                    QuantityReceived = 0;
                    BarCode = "NULL";

                }
                SubCategoryId = (purchaseOrderItemTable.Rows[i]["SubCategoryId"].ToString());
                BrandID = (purchaseOrderItemTable.Rows[i]["BrandId"].ToString());
                ProductId = (purchaseOrderItemTable.Rows[i]["ProductId"].ToString());

                SubCategoryIDD = (purchaseOrderItemTable.Rows[i]["SubCategoryIDD"].ToString());
                BrandIDD = (purchaseOrderItemTable.Rows[i]["BrandIDD"].ToString());
                ProductIDD = (purchaseOrderItemTable.Rows[i]["ProductIDD"].ToString());

                Quantity = (purchaseOrderItemTable.Rows[i]["Quantity"].ToString());
                PurchaseQuantity = Convert.ToInt32(purchaseOrderItemTable.Rows[i]["PurchaseQuantity"].ToString());


                if (PurchaseQuantity != QuantityReceived)
                {
                    finalTable.Rows.Add(StockInItemId, PurchaseOrderItemId, PurchaseOrderId, 
                        ProductVarientId, ReferenceId, SubCategoryId, BrandID, ProductId,
                        SubCategoryIDD, BrandIDD, ProductIDD,
                 Quantity, PurchaseQuantity, QuantityReceived, Discount, SellingPrice, BarCode, BuyingPrice);
                }

            }
            return finalTable;
        }

        public PurchaseOrder postPurchaseOrderToDb(PurchaseOrder purchaseOrderData)
        {
            PurchaseOrder objResultReturn = new PurchaseOrder();
            PurchaseOrderItemBL ObjPurchaseOrderItemBL = new PurchaseOrderItemBL();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_insertPurchaseOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SellerId", purchaseOrderData.SellerId);
            cmd.Parameters.AddWithValue("@VendorId", purchaseOrderData.VendorId);
            cmd.Parameters.AddWithValue("@OrderNo", purchaseOrderData.OrderNo);
            cmd.Parameters.AddWithValue("@OrderDate", purchaseOrderData.OrderDate);
            cmd.Parameters.AddWithValue("@DeliveryDate", purchaseOrderData.DeliveryDate);
            cmd.Parameters.AddWithValue("@ReferenceNo", purchaseOrderData.ReferenceNo);
            cmd.Parameters.AddWithValue("@BillingId", purchaseOrderData.BillingId);
            cmd.Parameters.AddWithValue("@ShippingId", purchaseOrderData.ShippingId);
            cmd.Parameters.AddWithValue("@Remarks", purchaseOrderData.Remarks);

            cmd.Parameters.AddWithValue("@ItemValue", purchaseOrderData.ItemValue);
            cmd.Parameters.AddWithValue("@TaxAmount", purchaseOrderData.TaxAmount);
            cmd.Parameters.AddWithValue("@Taxable", purchaseOrderData.Taxable);
            cmd.Parameters.AddWithValue("@CESSAmount", purchaseOrderData.CESSAmount);
            cmd.Parameters.AddWithValue("@DocAmount", purchaseOrderData.DocAmount);
            cmd.Parameters.AddWithValue("@AdvanceAmount", purchaseOrderData.AdvanceAmount);
            cmd.Parameters.AddWithValue("@AdvanceLedger", purchaseOrderData.AdvanceLedger);
            cmd.Parameters.AddWithValue("@BatchNumber", purchaseOrderData.BatchNumber);
            cmd.Parameters.AddWithValue("@paymentTerms", purchaseOrderData.paymentTerms);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            conn.Close();
            int id = (int)cmd.Parameters["@id"].Value;
            objResultReturn.PurchaseOrderId = id;
            objResultReturn.OrderNo = purchaseOrderData.OrderNo;
            objResultReturn.vendorName = purchaseOrderData.vendorName;
            ObjPurchaseOrderItemBL.postPurchaseOrderItemToDb(purchaseOrderData.items, id);
            return objResultReturn;
        }

    }
}
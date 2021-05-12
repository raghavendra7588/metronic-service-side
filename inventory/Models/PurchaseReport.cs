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
    public class PurchaseReport
    {
        public string vendorId { get; set; }
        public string orderNo { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string sellerId { get; set; }
    }

    public class PurchaseReportBL
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


        public DataTable postAllData(PurchaseReport purchaseReport)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            //string sql = BuildQuery(purchaseReport.sellerId, purchaseReport.vendorId, purchaseReport.orderNo, purchaseReport.startDate, purchaseReport.endDate);
            conn.Open();

            command.Connection = conn;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_PurchaseReport_Vendor_Order_Wise_DATA";

            command.Parameters.AddWithValue("@vendorId", purchaseReport.vendorId);
            command.Parameters.AddWithValue("@SellerId", purchaseReport.sellerId);
            command.Parameters.AddWithValue("@orderNO", purchaseReport.orderNo);
            command.Parameters.AddWithValue("@OrderDate", purchaseReport.startDate);
            command.Parameters.AddWithValue("@DeliveryDate", purchaseReport.endDate);
 



            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }

        public static string BuildQuery(string SellerID, string VendorID, string orderNO, string OrderDate, string DeliveryDate)
        {
            string MethodResult = "";
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("select Mst_Vendor.name as vendor_name,Mst_PurchaseOrder.PurchaseOrderId,FORMAT(Mst_PurchaseOrder.CreatedAt,'dd/MM/yyyy hh:mm:ss') as CreatedAt,Mst_PurchaseOrder.OrderNo,Mst_PurchaseOrder.OrderDate,Mst_PurchaseOrder.DeliveryDate,Mst_PurchaseOrder.BatchNumber from Mst_Vendor,Mst_PurchaseOrder");

                List<string> Clauses = new List<string>();

                Clauses.Add("Mst_PurchaseOrder.vendorId=Mst_Vendor.vendorId");
                Clauses.Add("Mst_PurchaseOrder.SellerId=" + Convert.ToInt32(SellerID));

                if (VendorID != "ALL")
                {
                    Clauses.Add("Mst_PurchaseOrder.vendorId=" + Convert.ToInt32(VendorID));
                }
                if (orderNO != "ALL")
                {
                    Clauses.Add("Mst_PurchaseOrder.orderNo='" + orderNO + "'");
                }
                if (OrderDate != "ALL")
                {
                    Clauses.Add("Mst_PurchaseOrder.OrderDate >='" + OrderDate + "'");
                }
                if (DeliveryDate != "ALL")
                {
                    Clauses.Add("Mst_PurchaseOrder.DeliveryDate<='" + DeliveryDate + "'");
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
            return MethodResult + "  order by CreatedAt desc";
        }



    }
}
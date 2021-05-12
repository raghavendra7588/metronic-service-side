using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    public class Payment
    {
        public string sellerId { get; set; }
        public string vendorName { get; set; }
        public string vendorCode { get; set; }
        public DateTime tempStartDate { get; set; }
        public DateTime tempExpiryDate { get; set; }
    }

    public class UpdatePaymentMode
    {
        public int SellerId { get; set; }
        public int UpdatedBySellerId { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentAmount { get; set; }
    }

    public class UpdateInActiveState
    {
        public int SellerId { get; set; }
        public int UpdatedBySellerId { get; set; }
        public DateTime InactivatedDate { get; set; }
        public string InactiveReason { get; set; }       
        public string CurrentStatus { get; set; }
        public DateTime updatedExpiryDate { get; set; }
    }

    public class UpdatePaymentDetails
    {
        public int SellerId { get; set; }
        public string TrasnsactionId { get; set; }
        public string Amount { get; set; }
        public DateTime NewExpiryDate { get; set; }
        public string CurrentStatus { get; set; }
        public int PaymentId { get; set; }
        public string VendorName { get; set; }
        public string VendorCode { get; set; }
        public DateTime SubscritpionStartDate { get; set; }
    }

    public class StatusCheckpoint
    {
        public int PaymentId { get; set; }
    }

    public class TransactionHistory
    {
        public int SellerId { get; set; }
        public DateTime CurrentDate { get; set; }
    }

    public class PaymentBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();
        public DataTable getSellerPaymentData(Payment objPayment)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetSellerPaymentValidationDetails";
            command.Parameters.AddWithValue("@SellerId", objPayment.sellerId);
            command.Parameters.AddWithValue("@VendorCode", objPayment.vendorCode);
            command.Parameters.AddWithValue("@VendorName", objPayment.vendorName);
            command.Parameters.AddWithValue("@TempStartDate", objPayment.tempStartDate);
            command.Parameters.AddWithValue("@TempExpiryDate", objPayment.tempExpiryDate);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }

        public DataTable getPaymentMode()
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetPaymentMode";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();
            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }


        public string updatePaymentMode(UpdatePaymentMode updatePaymentModeData)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_updateSellerPaymentMode", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SellerId", updatePaymentModeData.SellerId);
            cmd.Parameters.AddWithValue("@UpdatedBySellerId", updatePaymentModeData.UpdatedBySellerId);
            cmd.Parameters.AddWithValue("@PaymentAmount", updatePaymentModeData.PaymentAmount);
            cmd.Parameters.AddWithValue("@PaymentMode", updatePaymentModeData.PaymentMode);


            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
        }



        public DataTable transactionHistoryBySeller(int id)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetSellerSubscriptionHistory";
            command.Parameters.AddWithValue("@SellerId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();
            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }

        public string updatePreviousTransationsData(TransactionHistory objTransactionHistory)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_UpdatePreviousTransactions", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SellerId", objTransactionHistory.SellerId);
            cmd.Parameters.AddWithValue("@CurrentDate", objTransactionHistory.CurrentDate);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
        }


        public string updateInactiveStatus(UpdateInActiveState updateInActiveStateData)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_updateSellerActiveStatus", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SellerId", updateInActiveStateData.SellerId);
            cmd.Parameters.AddWithValue("@UpdatedBySellerId", updateInActiveStateData.SellerId);
            cmd.Parameters.AddWithValue("@InactiveReason", updateInActiveStateData.InactiveReason);
            cmd.Parameters.AddWithValue("@InactivatedDate", updateInActiveStateData.InactivatedDate);
            cmd.Parameters.AddWithValue("@CurrentStatus", updateInActiveStateData.CurrentStatus);
            cmd.Parameters.AddWithValue("@UpdatedExpiryDate", updateInActiveStateData.updatedExpiryDate);
          
            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
        }



        public DataTable GetLastestTransactionBySeller(int id)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetLatestTransactionBySellerId";
            command.Parameters.AddWithValue("@SellerId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();
            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;
        }

        public string updatePaymentDetails(UpdatePaymentDetails updatePaymentDetailsData)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_updatePaymentDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SellerId", updatePaymentDetailsData.SellerId);
            cmd.Parameters.AddWithValue("@TransactionID", updatePaymentDetailsData.TrasnsactionId);
            cmd.Parameters.AddWithValue("@Amount", updatePaymentDetailsData.Amount);
            cmd.Parameters.AddWithValue("@CurrentStatus", updatePaymentDetailsData.CurrentStatus);
            cmd.Parameters.AddWithValue("@NewExpiryDate", updatePaymentDetailsData.NewExpiryDate);
            cmd.Parameters.AddWithValue("@PaymentId", updatePaymentDetailsData.PaymentId);
            cmd.Parameters.AddWithValue("@VendorCode", updatePaymentDetailsData.VendorCode);
            cmd.Parameters.AddWithValue("@VendorName", updatePaymentDetailsData.VendorName);
            cmd.Parameters.AddWithValue("@SubscritpionStartDate", updatePaymentDetailsData.SubscritpionStartDate);
            
            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
        }

        public string PostSellerStatusCheckpoint(StatusCheckpoint objStatusCheckpoint)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_SellerActiveStatusCheckPoint", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PaymenId", objStatusCheckpoint.PaymentId);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
        }

    }
}
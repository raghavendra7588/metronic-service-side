using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using inventory.Models;

namespace inventory.Models
{
    public class Vendor
    {
  
        public string SellerId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string underLedger { get; set; }
        public string contactPerson { get; set; }
        public string printName { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public string brand { get; set; }
        public string fileUpload { get; set; }
        public string gst { get; set; }
        public string gstCategory { get; set; }
        public string pan { get; set; }
        public string registrationDate { get; set; }
        public string distance { get; set; }
        public string cin { get; set; }
        public string creditLimitDays { get; set; }
        public string priceCategory { get; set; }
        public string agentBroker { get; set; }
        public string transporter { get; set; }
        public string creditLimit { get; set; }
        public string ifscCode { get; set; }
        public string accountNumber { get; set; }
        public string bankName { get; set; }
        public string branch { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pinCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string email { get; set; } 
        public string accountName { get; set; }
        public string accountType { get; set; }
    }


}


public class VenodrBL
{


    string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();


    public DataTable getAllData(string strId)
    {
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(strConn);
        command.Connection = conn;
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "Mst_getAllVendorData";
        command.Parameters.AddWithValue("@SellerId", strId);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        conn.Open();

        DataSet fileData = new DataSet();
        adapter.Fill(fileData, "fileData");
        conn.Close();
        DataTable firstTable = fileData.Tables[0];
        return firstTable;

    }


    public void postVendorDataToDb(Vendor objVendor)
    {

        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        SqlCommand cmd = new SqlCommand("Mst_insertVendorMaster", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@sellerId", objVendor.SellerId);
        cmd.Parameters.AddWithValue("@code", objVendor.code);
        cmd.Parameters.AddWithValue("@name", objVendor.name);
        cmd.Parameters.AddWithValue("@underLedger", objVendor.underLedger);
        cmd.Parameters.AddWithValue("@contactPerson", objVendor.contactPerson);
        cmd.Parameters.AddWithValue("@printName", objVendor.printName);
   

        if (objVendor.category == "NULL")
        {
            objVendor.category = "";
            cmd.Parameters.AddWithValue("@category", objVendor.category);
        }
        else
        {
            cmd.Parameters.AddWithValue("@category", objVendor.category);
        }

        if (objVendor.subCategory == "NULL")
        {
            objVendor.subCategory = "";
            cmd.Parameters.AddWithValue("@subCategory", objVendor.subCategory);
        }
        else
        {
            cmd.Parameters.AddWithValue("@subCategory", objVendor.subCategory);
        }

        if (objVendor.brand == "NULL")
        {
            objVendor.brand = "";
            cmd.Parameters.AddWithValue("@brand", objVendor.brand);
        }
        else
        {
            cmd.Parameters.AddWithValue("@brand", objVendor.brand);
        }
    
        cmd.Parameters.AddWithValue("@fileUpload", objVendor.fileUpload);
        cmd.Parameters.AddWithValue("@gst", objVendor.gst);
        cmd.Parameters.AddWithValue("@gstCategory", objVendor.gstCategory);
        cmd.Parameters.AddWithValue("@pan", objVendor.pan);
        cmd.Parameters.AddWithValue("@registrationDate", objVendor.registrationDate);
        cmd.Parameters.AddWithValue("@distance", objVendor.distance);
        cmd.Parameters.AddWithValue("@cin", objVendor.cin);
        cmd.Parameters.AddWithValue("@creditLimitDays", objVendor.creditLimitDays);
        cmd.Parameters.AddWithValue("@priceCategory", objVendor.priceCategory);
        cmd.Parameters.AddWithValue("@agentBroker", objVendor.agentBroker);
        cmd.Parameters.AddWithValue("@transporter", objVendor.transporter);
        cmd.Parameters.AddWithValue("@creditLimit", objVendor.creditLimit);
        cmd.Parameters.AddWithValue("@ifscCode", objVendor.ifscCode);
        cmd.Parameters.AddWithValue("@accountNumber", objVendor.accountNumber);
        cmd.Parameters.AddWithValue("@bankName", objVendor.bankName);
        cmd.Parameters.AddWithValue("@branch", objVendor.branch);

        cmd.Parameters.AddWithValue("@address", objVendor.address);
        cmd.Parameters.AddWithValue("@city", objVendor.city);
        cmd.Parameters.AddWithValue("@pinCode", objVendor.pinCode);

        cmd.Parameters.AddWithValue("@state", objVendor.state);
        cmd.Parameters.AddWithValue("@country", objVendor.country);
        cmd.Parameters.AddWithValue("@phone", objVendor.phone);
        cmd.Parameters.AddWithValue("@email", objVendor.email);
        cmd.Parameters.AddWithValue("@accountName", objVendor.accountName);
        cmd.Parameters.AddWithValue("@accountType", objVendor.accountType);

        cmd.ExecuteNonQuery();
        conn.Close();
    }


    public void updateVendorDataToDb(Vendor objVendor, int vendorId)
    {

        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        SqlCommand cmd = new SqlCommand("Mst_updateVendorMaster", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@sellerId", objVendor.SellerId);
        cmd.Parameters.AddWithValue("@vendorId", vendorId);
        cmd.Parameters.AddWithValue("@code", objVendor.code);
        cmd.Parameters.AddWithValue("@name", objVendor.name);
        cmd.Parameters.AddWithValue("@underLedger", objVendor.underLedger);
        cmd.Parameters.AddWithValue("@contactPerson", objVendor.contactPerson);
        cmd.Parameters.AddWithValue("@printName", objVendor.printName);
        cmd.Parameters.AddWithValue("@category", objVendor.category);
        cmd.Parameters.AddWithValue("@subCategory", objVendor.subCategory);
        cmd.Parameters.AddWithValue("@brand", objVendor.brand);
        cmd.Parameters.AddWithValue("@fileUpload", objVendor.fileUpload);
        cmd.Parameters.AddWithValue("@gst", objVendor.gst);
        cmd.Parameters.AddWithValue("@gstCategory", objVendor.gstCategory);
        cmd.Parameters.AddWithValue("@pan", objVendor.pan);
        cmd.Parameters.AddWithValue("@registrationDate", objVendor.registrationDate);
        cmd.Parameters.AddWithValue("@distance", objVendor.distance);
        cmd.Parameters.AddWithValue("@cin", objVendor.cin);
        cmd.Parameters.AddWithValue("@creditLimitDays", objVendor.creditLimitDays);
        cmd.Parameters.AddWithValue("@priceCategory", objVendor.priceCategory);
        cmd.Parameters.AddWithValue("@agentBroker", objVendor.agentBroker);
        cmd.Parameters.AddWithValue("@transporter", objVendor.transporter);
        cmd.Parameters.AddWithValue("@creditLimit", objVendor.creditLimit);
        cmd.Parameters.AddWithValue("@ifscCode", objVendor.ifscCode);
        cmd.Parameters.AddWithValue("@accountNumber", objVendor.accountNumber);
        cmd.Parameters.AddWithValue("@bankName", objVendor.bankName);
        cmd.Parameters.AddWithValue("@branch", objVendor.branch);

        cmd.Parameters.AddWithValue("@address", objVendor.address);
        cmd.Parameters.AddWithValue("@city", objVendor.city);
        cmd.Parameters.AddWithValue("@pinCode", objVendor.pinCode);

        cmd.Parameters.AddWithValue("@state", objVendor.state);
        cmd.Parameters.AddWithValue("@country", objVendor.country);
        cmd.Parameters.AddWithValue("@phone", objVendor.phone);
        cmd.Parameters.AddWithValue("@email", objVendor.email);
        cmd.Parameters.AddWithValue("@accountName", objVendor.accountName);
        cmd.Parameters.AddWithValue("@accountType", objVendor.accountType);

        cmd.ExecuteNonQuery();
        conn.Close();
    }


    public DataTable getSellerContactCredentials(int sellerId)
    {
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(strConn);
        command.Connection = conn;
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "Mst_GetSellerContactCredentials";
        command.Parameters.AddWithValue("@SellerId", sellerId);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        conn.Open();
        DataSet fileData = new DataSet();
        adapter.Fill(fileData, "fileData");
        conn.Close();
        DataTable firstTable = fileData.Tables[0];
        return firstTable;
    }

}


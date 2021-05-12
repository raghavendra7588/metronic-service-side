using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace inventory.Models
{
    public class Address
    {
        public string id { get; set; }
        public string sellerName { get; set; }
        public int sellerId { get; set; }
        public string billing_address { get; set; }
        public string billing_city { get; set; }
        public string billing_pinCode { get; set; }
        public string billing_country { get; set; }
        public string billing_state { get; set; }
        public string billing_phone { get; set; }
        public string billing_email { get; set; }
        public string shipping_address { get; set; }
        public string shipping_city { get; set; }
        public string shipping_pinCode { get; set; }
        public string shipping_country { get; set; }
        public string shipping_state { get; set; }
        public string shipping_phone { get; set; }
        public string shipping_email { get; set; }
        public string billingName { get; set; }
        public string shippingName { get; set; }

    }

    public class AddressBL
    {
        string strConn = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();



        public DataTable getAllData(int id)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = new SqlConnection(strConn);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Mst_GetAddressData";
            command.Parameters.AddWithValue("@sellerId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.Open();

            DataSet fileData = new DataSet();
            adapter.Fill(fileData, "fileData");
            conn.Close();
            DataTable firstTable = fileData.Tables[0];
            return firstTable;

        }

        public string postAddressToDb(Address addressData)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_insertAddress", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@sellerName", addressData.sellerName);
            cmd.Parameters.AddWithValue("@sellerId", addressData.sellerId);
            cmd.Parameters.AddWithValue("@billing_address", addressData.billing_address);
            cmd.Parameters.AddWithValue("@billing_city", addressData.billing_city);
            cmd.Parameters.AddWithValue("@billing_pinCode", addressData.billing_pinCode);
            cmd.Parameters.AddWithValue("@billing_country", addressData.billing_country);
            cmd.Parameters.AddWithValue("@billing_state", addressData.billing_state);
            cmd.Parameters.AddWithValue("@billing_phone", addressData.billing_phone);
            cmd.Parameters.AddWithValue("@billing_email", addressData.billing_email);
            
            cmd.Parameters.AddWithValue("@shipping_address", addressData.shipping_address);
            cmd.Parameters.AddWithValue("@shipping_city", addressData.shipping_city);
            cmd.Parameters.AddWithValue("@shipping_pinCode", addressData.shipping_pinCode);
            cmd.Parameters.AddWithValue("@shipping_country", addressData.shipping_country);
            cmd.Parameters.AddWithValue("@shipping_state", addressData.shipping_state);
            cmd.Parameters.AddWithValue("@shipping_phone", addressData.shipping_phone);
            cmd.Parameters.AddWithValue("@shipping_email", addressData.shipping_email);

            cmd.Parameters.AddWithValue("@billingName", addressData.billingName);
            cmd.Parameters.AddWithValue("@shippingName", addressData.shippingName);
            

            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
        }

        public string updateAddressToDb(Address addressData, int id)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Mst_updateAddressMaster", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@sellerName", addressData.sellerName);
            cmd.Parameters.AddWithValue("@sellerId", addressData.sellerId);
            cmd.Parameters.AddWithValue("@billing_address", addressData.billing_address);
            cmd.Parameters.AddWithValue("@billing_city", addressData.billing_city);
            cmd.Parameters.AddWithValue("@billing_pinCode", addressData.billing_pinCode);
            cmd.Parameters.AddWithValue("@billing_country", addressData.billing_country);
            cmd.Parameters.AddWithValue("@billing_state", addressData.billing_state);
            cmd.Parameters.AddWithValue("@billing_phone", addressData.billing_phone);
            cmd.Parameters.AddWithValue("@billing_email", addressData.billing_email);
          
            cmd.Parameters.AddWithValue("@shipping_address", addressData.shipping_address);
            cmd.Parameters.AddWithValue("@shipping_city", addressData.shipping_city);
            cmd.Parameters.AddWithValue("@shipping_pinCode", addressData.shipping_pinCode);
            cmd.Parameters.AddWithValue("@shipping_country", addressData.shipping_country);
            cmd.Parameters.AddWithValue("@shipping_state", addressData.shipping_state);
            cmd.Parameters.AddWithValue("@shipping_phone", addressData.shipping_phone);
            cmd.Parameters.AddWithValue("@shipping_email", addressData.shipping_email);

            cmd.Parameters.AddWithValue("@billingName", addressData.billingName);
            cmd.Parameters.AddWithValue("@shippingName", addressData.shippingName);

            cmd.ExecuteNonQuery();
            conn.Close();
            return "ok";
        }
    }
}
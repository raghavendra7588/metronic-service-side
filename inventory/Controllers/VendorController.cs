using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using inventory.Models;

namespace inventory.Controllers
{
    public class VendorController : ApiController
    {
        VenodrBL ObjVendorBL = new VenodrBL();


        [HttpGet]
        public HttpResponseMessage getall(int id)
        {
            string strId = id.ToString();
            try
            {
                Vendor ObjVendor = new Vendor();
                DataTable dt = ObjVendorBL.getAllData(strId);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Vendor/SellerContactCredentials/{id:int}")]
        public HttpResponseMessage getSellerCredentialsData(int id)
        {
            try
            {
                DataTable dt = ObjVendorBL.getSellerContactCredentials(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }


        [HttpPost]
        public HttpResponseMessage Post()
        {
            Vendor objVendor = new Vendor();

            string strVendorId = HttpContext.Current.Request.Params.Get("vendorId");
            objVendor.SellerId = HttpContext.Current.Request.Params.Get("sellerId");
            objVendor.code = HttpContext.Current.Request.Params.Get("code");
            objVendor.name = HttpContext.Current.Request.Params.Get("name");
            objVendor.underLedger = HttpContext.Current.Request.Params.Get("underLedger");
            objVendor.contactPerson = HttpContext.Current.Request.Params.Get("contactPerson");
            objVendor.printName = HttpContext.Current.Request.Params.Get("printName");
            objVendor.category = HttpContext.Current.Request.Params.Get("category");
            objVendor.subCategory = HttpContext.Current.Request.Params.Get("subCategory");
            objVendor.brand = HttpContext.Current.Request.Params.Get("brand");
            objVendor.fileUpload = HttpContext.Current.Request.Params.Get("FileName");
            objVendor.gst = HttpContext.Current.Request.Params.Get("gst");
            objVendor.gstCategory = HttpContext.Current.Request.Params.Get("gstCategory");
            objVendor.pan = HttpContext.Current.Request.Params.Get("pan");
            objVendor.registrationDate = HttpContext.Current.Request.Params.Get("registrationDate");
            objVendor.distance = HttpContext.Current.Request.Params.Get("distance");
            objVendor.cin = HttpContext.Current.Request.Params.Get("cin");

            objVendor.creditLimitDays = HttpContext.Current.Request.Params.Get("creditLimitDays");
            objVendor.priceCategory = HttpContext.Current.Request.Params.Get("priceCategory");
            objVendor.agentBroker = HttpContext.Current.Request.Params.Get("agentBroker");
            objVendor.transporter = HttpContext.Current.Request.Params.Get("transporter");
            objVendor.creditLimit = HttpContext.Current.Request.Params.Get("creditLimit");
            objVendor.ifscCode = HttpContext.Current.Request.Params.Get("ifscCode");
            objVendor.accountNumber = HttpContext.Current.Request.Params.Get("accountNumber");
            objVendor.bankName = HttpContext.Current.Request.Params.Get("bankName");
            objVendor.branch = HttpContext.Current.Request.Params.Get("branch");

            objVendor.address = HttpContext.Current.Request.Params.Get("address");
            objVendor.city = HttpContext.Current.Request.Params.Get("city");
            objVendor.pinCode = HttpContext.Current.Request.Params.Get("pinCode");

            objVendor.state = HttpContext.Current.Request.Params.Get("state");
            objVendor.country = HttpContext.Current.Request.Params.Get("country");
            objVendor.phone = HttpContext.Current.Request.Params.Get("phone");
            objVendor.email = HttpContext.Current.Request.Params.Get("email");
            objVendor.accountName = HttpContext.Current.Request.Params.Get("accountName");
            objVendor.accountType = HttpContext.Current.Request.Params.Get("accountType");

            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            if (!string.IsNullOrEmpty(objVendor.fileUpload))
            {

                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string file in httpRequest.Files)
                    {
                        string finalPath = string.Empty;
                        var postedFile = httpRequest.Files[file];
                        var filePath = HttpContext.Current.Server.MapPath("~/uploadDocuments/vendor/" + postedFile.FileName);
                        if (!File.Exists(filePath))
                        {
                            postedFile.SaveAs(filePath);
                            finalPath = "/uploadDocuments/" + postedFile.FileName;
                        }
                        else
                        {
                            Random rnd = new Random();
                            int randomNumber = rnd.Next(1, 10001);
                            string randomNumberString = randomNumber.ToString();

                            string filePathnew = HttpContext.Current.Server.MapPath("~/uploadDocuments/vendor/" + randomNumberString + postedFile.FileName);
                            postedFile.SaveAs(filePathnew);
                            finalPath = "/uploadDocuments/vendor/" + randomNumberString + postedFile.FileName;
                            objVendor.fileUpload = finalPath;
                        }
                        docfiles.Add("/uploadDocuments/vendor/" + postedFile.FileName);


                    }
                    result = Request.CreateResponse(HttpStatusCode.Created, docfiles);

                }
            }


            else
            {
                objVendor.fileUpload = string.Empty;
            }
            if (Convert.ToInt32(strVendorId) == 0)
            {
                ObjVendorBL.postVendorDataToDb(objVendor);
                result = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                ObjVendorBL.updateVendorDataToDb(objVendor, Convert.ToInt32(strVendorId));
                result = Request.CreateResponse(HttpStatusCode.OK);
            }
            return result;
        }




    }
}

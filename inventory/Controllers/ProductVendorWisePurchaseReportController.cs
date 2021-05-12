using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using inventory.Models;

namespace inventory.Controllers
{
    public class ProductVendorWisePurchaseReportController : ApiController
    {

        ProductsVendorWisePurchaseReportBL objProductsVendorWisePurchaseReportBL = new ProductsVendorWisePurchaseReportBL();

        [HttpPost]
        public HttpResponseMessage postall(ProductsVendorWisePurchaseReport objProductsVendorWisePurchaseReportReport)
        {
            try
            {
                DataTable dt = objProductsVendorWisePurchaseReportBL.postAllData(objProductsVendorWisePurchaseReportReport);
                DataTable reportData = objProductsVendorWisePurchaseReportBL.createReportData(dt);
                return Request.CreateResponse(HttpStatusCode.OK, reportData);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/ProductVendorWisePurchaseReport/brandVendorWisePurchaseReport")]
        public HttpResponseMessage postBrandVendorWisePurchaseReportall(ProductsVendorWisePurchaseReport objProductsVendorWisePurchaseReportReport)
        {
            try
            {
                DataTable dt = objProductsVendorWisePurchaseReportBL.postBrandVendorData(objProductsVendorWisePurchaseReportReport);
                DataTable reportData = objProductsVendorWisePurchaseReportBL.createBrandVendorWiseReportData(dt);
                return Request.CreateResponse(HttpStatusCode.OK, reportData);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("api/ProductVendorWisePurchaseReport/productVendorOrderWisePurchaseReport")]
        public HttpResponseMessage postProductVendorOrderWisePurchaseReport(ProductsVendorWisePurchaseReport objProductsVendorWisePurchaseReportReport)
        {
            try
            {
                DataTable dt = objProductsVendorWisePurchaseReportBL.postProductVendorOrderWiseData(objProductsVendorWisePurchaseReportReport);
                // DataTable reportData = objProductsVendorWisePurchaseReportBL.createBrandVendorWiseReportData(dt);
                return Request.CreateResponse(HttpStatusCode.OK, dt);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/ProductVendorWisePurchaseReport/brandVendorOrderWisePurchaseReport")]
        public HttpResponseMessage postBrandVendorOrderWisePurchaseReport(ProductsVendorWisePurchaseReport objProductsVendorWisePurchaseReportReport)
        {
            try
            {
                DataTable dt = objProductsVendorWisePurchaseReportBL.postBrandVendorOrderWiseData(objProductsVendorWisePurchaseReportReport);               
               return Request.CreateResponse(HttpStatusCode.OK, dt);
             
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

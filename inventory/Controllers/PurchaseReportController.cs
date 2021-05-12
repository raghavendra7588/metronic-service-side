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
    public class PurchaseReportController : ApiController
    {
        PurchaseReportBL objPurchaseReport = new PurchaseReportBL();


        [HttpGet]
        public HttpResponseMessage getall(int id)
        {
            try
            {            
                DataTable dt = objPurchaseReport.getData(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }


        [HttpPost]
        [Route("api/PurchaseReport/purchaseReportVendorOrderWise")]
        public HttpResponseMessage postall(PurchaseReport purchaseReport)
        {
            try
            {
                DataTable dt = objPurchaseReport.postAllData(purchaseReport);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

    }
}


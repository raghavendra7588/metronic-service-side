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
    public class PurchaseReportInventoryController : ApiController
    {

        PurchaseReportInventoryBL objPurchaseOrderInventoryBL = new PurchaseReportInventoryBL();
        [HttpGet]
        public HttpResponseMessage getall(int id)
        {
            try
            {
                DataTable dt = objPurchaseOrderInventoryBL.getData(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        public HttpResponseMessage postall(PurchaseReportInventory objPurchaseReport)
        {
            try
            {
                DataTable dt = objPurchaseOrderInventoryBL.postAllData(objPurchaseReport);
                DataTable reportData = objPurchaseOrderInventoryBL.createReportData(dt);
                return Request.CreateResponse(HttpStatusCode.OK, reportData);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

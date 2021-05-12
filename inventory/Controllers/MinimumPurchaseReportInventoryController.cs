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
    public class MinimumPurchaseReportInventoryController : ApiController
    {
        MinimumPurchaseReportInventoryBL objMinimumPurchaseReportInventoryBL = new MinimumPurchaseReportInventoryBL();


        [HttpPost]
        public HttpResponseMessage postall(MinimumPurchaseReportInventory objMinimumPurchaseReport)
        {
            try
            {
                DataTable dt = objMinimumPurchaseReportInventoryBL.postAllData(objMinimumPurchaseReport);              
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

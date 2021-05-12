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
    public class PurchaseOrderController : ApiController
    {
        PurchaseOrderBL purchaseOrderBL = new PurchaseOrderBL();


        [HttpPost]
        [Route("api/PurchaseOrder/getOrderIdByVendorId")]
        public HttpResponseMessage getOrderIdByVendorId(GetPurchaseOrder objGetPurchaseOrder)
        {
            try
            {

                DataTable dt = purchaseOrderBL.getData(objGetPurchaseOrder);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }


        [HttpPost]
        [Route("api/PurchaseOrder/getOrderItemData")]
        public HttpResponseMessage getOrderItemData(GetPurchaseOrderItem objGetPurchaseOrderItem)
        {
            try
            {

                DataTable dt = purchaseOrderBL.geItemData(objGetPurchaseOrderItem);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        public PurchaseOrder Post(PurchaseOrder purchaseOrderData)
        {
            PurchaseOrder ObjPurchaseOrder = new PurchaseOrder();
            int intId = ObjPurchaseOrder.PurchaseOrderId;
            try
            {
                if (intId == 0)
                {
                    ObjPurchaseOrder= purchaseOrderBL.postPurchaseOrderToDb(purchaseOrderData);
                }

                return ObjPurchaseOrder;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

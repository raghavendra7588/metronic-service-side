using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using inventory.Models;

namespace inventory.Controllers
{
    public class PurchaseProductsController : ApiController
    {
        PurchaseProductsBL objPurchaseProductsBL = new PurchaseProductsBL();



        [HttpPost]
        public PurchaseProducts PostProductItems(PurchaseProducts objPurchaseOrderData)
        {
            PurchaseProducts ObjPurchaseOrder = new PurchaseProducts();
           // int intId = ObjPurchaseOrder.PurchaseProductId;
            try
            {
                //if (intId == 0)
                //{
                    ObjPurchaseOrder = objPurchaseProductsBL.PostProductItems(objPurchaseOrderData);
                //}

                return ObjPurchaseOrder;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

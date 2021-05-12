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
    public class VendorViewController : ApiController
    {
        vendorViewBL ObjVendor = new vendorViewBL();
        [HttpPost]
        public HttpResponseMessage postallView(vendorView vendorViewData)
        {
            try
            {  
                DataTable dt = ObjVendor.postAllViewData(vendorViewData);              
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }


}

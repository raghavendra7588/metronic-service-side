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
   
    public class StockInController : ApiController
    {
        StockInBL ObjStockInBL = new StockInBL();

        [HttpGet]
        public HttpResponseMessage getall(int id)

        {
            try
            {
                Vendor ObjVendor = new Vendor();
                DataTable dt = ObjStockInBL.getAllData(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        public HttpResponseMessage Post(List<StockIn> stockInData)
        {
           
            try
            {           
                ObjStockInBL.postStockInItemsToDb(stockInData);         
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

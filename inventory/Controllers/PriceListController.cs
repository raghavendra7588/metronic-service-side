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
    public class PriceListController : ApiController
    {
        PriceListBL ObjPriceList = new PriceListBL();

        [HttpGet]
        public HttpResponseMessage getall(int id)
   
        {
            try
            {
                Vendor ObjVendor = new Vendor();
                DataTable dt = ObjPriceList.getAllData(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        public HttpResponseMessage Post(PriceList priceListData)
        {
            int priceListId = priceListData.PriceListId;
            try
            {
                if (priceListId == 0)
                {
                    ObjPriceList.postPriceListToDb(priceListData);
                }
                else
                {

                    ObjPriceList.updatePriceListToDb(priceListData, priceListId);
                }

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/PriceList/multiple")]
        public HttpResponseMessage Post(List<PriceList> priceListData)
        {
            try
            {
                if(priceListData != null)
                {
                    for (int i = 0; i < priceListData.Count; i++)
                    {
                        ObjPriceList.postPriceListToDb(priceListData[i]);
                    }
                }
            
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}

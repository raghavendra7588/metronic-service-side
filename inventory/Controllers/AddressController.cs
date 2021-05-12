using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using inventory.Models;
using Newtonsoft.Json;

namespace inventory.Controllers
{
    public class AddressController : ApiController
    {

        AddressBL ObjAddressBL = new AddressBL();

        [HttpGet]
        public HttpResponseMessage getall(int id)
        {
            try
            {
                Vendor ObjVendor = new Vendor();
                DataTable dt = ObjAddressBL.getAllData(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        public HttpResponseMessage Post(Address addressData)
        {
         
            string strId = addressData.id;
            try
            {
                if (Convert.ToInt32(strId) == 0)
                {
                    ObjAddressBL.postAddressToDb(addressData);
                }
                else
                {
                    ObjAddressBL.updateAddressToDb(addressData,Convert.ToInt32(strId));
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

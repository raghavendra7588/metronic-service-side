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
    public class DashBoardController : ApiController
    {
        //DashBoardPurchasePerDayBL objDashBoardPurchasePerDayBL = new DashBoardPurchasePerDayBL();
        DashBoardPurchasePerMonthBL objDashBoardPurchasePerMonthBL = new DashBoardPurchasePerMonthBL();
        DashBoardPurchaseOrderPerDayBL objDashBoardPurchaseOrderPerDayBL = new DashBoardPurchaseOrderPerDayBL();
        //DashBoardPurchaseOrderPerMonthBL objDashBoardPurchaseOrderPerMonthBL = new DashBoardPurchaseOrderPerMonthBL();
        FastestMovingProductsPerMonthBL objFastestMovingProductsPerMonthBL = new FastestMovingProductsPerMonthBL();

        //[HttpPost]
        //[Route("api/DashBoard/postPurchasePerDay")]
        //public HttpResponseMessage postPurchasePerDay(DashBoardPurchasePerDay objDashBoardPurchasePerDay)
        //{
        //    try
        //    {
        //        DataTable dt = objDashBoardPurchasePerDayBL.postPurchasePerDayToDb(objDashBoardPurchasePerDay);
        //        return Request.CreateResponse(HttpStatusCode.OK, dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

        //    }
        //}


        [HttpPost]
        [Route("api/DashBoard/postPurchasePerMonth")]
        public HttpResponseMessage postPurchasePerMonth(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
        {
            try
            {
                DataTable dt = objDashBoardPurchasePerMonthBL.postPurchasePerMonthToDb(objDashBoardPurchasePerMonth);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("api/DashBoard/postPurchaseOrderPerDay")]
        public HttpResponseMessage postPurchaseOrderPerDay(DashBoardPurchaseOrderPerDay objDashBoardPurchaseOrderPerDay)
        {
            try
            {
                DataTable dt = objDashBoardPurchaseOrderPerDayBL.postPurchasePerOrderDb(objDashBoardPurchaseOrderPerDay);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        //[HttpPost]
        //[Route("api/DashBoard/postPurchaseOrderPerMonth")]
        //public HttpResponseMessage postPurchaseOrderPerMonth(DashBoardPurchaseOrderPerMonth objDashBoardPurchaseOrderPerMonth)
        //{
        //    try
        //    {
        //        DataTable dt = objDashBoardPurchaseOrderPerMonthBL.postPurchaseOrderPerMonthToDb(objDashBoardPurchaseOrderPerMonth);
        //        return Request.CreateResponse(HttpStatusCode.OK, dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

        //    }
        //}

        //[HttpPost]
        //[Route("api/DashBoard/postFastestMovingProductsPerMonth")]
        //public HttpResponseMessage postFastestMovingProductsPerMonth(DashBoardFastestMovingProductsPerMonth objDashBoardFastestMovingProductsPerMonth)
        //{
        //    try
        //    {
        //        DataTable dt = objFastestMovingProductsPerMonthBL.postFastestMovingProductsToDb(objDashBoardFastestMovingProductsPerMonth);
        //        return Request.CreateResponse(HttpStatusCode.OK, dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

        //    }
        //}

        [HttpGet]
        [Route("api/DashBoard/postFastestMovingProductsPerMonth/{id:int}")]
        public HttpResponseMessage postFastestMovingProductsPerMonth(int id)
        {
            try
            {
                DataTable dt = objFastestMovingProductsPerMonthBL.postFastestMovingProductsToDb(id.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }


        [HttpGet]
        [Route("api/DashBoard/getPurchaseValueByWeek/{id:int}")]
        public HttpResponseMessage getPurchaseValueByWeek(int id)
        {
            try
            {
                DataTable dt = objFastestMovingProductsPerMonthBL.getPurchaseAmountPerWeek(id.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/DashBoard/getPurchaseValueByWeekByVendor/{id:int}")]
        public HttpResponseMessage getPurchaseValueByWeekByVendor(int id)
        {
            try
            {
                DataTable dt = objFastestMovingProductsPerMonthBL.getPurchaseAmountPerWeekByVendor(id.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("api/DashBoard/getPurchaseAmountByMonth")]
        public HttpResponseMessage PostPurchaseAmountByMonth(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
        {
            try
            {
                DataTable dt = objFastestMovingProductsPerMonthBL.getPurchaseAmountPerMonth(objDashBoardPurchasePerMonth);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }

        
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("api/DashBoard/getPurchaseAmountByMonthByVendor")]
        public HttpResponseMessage PostPurchaseAmountByMonthByVendor(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
        {
            try
            {
                DataTable dt = objFastestMovingProductsPerMonthBL.getPurchaseAmountPerMonthByVendors(objDashBoardPurchasePerMonth);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }


            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/DashBoard/getHighestValueProductsByCurrentMonth")]
        public HttpResponseMessage PostHighestValueByMonth(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
        {
            try
            {
                DataTable dt = objFastestMovingProductsPerMonthBL.getHighestValueProductsByMonth(objDashBoardPurchasePerMonth);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }


            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/DashBoard/getHighestValueByLastMonth")]
        public HttpResponseMessage PostHighestValueByLastMonth(DashBoardPurchasePerMonth objDashBoardPurchasePerMonth)
        {
            try
            {
                DataTable dt = objFastestMovingProductsPerMonthBL.getHighestValueProductsByLastMonth(objDashBoardPurchasePerMonth);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }


            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpGet]
        [Route("DashBoard/getTopFiveProductsBySellerID/{id:int}")]
        public HttpResponseMessage PostTopFiveProductsBySellerID(int id)
        {
            try
            {
                DataTable dt = objFastestMovingProductsPerMonthBL.getTopProductsBySellerId(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }


            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

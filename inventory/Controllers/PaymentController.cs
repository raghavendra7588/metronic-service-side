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
    public class PaymentController : ApiController
    {
        PaymentBL objPaymentBL = new PaymentBL();



        [HttpPost]
        public HttpResponseMessage UpdatePaymentMode(Payment objPayment)
        {
            try
            {
                DataTable dt = objPaymentBL.getSellerPaymentData(objPayment);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/PaymentController/getPaymentMode")]
        public HttpResponseMessage getPaymentModeData()
        {
            try
            {
                DataTable dt = objPaymentBL.getPaymentMode();
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("api/PaymentController/UpdatePaymentMode")]
        public HttpResponseMessage UpdatePaymentMode(UpdatePaymentMode updatePaymentModeData)
        {
            try
            {
                objPaymentBL.updatePaymentMode(updatePaymentModeData);
                return Request.CreateResponse(HttpStatusCode.Created);
            }


            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/PaymentController/TransactionHistoryBySeller/{id:int}")]
        public HttpResponseMessage getTransactionHistoryBySeller(int id)
        {
            try
            {
                DataTable dt = objPaymentBL.transactionHistoryBySeller(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("api/PaymentController/UpdatePreviousTransactions")]
        public HttpResponseMessage updatePreviousTransaction(TransactionHistory objTransactionHistory)
        {
            try
            {
                objPaymentBL.updatePreviousTransationsData(objTransactionHistory);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/PaymentController/UpdateActiveStatus")]
        public HttpResponseMessage updateInactiveStatus(UpdateInActiveState updateUpdateInActiveState)
        {
            try
            {
                objPaymentBL.updateInactiveStatus(updateUpdateInActiveState);
                return Request.CreateResponse(HttpStatusCode.OK);
            }


            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/PaymentController/GetLatestTransactionBySellerID/{id:int}")]
        public HttpResponseMessage getLatestTransactionHistoryBySeller(int id)
        {
            try
            {
                DataTable dt = objPaymentBL.GetLastestTransactionBySeller(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("api/PaymentController/UpdatePaymentDetails")]
        public HttpResponseMessage updatePaymentDetailsData(UpdatePaymentDetails updatePaymentDetails)
        {
            try
            {
                objPaymentBL.updatePaymentDetails(updatePaymentDetails);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("api/PaymentController/UpdateSellerStatusCheckPoint")]
        public HttpResponseMessage updateSellerStatusCheckpoint(StatusCheckpoint objStatusCheckpoint)
        {
            try
            {
                objPaymentBL.PostSellerStatusCheckpoint(objStatusCheckpoint);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

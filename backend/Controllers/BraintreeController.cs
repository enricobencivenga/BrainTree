using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Braintree;
using Braintree.Server;
using Braintree.Server.Models;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace Braintree.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BraintreeController : ControllerBase
    {
        private IBraintreeConfiguration braintreeConfiguration;

        public static readonly TransactionStatus[] transactionSuccessStatuses = {
                                                                                    TransactionStatus.AUTHORIZED,
                                                                                    TransactionStatus.AUTHORIZING,
                                                                                    TransactionStatus.SETTLED,
                                                                                    TransactionStatus.SETTLING,
                                                                                    TransactionStatus.SETTLEMENT_CONFIRMED,
                                                                                    TransactionStatus.SETTLEMENT_PENDING,
                                                                                    TransactionStatus.SUBMITTED_FOR_SETTLEMENT
                                                                                };

        public BraintreeController(IConfiguration config)
        {
            braintreeConfiguration = new BraintreeConfiguration(config);
        }

        [HttpGet("getclienttoken")]
        public IActionResult GetClientToken()
        {
            var gateway = braintreeConfiguration.GetGateway();
            var clientToken = gateway.ClientToken.Generate();
            var clientTokenResponse = new ClientTokenResponse(clientToken);
            return new JsonResult(clientTokenResponse);
        }

        [HttpPost("createpurchase")]
        public IActionResult CreatePurchase([FromBody]NonceRequest nonceRequest)
        {
            var gateway = braintreeConfiguration.GetGateway();

            var request = new TransactionRequest
            {
                Amount = nonceRequest.ChargeAmount,
                PaymentMethodNonce = nonceRequest.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);
            return new JsonResult(result);
        }      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Braintree.Server.Models
{
    public class NonceRequest
    {
        public string Nonce { get; set; }
        public decimal ChargeAmount { get; set; }

        public NonceRequest(string nonce)
        {
            Nonce = nonce;
            ChargeAmount = ChargeAmount;
        }
    }
}
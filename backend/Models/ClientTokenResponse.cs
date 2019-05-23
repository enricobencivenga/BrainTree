using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Braintree.Server.Models
{
    public class ClientTokenResponse
    {
        public string Token { get; set; }

        public ClientTokenResponse(string token)
        {
            Token = token;
        }
    }
}
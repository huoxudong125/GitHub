using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSB.EnterpriseCenter.WebApi.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string OrderDetailId { get; set; }

        public OderDetail OderDetail { get; set; }
    }
}
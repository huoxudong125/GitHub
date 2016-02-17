using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSB.EnterpriseCenter.WebApi.Models
{
    public class OderDetail
    {
        public string Id { get; set; }

        public string ProductId { get; set; }
        public virtual  Product Product { get; set; }
    }
}
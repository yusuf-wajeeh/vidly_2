using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_HandsOn.Models;

namespace MVC_HandsOn.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public customer customer { get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_HandsOn.Models
{
    public class MemberShipType
    {
        public int id { get; set; }

        public string name { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }

        public static readonly int unknown = 0;
        public static readonly int PayAsYouGo = 1;

    }
}
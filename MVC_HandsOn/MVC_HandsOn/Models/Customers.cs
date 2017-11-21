using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_HandsOn.Models
{
    public class customer
    {
        public int id { get; set; }


        [Required]
        [MaxLength(255)]
        public string name { get; set;  }

        [Min18Yrs]
        [Display(Name="Date Of Birth")]
        public DateTime? dob { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }

        [Display(Name ="Membership Type")]
        public int MemberShipTypeId { get; set; }


    }
}
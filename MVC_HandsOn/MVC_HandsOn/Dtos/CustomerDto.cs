using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVC_HandsOn.Models;

namespace MVC_HandsOn.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }


        [Required]
        [MaxLength(255)]
        public string name { get; set; }

        [Min18Yrs]
       
        public DateTime? dob { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
       

       
        public int MemberShipTypeId { get; set; }

    }
}
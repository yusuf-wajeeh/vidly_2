using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_HandsOn.Models;

namespace MVC_HandsOn.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie movie { get; set; }
        public List<customer> customer { get; set; }
    }
}
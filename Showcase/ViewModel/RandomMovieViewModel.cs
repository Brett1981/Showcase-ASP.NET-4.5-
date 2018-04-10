using Showcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Showcase.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> customers { get; set; }
    }
}
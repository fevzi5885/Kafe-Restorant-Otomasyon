using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }

    }
}

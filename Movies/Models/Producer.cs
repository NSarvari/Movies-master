using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        //Relations
        public List<Movie> Movies { get; set; }
    }
}

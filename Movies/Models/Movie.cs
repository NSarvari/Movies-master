using Movies.Data;
using System;
using System.ComponentModel.DataAnnotations;


namespace Movies.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory{ get; set; }

        //Relations
        public Producer producer { get; set; }
    }
}

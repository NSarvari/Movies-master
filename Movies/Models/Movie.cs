using Movies.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public List<MovieActor> MovieActors { get; set; }

        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        [ForeignKey("ProducerId")]
        public int ProducerID { get; set; }

        public Producer Producer { get; set; }
    }
}

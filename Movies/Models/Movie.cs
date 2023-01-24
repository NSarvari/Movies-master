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

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "ImageUrl")]
        public string ImageUrl { get; set; }

        [Display(Name = "Price")]
        public string Price { get; set; }

        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [Display(Name = "MovieCategory")]
        public MovieCategory MovieCategory{ get; set; }

        //Relations
        public List<MovieActor> MovieActors { get; set; }

        public List<Cinema> Cinemas { get; set; }

        public List<Producer> Producers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        [Display(Name ="FullName")]
        [Required(ErrorMessage ="Full Name field cannot be empty")]
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Bio field cannot be empty")]
        public string Bio { get; set; }

        [Display(Name = "Profile Picture Url")]
        [Required(ErrorMessage = "Profile Picture field cannot be empty")]
        public string ProfilePictureUrl { get; set; }

        //Relations
        public List<MovieActor> MovieActors { get; set; }
    }
}

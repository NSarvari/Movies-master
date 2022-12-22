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
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Display(Name = "Profile Picture Url")]
        public string ProfilePictureUrl { get; set; }

        //Relations
        public List<MovieActor> MovieActors { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class MovieActor
    {
        [Display(Name = "MovieId")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Display(Name = "ActorId")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}

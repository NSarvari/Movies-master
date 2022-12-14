using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MovieActor
    {
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop2
{
    public class Movie
    {
        [JsonProperty]
        private string _title { get; set; } = string.Empty;
        private List<MovieScreening> _screenings { get; set; } = new List<MovieScreening>();
        
        public Movie(string title)
        {
            _title = title;
        }

        public void AddScreening(MovieScreening screening)
        {
            _screenings.Add(screening);
        }

        public string ToString()
        {
            return "Title: " + _title;
        }
    }
}

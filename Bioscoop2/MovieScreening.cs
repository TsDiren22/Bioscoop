using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop2
{
    public class MovieScreening
    {
        private DateTime _dateAndTime { get; set; }
        private double _pricePerSeat { get; set; }
        public List<MovieTicket> _movieTickets { get; set; } = new List<MovieTicket>();
        public Movie _movie { get; set; }

        public MovieScreening(DateTime dateAndTime, double pricePerSeat, Movie movie)
        {
            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
            _movie = movie;
        }

        public double GetPricePerSeat()
        {
            return _pricePerSeat;
        }

        public DateTime GetDateAndTime()
        {
            return _dateAndTime;
        }

        public string ToString()
        {
            return string.Format("Date and time: {0}\nPrice per seat: {1}", _dateAndTime, _pricePerSeat);
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop2
{
    public class MovieTicket
    {
        [JsonProperty]
        private int _rowNr { get; set; }
        [JsonProperty]
        private int _seatNr { get; set; }
        [JsonProperty]
        public MovieScreening _screening { get; set; }
        private bool _isPremium { get; set; }

        public MovieTicket(int rowNr, int seatNr, bool isPremium, MovieScreening screening)
        {
            _rowNr = rowNr;
            _seatNr = seatNr;
            _screening = screening;
            _isPremium = isPremium;
        }

        public bool IsPremiumTicket()
        {
            return _isPremium;
        }

        public double GetPrice()
        {
            return _screening.GetPricePerSeat();
        }

        public string ToString()
        {
            return string.Format("\nBase price: {2}\nRow, Seat\n {0}, {1}\n\nPremium: {3}\n_________________", _rowNr, _seatNr, GetPrice(), (_isPremium ? "Extra costs will be added to the total." : "No"));
        }
    }
}

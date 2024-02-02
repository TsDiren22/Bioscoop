using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop2
{
    public class Order
    {
        [JsonProperty]
        public int _orderNr { get; private set; }
        private bool _isStudentOrder { get; set; }
        [JsonProperty]
        private List<MovieTicket> _movieTickets { get; set; } = new List<MovieTicket>();

        public Order(int orderNr, bool isStudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStudentOrder;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            _movieTickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            {
                double totalPrice = 0;
                int i = 1;
                foreach (MovieTicket ticket in _movieTickets)
                {   
                    double premiumToAdd = _isStudentOrder ? 2:3;
                    double price = ticket.GetPrice();
                    if (i % 2 == 0 && IsWeekDay(ticket)) price = 0;
                    else if (ticket.IsPremiumTicket()) price += premiumToAdd;
                    totalPrice += price;
                    i++;
                    
                }
                if (_movieTickets.Count >= 6 && !IsWeekDay(_movieTickets[0]) && !_isStudentOrder)
                {
                    totalPrice *= 0.9;
                }
                return totalPrice;
            }
        }

        private static bool IsWeekDay(MovieTicket ticket)
        {
            DateTime dateAndTime = ticket._screening.GetDateAndTime();
            return dateAndTime.DayOfWeek != DayOfWeek.Friday && dateAndTime.DayOfWeek != DayOfWeek.Saturday && dateAndTime.DayOfWeek != DayOfWeek.Sunday;
        }

        public async Task Export(TicketExportFormat exportFormat)
        {
            switch (exportFormat)
            {
                case TicketExportFormat.PLAINTEXT:
                    StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(_movieTickets[0]._screening._movie.ToString() + " | " + " Order: " + _orderNr);
                    _movieTickets.ForEach(x => stringBuilder.AppendLine(x.ToString()));
                    stringBuilder.AppendLine("Total Cost: " + CalculatePrice());

                    using (StreamWriter writer = new StreamWriter("..\\..\\.\\..\\GeneratedFiles\\PlainText.txt"))
                    {
                        await writer.WriteAsync(stringBuilder.ToString());
                    }
                    break;

                case TicketExportFormat.JSON:
                    string json = JsonConvert.SerializeObject(this);

                    using (StreamWriter writer = new StreamWriter("..\\..\\..\\GeneratedFiles\\JsonFile.json"))
                    {
                        await writer.WriteAsync(json);
                    }
                    break;
            }
        }
    }
}

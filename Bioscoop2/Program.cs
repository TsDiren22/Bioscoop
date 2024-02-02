using Bioscoop2;

Movie movie = new Movie("The Matrix");
MovieScreening screening = new(new DateTime(2024, 2, 8, 12, 30, 0), 10.0, movie);
MovieTicket ticket1 = new(1, 1, true, screening);
MovieTicket ticket2 = new(1, 2, true, screening);
MovieTicket ticket3 = new(1, 3, true, screening);
MovieTicket ticket4 = new(1, 4, true, screening);
MovieTicket ticket5 = new(1, 5, true, screening);
MovieTicket ticket6 = new(1, 6, true, screening);

movie.AddScreening(screening);

//IPriceBehaviour priceBehaviour = new NonStudentOrder();
Order order = new(1, true);

order.AddSeatReservation(ticket1);
order.AddSeatReservation(ticket2);
order.AddSeatReservation(ticket3);
order.AddSeatReservation(ticket4);
order.AddSeatReservation(ticket5);
order.AddSeatReservation(ticket6);

await order.Export(TicketExportFormat.PLAINTEXT);
await order.Export(TicketExportFormat.JSON);
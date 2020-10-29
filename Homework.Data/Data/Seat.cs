using System;
using System.Collections.Generic;

namespace Homework.Data.Data
{
    public class Seat
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}

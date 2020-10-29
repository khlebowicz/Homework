using System;
using System.Collections.Generic;

namespace Homework.Data.Data
{
    public class Performance
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Seat> Seats { get; set; }
    }
}

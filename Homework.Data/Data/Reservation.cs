using System;

namespace Homework.Data.Data
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime UntilWhen { get; set; }
    }
}
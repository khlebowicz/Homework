using Homework.Data.Data;
using Homework.Data.Fixtures;
using System.Collections.Generic;

namespace Homework.Data
{
    public class InMemoryDb : IInMemoryDb
    {
        public ICollection<Performance> Performances { get; } = new List<Performance>
        {
            new Performance{
                Id = Guids.Get(0),
                Name = "Potop",
                Date = Dates.Get(3),
                Seats = new Seat[]
                {
                    new Seat { Id = Guids.Get(1), Column = 1, Row = 1, Reservations = new List<Reservation>() },
                    new Seat { Id = Guids.Get(2), Column = 1, Row = 2, Reservations = new List<Reservation>()
                        {
                            new Reservation { UserId = Guids.Get(5), UntilWhen = Dates.Get(2) },
                        }
                    },
                    new Seat { Id = Guids.Get(3), Column = 2, Row = 1, Reservations = new List<Reservation>() },
                    new Seat { Id = Guids.Get(4), Column = 2, Row = 2, Reservations = new List<Reservation>
                        {
                            new Reservation { UserId = Guids.Get(5), UntilWhen = Dates.Get(1) },
                            new Reservation { UserId = Guids.Get(5), UntilWhen = Dates.Get(0) }
                        }
                    }
                }
            }
        };

        public ICollection<User> Users { get; } = new List<User>
        {
            new User{ Id = Guids.Get(0), FullName = "Radosław Kot", IsVip = true},
            new User{ Id = Guids.Get(1), FullName = "Przemysław Dzięcioł"},
            new User{ Id = Guids.Get(5), FullName = "Abacki Abacki"}
        };
    }
}

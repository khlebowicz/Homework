using Homework.Data.Data;
using System.Collections.Generic;

namespace Homework.Data
{
    public interface IInMemoryDb
    {
        ICollection<Performance> Performances { get; }
        ICollection<User> Users { get; }
    }
}
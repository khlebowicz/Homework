using System;

namespace Homework.Data.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool IsVip { get; set; }
    }
}
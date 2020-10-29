using System;

namespace Homework.Data.Fixtures
{
    public static class Guids
    {
        private static readonly Guid[] _guids = new Guid[]
        {
            new Guid("8bf0b988-f921-4ba3-9767-97376af2bfc1"),
            new Guid("273e2a39-e2e2-4430-9c0e-ed1985ce5f7f"),
            new Guid("72678a3a-6842-458b-b7dd-1a129983861c"),
            new Guid("64a5dc4d-3e96-4c0c-ad59-bfaadedf6e60"),
            new Guid("a11725cf-4e7c-4dd5-88ce-f5a5ba3c1747"),
            new Guid("99b67f3e-fcf4-4e98-afe1-f8fbf32bca42")
        };

        public static Guid Get(int index) => _guids[index];
    }
}

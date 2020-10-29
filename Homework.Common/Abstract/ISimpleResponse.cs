using System.Collections.Generic;

namespace Homework.Common
{
    public interface ISimpleResponse
    {
        IEnumerable<string> Errors { get; }

        bool IsValid { get; }

        object Result { get; }
    }
}
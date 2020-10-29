using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Homework.Common
{
    public class SimpleResponse : ISimpleResponse
    {
        private readonly IList<string> _errorMessages;

        public IEnumerable<string> Errors => new ReadOnlyCollection<string>(_errorMessages);
        public object Result { get; }

        public bool IsValid { get { return !_errorMessages.Any(); } }

        public SimpleResponse(object result)
        {
            _errorMessages = new List<string>();
            Result = result;
        }

        public SimpleResponse(List<string> errorMessages)
        {
            _errorMessages = errorMessages;
        }
    }
}

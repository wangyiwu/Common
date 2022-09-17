

using Common.Configuration;
using System.Collections.Generic;

namespace Common.Configuration
{
    public interface IErrorProvider
    {
        IEnumerable<ConfigurationError> GetErrors();
    }
}

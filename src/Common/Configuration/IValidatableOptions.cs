

using Common.Configuration;
using System.Collections.Generic;

namespace Common.Configuration
{
    public interface IValidatableOptions
    {
        IEnumerable<ConfigurationError> Validate();
    }
}

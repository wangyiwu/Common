

using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.Configuration
{
    public sealed class Alternatives : Dictionary<string, Action>
    {
        public Alternatives()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }
}

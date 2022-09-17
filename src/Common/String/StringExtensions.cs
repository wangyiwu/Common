using System;
using System.Text.RegularExpressions;

namespace Common.String.Extensions
{
    public static class StringExtensions
    {
        public static string GetTenantKey(this string path, string key)
        {
            var regexPattern = "([a-zA-Z0-9]+):([a-zA-Z0-9])+";

            var match = Regex.Match(path, regexPattern);

            if (!match.Success)
            {
                throw new Exception();
            }

            foreach(Group group in match.Groups)
            {
                if (group.Value.Contains(key) && group.Value.Split(":").Length == 2)
                {
                    return group.Value.Split(":")[1];
                }
            }

            return "";
        }
    }
}

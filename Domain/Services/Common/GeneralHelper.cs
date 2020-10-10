using Domain.Types;
using System;

namespace Domain.Services.Common
{
    public static class GeneralHelper
    {
        public static LogType ExceptionLogType(Exception ex)
        {
            if (ex.GetType() == typeof(ArgumentException))
            {
                return LogType.WARNING;
            }

            return LogType.ERROR;
        }

        public static string LimitLength(string input, int maxLength)
        {
            if (input == null) return null;

            if (input.Length <= maxLength) return input;

            return input.Substring(0, maxLength);
        }
    }
}

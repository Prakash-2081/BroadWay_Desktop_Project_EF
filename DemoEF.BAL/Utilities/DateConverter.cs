using Demo.DAL.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF.BAL.Utilities
{
    public static class DateConverter
    {
        public static string FormatDate(this DateTime date, string format = ApplicationConstant.DateFormat)
        {
            return date.ToString(format);
        }
        public static string FormatDate(this DateOnly date,string format = ApplicationConstant.DateFormat)
        {
            return date.ToString(format);
        }
        public static string FormatDate(this DateTime? date, string format = ApplicationConstant.DateFormat)
        {
            if (!date.HasValue) return null;

            return date.Value.ToString(format);
        }
    }
}

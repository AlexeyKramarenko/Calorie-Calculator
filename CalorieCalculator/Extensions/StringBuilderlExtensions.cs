using CalorieCalculator.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieCalculator.Extensions
{
    public static class StringBuilderlExtensions
    {
        public static StringBuilder Append(this StringBuilder sb, string str)
        {
            sb.Append(str);
            return sb;
        }

        public static StringBuilder AppendLine(this StringBuilder sb)
        {
            sb.AppendLine();
            return sb;
        }

        public static StringBuilder ForEach(
                                    this StringBuilder sb,
                                         IEnumerable<ProductRecord> records,
                                         Func<ProductRecord, string> func)
        { 
            foreach (ProductRecord record in records)
            {
                sb.Append(func(record));
                sb.AppendLine();
            }

            return sb;
        }
    }
}

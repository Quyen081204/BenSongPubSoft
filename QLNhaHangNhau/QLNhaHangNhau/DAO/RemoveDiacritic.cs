using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLNhaHangNhau.DAO
{
    public class RemoveDiacritic
    {
        public static string RemoveDiacritics(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormD);
            Console.WriteLine(normalized);
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string result = regex.Replace(normalized, "")
                                 .Replace('đ', 'd')
                                 .Replace('Đ', 'D');
            return result;
        }
    }
}

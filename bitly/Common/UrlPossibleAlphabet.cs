using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bitly
{
    /// <summary>
    /// Словарь, содержащий символы, допустимые в URL и не являющиеся управляющими
    /// </summary>
    public class UrlPossibleAlphabet : AlphabetDictionary
    {
        // Диапазоны символов согласно ASCII
        private List<char[]> ranges = new List<char[]>() { new char[]{ 'A', 'Z' },
                                                           new char[]{ 'a', 'z' },
                                                           new char[]{ '0', '9' },
                                                           new char[]{ '-', '-' }, 
                                                           new char[]{ '_', '_' }};
        /// <summary>
        /// Возвращает последовательность допустимх в URL символов
        /// </summary>
        public override char[] getAlphabet()
        {
            List<Char> ret = new List<char>();
            foreach(var t in ranges)
                for (char c = t[0]; c <= t[1]; c++)
                    ret.Add(c);

            return ret.ToArray();
        }
    }
}
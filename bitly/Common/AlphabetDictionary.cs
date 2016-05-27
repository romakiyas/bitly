using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bitly
{
    /// <summary>
    /// Базовый класс для работы со славарем алфавита. 
    /// Кодирует/декодирует числовое значение в системе счисления c основанием, равным длинне словаря.
    /// </summary>
    public abstract class AlphabetDictionary
    {
        /// <summary>
        /// Возвращает массив сиволов словаря. Реализация метода возложена на наследника
        /// </summary>
        /// <returns>Массив символов словаря</returns>
        abstract public char[] getAlphabet();

        /// <summary>
        /// Преобразует числовое значение в символьную последовательность согласно словарю
        /// </summary>
        public char[] fromDecimal(long value)
        {
            var alphabet = this.getAlphabet();
            List<char> ret = new List<char>();
            while (value > 0)
            {
                ret.Add(alphabet[value % alphabet.Length]);
                value = value / alphabet.Length;
            }
            ret.Reverse();
            return ret.ToArray();
        }

        /// <summary>
        /// Преобразует символьную последовательность в числовое значение согласно словарю
        /// </summary>
        public long toDecimal(char[] value)
        {
            long result = 0;

            var alphabet = this.getAlphabet();
            int digs = value.Length;
            for (int i = 0; i<digs; i++)
            {
                var decValue = Array.IndexOf(alphabet, value[digs - i - 1]);
                result += (long)(decValue * Math.Pow(alphabet.Length, i));
            }
            return result;
        }
    }
}
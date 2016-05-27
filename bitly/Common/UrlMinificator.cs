using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bitly.Models;

namespace bitly
{
    /// <summary>
    /// Преобразует числовое значение в код ссылки и наоборот
    /// </summary>
    public class UrlMinificator
    {
        AlphabetDictionary dict;
        private string baseDomain;

        /// <summary>
        /// Создает минификатор ссылок
        /// </summary>
        /// <param name="baseDomain">Домен сайта. Пример: http://bit.ly</param>
        /// <param name="dict">Словарь сомволов, согласно которому выполнять построение кода</param>
        public UrlMinificator(string baseDomain, 
                              AlphabetDictionary dict)
        {
            this.dict = dict;
            this.baseDomain = baseDomain;
        }

        /// <summary>
        /// Создает код ссылки
        /// </summary>
        /// <param name="urlID">ID записи</param>
        /// <returns>Код ссылки согласно словаря минификатора</returns>
        public String Minify(long urlID)
        {
            char[] sequence = dict.fromDecimal(urlID);
            return String.Format("{0}/{1}", baseDomain, new String(sequence));
        }
        
        /// <summary>
        /// Возвращает числовое значение на основе кода
        /// </summary>
        /// <param name="urlCodePart">Часть ссылки, содержащая код</param>
        /// <returns>числовое значение ID записи</returns>
        public long Maxify(string urlCodePart)
        {
            return dict.toDecimal(urlCodePart.ToCharArray());
        }
    }
}
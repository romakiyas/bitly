using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bitly.Models
{
    /// <summary>
    /// Сохраняемая ссылка
    /// </summary>
    public class BitUrl
    {
        [Key]
        public long id { get; set; }    // todo: Uint32 / Uint64

        /// <summary>
        /// URL ссылки
        /// </summary>
        public string longUrl { get; set; }

        public DateTime appendDate { get; set; }    // TODO: сделать отображение в часовом поясе клиента

        /// <summary>
        /// Счетчик переходов
        /// </summary>
        public int clicks { get; set; }

        /// <summary>
        /// Пользователь, создавший ссылку
        /// </summary>
        public virtual User author { get; set; }

        /// <summary>
        /// Преобразовать в короткую ссылку
        /// </summary>
        /// <param name="um">Минификатор ссылок</param>
        /// <returns>Короткуя ссылка. Пример: http://bit.ly\/aaU6</returns>
        public string toShortUrl(UrlMinificator um)
        {
            return um.Minify(this.id);
        }

        public BitUrl()
        {
            appendDate = DateTime.Now;
        }
    }
}
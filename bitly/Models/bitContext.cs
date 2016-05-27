using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace bitly.Models
{
    /// <summary>
    /// Контекст доступа к данным
    /// </summary>
    public class bitContext:DbContext
    {
        /// <summary>
        /// Пользователи сайта
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Набор сохраненных ссылок
        /// </summary>
        public DbSet<BitUrl> Urls { get; set; }
    }
}
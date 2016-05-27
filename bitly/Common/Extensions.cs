using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using bitly.Models;

namespace bitly
{
    public static class Extensions
    {
        /// <summary>
        /// Метод расширения для удобного доступа к текущему пользователю сессии
        /// </summary>
        /// <returns>Если пользователь существует - возвращает его, в противном случае - null</returns>
        public static User currentUser(this HttpSessionState sess)
        {
            if (sess[MvcApplication.SS_USER_ID] != null)
            {
                using (var db = new bitContext())
                {
                    return (db.Users.Find((int)sess[MvcApplication.SS_USER_ID]));
                }
            }
            return null;
        }

        /// <summary>
        /// ID текущего пользователя для удобства
        /// </summary>
        public static int currentUserID(this HttpSessionStateBase sess)
        {
            return (sess[MvcApplication.SS_USER_ID] != null) ? (int)sess[MvcApplication.SS_USER_ID] : -1;
        }


    }
}
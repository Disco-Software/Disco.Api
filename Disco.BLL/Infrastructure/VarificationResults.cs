using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Infrastructure
{
    public enum VarificationResults
    {
        /// <summary>
        /// Пользователь с таким E-mail-лом не найден
        /// </summary>
        UserNotFound,

        /// <summary>
        /// Не верный пароль
        /// </summary>
        PasswordNotValid,

        /// <summary>
        /// Пльзователь с таким E-mail-лом назден 
        /// </summary>
        Ok,
        
        /// <summary>
        /// Email не может быть пустым
        /// </summary>
        EmailCenNotBeNull,

        /// <summary>
        /// Password не может быть пустым 
        /// </summary>
        PasswordCanNOtBeNull,
    }
}

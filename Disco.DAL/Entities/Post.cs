using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Post : BaseEntity.BaseEntity<int>
    {
        /// <summary>
        /// Задает или возвращает Описание поста
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Задает или возвращает Фото
        /// </summary>
        public List<Photo> Photos{ get; set; }

        /// <summary>
        /// Задает или возвращает Видео
        /// </summary>
        public List<Video> Videos { get; set; }
        
        /// <summary>
        /// Задает или возвращает музыкальный ресурс
        /// </summary>
        public List<Song> Songs { get; set; }
        
        /// <summary>
        /// Задает или возвращает id пользователя
        /// </summary>
        public string UserId { get; set; }
    }
}

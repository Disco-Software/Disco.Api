using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities.BaseEntity
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}

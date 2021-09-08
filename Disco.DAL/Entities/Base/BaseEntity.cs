using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities.Base
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}

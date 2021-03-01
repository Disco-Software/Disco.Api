using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Domain.Core.BaseEntity
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}

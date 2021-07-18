using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Mobile.Models.BaseModel
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}

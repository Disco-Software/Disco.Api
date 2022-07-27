namespace Disco.Domain.Models.Base
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}

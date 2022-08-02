namespace Disco.Domain.Models.Base
{
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
    }
}

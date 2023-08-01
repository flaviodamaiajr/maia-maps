namespace Maia.Maps.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        
        protected EntityBase()
        {
            CreatedAt = DateTime.Now;
        }
    }
}

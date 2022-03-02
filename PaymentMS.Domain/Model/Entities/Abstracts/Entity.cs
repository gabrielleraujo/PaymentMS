using System.ComponentModel.DataAnnotations;

namespace PaymentMS.Domain.Models.Entities
{
    public abstract class Entity
    {
        protected Entity()
        { }

        protected Entity(Guid id)
        {
            Id = id;
        }

        [Key]
        public Guid Id { get; private set; }
    }
}
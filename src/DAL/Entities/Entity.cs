using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}

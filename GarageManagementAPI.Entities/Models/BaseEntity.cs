using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagementAPI.Entities.Models
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}

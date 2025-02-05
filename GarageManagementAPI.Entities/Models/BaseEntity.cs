using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Runtime.Serialization;

namespace GarageManagementAPI.Entities.Models
{
    public abstract class BaseEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; } = Guid.NewGuid();

        [IgnoreDataMember]
        public static readonly PropertyInfo[] PropertyInfos;

        static BaseEntity()
        {
            PropertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}

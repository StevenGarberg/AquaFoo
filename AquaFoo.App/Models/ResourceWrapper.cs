using System.ComponentModel.DataAnnotations.Schema;

namespace AquaFoo.App.Models
{
    public class ResourceWrapper<T> : Resource where T : Resource
    {
        [Column("Column", TypeName = "jsonb")]
        public T Data { get; set; }
    }
}
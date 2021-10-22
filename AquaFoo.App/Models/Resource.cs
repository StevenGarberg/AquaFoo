using System;
using System.ComponentModel.DataAnnotations;

namespace AquaFoo.App.Models
{
    public class Resource
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OwnerId { get; set; }
        
        [ConcurrencyCheck]
        public int Version { get; set; } = 1;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public bool Deleted { get; set; }
    }
}
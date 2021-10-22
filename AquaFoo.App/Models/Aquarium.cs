using System.ComponentModel.DataAnnotations.Schema;
using GG.DataAccess.Models;
using System.Collections.Generic;

namespace AquaFoo.App.Models
{
    [Table("Aquariums")]
    public class Aquarium : ResourceBase
    {
        [NotMapped]
        public string Name { get; set; }
        
        [NotMapped]
        public float? TankCapacity { get; set; }
        
        [NotMapped]
        public string TankCapacityUnit { get; set; }
        
        [NotMapped]
        public string WaterType { get; set; }
        
        [NotMapped]
        public float? Length { get; set; }
        
        [NotMapped]
        public float? Width { get; set; }
        
        [NotMapped]
        public float? Height { get; set; }
        
        [NotMapped]
        public string TankMeasurementUnit { get; set; }

        [NotMapped]
        public string Lighting { get; set; }
        
        [NotMapped]
        public string Heater { get; set; }
        
        [NotMapped]
        public string Filtration { get; set; }
        
        [NotMapped]
        public string Substrate { get; set; }
        
        [NotMapped]
        public string Notes { get; set; }

        [NotMapped]
        public List<WaterChange> WaterChanges { get; set; } = new List<WaterChange>();
    }
}
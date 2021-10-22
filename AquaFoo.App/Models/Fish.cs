using System;

namespace AquaFoo.App.Models
{
    public class Fish
    {
        public string Name { get; set; }
        
        public string Species { get; set; }
        
        public int Quantity { get; set; }
        
        public string Color { get; set; }
        
        public string Notes { get; set; }
        
        public DateTime? DateAcquired { get; set; }
        
        public float PurchasePrice { get; set; }
    }
}
using System;

namespace AquaFoo.App.Models
{
  public class WaterChange
  {
    public string Id { get; set; }
      
    public DateTime? PerformedAt { get; set; }
      
    public string WaterChangeMeasurement { get; set; }
    public float? WaterChangeAmount { get; set; }
    
    public string Notes { get; set; }
  }
}
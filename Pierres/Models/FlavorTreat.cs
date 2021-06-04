namespace Pierres.Models
{
  public class FlavorTreat
  {
    public int FlavorTreatId { get; set; }  
    public int FlavorId { get; set; } 
    public int TreatId { get; set; }    
    public virtual Flavors Flavor { get; set; }
    public virtual Treat Treat { get; set; }
  }
}
using System.Collections.Generic;

namespace Pierres.Models
{
  public class Flavors
  {
    public Flavor()
    {
      this.JoinEntities = new HashSet<FlavorTreat>();
      
    }

    public virtual ApplicationUser user { get; set; }

    public int FlavorId { get; set; } 
    public string FlavorName { get; set; }

    public virtual ICollection<FlavorTreat> JoinEntities { get; set; }
  }
}
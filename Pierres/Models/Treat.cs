using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pierres.Models
{
  public class Treat
  {
    public Treat()
    {
      this.JoinEntities = new HashSet<FlavorTreat>();
    }

    public virtual ApplicationUser user { get; set; }

    public int TreatId { get; set; }
    public string TreatName { get; set; } 
    public int Rating { get; set; }   

    public virtual ICollection<FlavorTreat> JoinEntities { get; set; }

    public string StarRating()
    {
      string starRating = "";
      if(Rating > 0)
      {
        for (int i = 1; i <= Rating; i++)
        {
          starRating += "⭐ ";
        }
        return starRating;
      }
    }

  }

}
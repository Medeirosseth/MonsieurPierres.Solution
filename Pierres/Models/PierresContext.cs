using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pierres.Models
{
  public class PierresContext : IdentityDbContext<ApplicationUser>
  {
    
  }
}
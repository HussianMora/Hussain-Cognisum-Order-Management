using Microsoft.EntityFrameworkCore;

namespace OrderDAL.Models
{
    public class ApplicationDBContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}

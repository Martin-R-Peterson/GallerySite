using GallerySite.Models;
using Microsoft.EntityFrameworkCore;

namespace GallerySite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<AlbumModel> Albums { get; set; }
        public DbSet<ImageModel> Images { get; set; }

    }
}

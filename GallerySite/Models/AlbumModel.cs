using System.ComponentModel.DataAnnotations;

namespace GallerySite.Models
{
    public class AlbumModel
    {

        public int Id { get; set; }
        [StringLength(80)]
        public string Title { get; set; }

        public string searchQuery { get; set; }
    }
}

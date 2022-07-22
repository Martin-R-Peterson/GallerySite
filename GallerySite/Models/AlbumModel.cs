using System.ComponentModel.DataAnnotations;

namespace GallerySite.Models
{
    public class AlbumModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(80)]
        public string Title { get; set; }
    }
}

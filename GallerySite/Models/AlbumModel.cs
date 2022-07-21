using System.ComponentModel.DataAnnotations;

namespace GallerySite.Models
{
    public class AlbumModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}

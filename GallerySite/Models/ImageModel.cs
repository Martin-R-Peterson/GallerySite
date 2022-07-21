using System.ComponentModel.DataAnnotations;

namespace GallerySite.Models
{
    public class ImageModel
    {
        public int AlbumId { get; set; }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }

    }
}

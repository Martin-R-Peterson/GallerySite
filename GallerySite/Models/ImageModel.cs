using System.ComponentModel.DataAnnotations;

namespace GallerySite.Models
{
    public class ImageModel
    {
        [Required]
        public int AlbumId { get; set; }

        public int Id { get; set; }
        [StringLength(80)]
        public string Title { get; set; }
        [Url]
        public string Url { get; set; }
        [Url]
        public string ThumbnailUrl { get; set; }

    }
}

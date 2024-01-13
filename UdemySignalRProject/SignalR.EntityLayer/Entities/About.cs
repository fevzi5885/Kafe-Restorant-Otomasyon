using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string? ImgaeUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

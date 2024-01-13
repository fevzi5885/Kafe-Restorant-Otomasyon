using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
    public class Booking
    {
        [Key]
        public int BokkingID {  get; set; }
        public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Phone { get; set; }
        public string? Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date {  get; set; }
    }
}

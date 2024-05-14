using System.ComponentModel.DataAnnotations;

namespace EShopAdminApplication.Models
{
    public class Ticket
    {
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Rating { get; set; }
    }
}

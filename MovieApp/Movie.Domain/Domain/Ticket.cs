using Movie.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Domain.Domain
{
    public class Ticket : BaseEntity
    {
        [Required]
        public double Price { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }
        public virtual EShopApplicationUser? CreatedBy { get; set; }
        public virtual ICollection<TicketInOrder>? TicketInOrder { get;}
    }
}

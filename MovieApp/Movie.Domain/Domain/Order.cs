using Movie.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace Movie.Domain.Domain
{
    public class Order : BaseEntity
    {
        public string userId { get; set; }
        public EShopApplicationUser Owner { get; set; }
        public ICollection<TicketInOrder>? TicketInOrder { get; set; }
    }
}

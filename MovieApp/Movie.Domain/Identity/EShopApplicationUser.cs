using Microsoft.AspNetCore.Identity;
using Movie.Domain.Domain;

namespace Movie.Domain.Identity
{
    public class EShopApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Ticket> MyTickets { get; set; }
        public Guid? OrderId { get; set; }
        public virtual ICollection<Order>? MyOrder { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }

}

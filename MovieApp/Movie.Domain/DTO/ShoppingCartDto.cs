using Movie.Domain.Domain;

namespace Movie.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<TicketInShoppingCart>? Products { get; set; }
        public double TotalPrice { get; set; }
    }
}

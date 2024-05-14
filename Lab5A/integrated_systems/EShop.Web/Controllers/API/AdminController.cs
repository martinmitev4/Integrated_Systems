using EShop.Domain.Domain;
using EShop.Domain.Identity;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_App.Service.Interface;
using Stripe.Terminal;

namespace EShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IConcertService _concertService;
        public AdminController(IOrderService orderService, IConcertService concertService)
        {
            _orderService = orderService;
            _concertService = concertService;
        }
        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }
        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity id)
        {
            var order = this._orderService.GetDetailsForOrder(id);
            return order;
        }

        [HttpPost("[action]")]
        public bool ImportAllUsers(List<Concert> model)
        {
            bool status = true;

            foreach (var item in model)
            {

                var concert = new Concert
                {
                    ConcertName = item.ConcertName,
                    ConcertDescription = item.ConcertDescription,
                    ConcertImage = item.ConcertImage,
                    Rating = item.Rating
                };
                _concertService.CreateNewConcert(concert);
            }
            return status;
        }

    }
}

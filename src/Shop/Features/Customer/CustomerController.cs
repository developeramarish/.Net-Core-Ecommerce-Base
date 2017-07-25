using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Features.Home;

namespace Shop.Features.Customer
{
    [Route("customer")]
    public class CustomerController : Controller
    {

        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Route("register")]
        public IActionResult CustomerCreate()
        {
            return View();
        }

        [HttpPost, Route("register")]

        public async Task<IActionResult> CustomerCreate(CustomerCreate.Command command)
        {
            await _mediator.Send(command);

            return new HomeController().RedirectToActionJson(nameof(HomeController.Index));
        }
    }
}
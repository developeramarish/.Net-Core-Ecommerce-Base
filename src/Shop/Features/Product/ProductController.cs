using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Features.Product
{
    public class ProductController : Controller
    {

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("products")]
        public async Task<IActionResult> Index()
        {

            var model = await _mediator.Send(new Index.Query());

            return View(model);
        }
    }
}
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Features.Admin
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("products")]
        public async Task<IActionResult> Products()
        {
            var model = await _mediator.Send(new Products.Query());

            return View(model);
        }

        [HttpGet, Route("productcreate")]
        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost, Route("productcreate")]
        
        public async Task<IActionResult> ProductCreate(ProductCreate.Command command)
        {
            await _mediator.Send(command);

            return this.RedirectToActionJson(nameof(Products));
        }
    }
}
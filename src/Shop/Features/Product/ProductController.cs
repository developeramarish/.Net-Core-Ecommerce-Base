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

        [HttpGet, Route("~/products")]
        public async Task<IActionResult> Index()
        {

            var model = await _mediator.Send(new Index.Query());

            return View(model);
        }

        [HttpGet, Route("manageproducts")]
        public async Task<IActionResult> ManageProducts()
        {
            var model = await _mediator.Send(new ManageProducts.Query());

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

            return this.RedirectToActionJson(nameof(ManageProducts));
        }

        [HttpGet, Route("productedit")]
        public async Task<IActionResult> ProductEdit(ProductEdit.Query query)
        {
            var model = await _mediator.Send(query);

            return View(model);
        }

        [HttpPost, Route("productedit")]
        public async Task<IActionResult> ProductEdit(ProductEdit.Command command)
        {
            await _mediator.Send(command);

            return this.RedirectToActionJson(nameof(ManageProducts));
        }

        [HttpGet, Route("productdelete")]
        public async Task<IActionResult> ProductDelete(ProductDelete.Query query)
        {
            await _mediator.Send(query);

            return this.RedirectToActionJson(nameof(ManageProducts));
        }

        [HttpPost, Route("productdelete")]

        public async Task<IActionResult> ProductDelete(ProductDelete.Command command)
        {
            await _mediator.Send(command);

            return this.RedirectToActionJson(nameof(ManageProducts));
        }

    }
}
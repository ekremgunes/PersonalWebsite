using gunesekremcom.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gunesekremcom.ViewComponents
{
    public class CategoryComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public CategoryComponent(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _mediator.Send(new CategoryComponentQuery());
            return View(categories);
        }
    }
}

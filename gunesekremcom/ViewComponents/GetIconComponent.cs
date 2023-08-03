using gunesekremcom.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gunesekremcom.ViewComponents
{
    public class GetIconComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public GetIconComponent(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _mediator.Send(new GetIconComponentQuery());
            return View(model);
        }
    }
}

using gunesekremcom.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gunesekremcom.ViewComponents
{
    public class AboutComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public AboutComponent(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _mediator.Send(new AboutComponentQuery());
            return View(model);
        }
    }
}

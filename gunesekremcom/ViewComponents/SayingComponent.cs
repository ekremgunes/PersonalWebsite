using gunesekremcom.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gunesekremcom.ViewComponents
{
    public class SayingComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public SayingComponent(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var saying = await _mediator.Send(new SayingComponentQuery());
            return View(saying);
        }
    }
}

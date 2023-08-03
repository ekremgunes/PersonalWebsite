using gunesekremcom.CQRS.Queries.ViewComponentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gunesekremcom.ViewComponents
{
    public class GetLogoComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public GetLogoComponent(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var src = await _mediator.Send(new GetLogoComponentQuery());
            return View(src);
        }
    }
}

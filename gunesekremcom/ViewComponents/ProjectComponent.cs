using gunesekremcom.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gunesekremcom.ViewComponents
{
    public class ProjectComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ProjectComponent(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var projects = await _mediator.Send(new ProjectComponentQuery());
            return View(projects);
        }
    }
}

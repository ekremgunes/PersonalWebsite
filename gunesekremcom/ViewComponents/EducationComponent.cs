using gunesekremcom.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gunesekremcom.ViewComponents
{
    public class EducationComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public EducationComponent(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var educations = await _mediator.Send(new EducationComponentQuery());
            return View(educations);
        }
    }
}

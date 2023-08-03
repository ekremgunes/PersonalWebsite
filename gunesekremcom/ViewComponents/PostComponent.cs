using gunesekremcom.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gunesekremcom.ViewComponents
{
    public class PostComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public PostComponent(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _mediator.Send(new PostComponentQuery());
            return View(posts);
        }
    }
}

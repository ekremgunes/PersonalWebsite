using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using gunesekremcom.Data.Validations.CategoryValidations;
using gunesekremcom.Data.Validations.CommentValidations;
using gunesekremcom.Data.Validations.PostValidations;
using gunesekremcom.Data.Validations.ReplyValidations;
using gunesekremcom.Tools;
using gunesekremcom.Tools.Enums;
using gunesekremcom.Tools.Helpers;
using gunesekremcom.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static gunesekremcom.Tools.Helpers.ValidationHelper;

namespace gunesekremcom.Controllers
{
    [AutoValidateAntiforgeryToken]
    //post,category,comment,reply
    public class BlogController : Controller
    {
        private readonly IUow _uow;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BlogController(IMediator _mediator, IUow _uow, IMapper _mapper)
        {
            this._mediator = _mediator;
            this._uow = _uow;
            this._mapper = _mapper;
        }
        public async Task<IActionResult> Index([FromQuery] string slug)
        {
            var post = await _mediator.Send(new GetPostBySlugQuery(slug));
            return View(post);
        }


        #region Blog Region
        #region Create
        [Authorize]

        public async Task<IActionResult> CreatePost()
        {
            ViewBag.Categories = await _mediator.Send(new GetCategoriesQuery());
            if (ViewBag.Categories?.Count < 1)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"Paylaşım yapabilmek için bir kategoriye ihtiyacınız var");
                return RedirectToAction("CreateCategory");
            }
            return View();
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreatePost(CreatePostCommand model, IFormFile postImg)
        {
            ViewBag.Categories = await _mediator.Send(new GetCategoriesQuery());
            if (postImg == null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"Resim alanı zorunlu");
                ModelState.AddModelError("Image", "Resim yüklemek zorunlu");
                return View(model);
            }
            var validator = new CreatePostCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                var path = await FileHelper.CreateFile(postImg);
                model.Image = path;
                model.Slug = await SlugMaker.Make(model.Title);
                model.ReadingTime = ReadingTime.Calculate(model.Content);
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Paylaşım başarıyla yüklendi");
                return RedirectToAction("Posts");

            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);
        }
        #endregion

        #region Read        
        [Authorize]
        public async Task<IActionResult> Posts()
        {
            var posts = await _mediator.Send(new GetPostsQuery());
            return View(posts);
        }
        [HttpGet]
        public async Task<IActionResult> Explorer([FromQuery] string category)
        {
            var posts = new List<GetPostsQueryResult>();
            var model = new BlogViewModel();
            int postSize = 4;
            if (!string.IsNullOrWhiteSpace(category))
            {
                model.CategoryName = category;
                posts = await _mediator.Send(new GetPostsByCategoryQuery(category, postSize));
            }
            else
            {
                posts = await _mediator.Send(new GetPostsQuery(postSize));

            }


            var categories = await _mediator.Send(new GetCategoriesQuery());
            categories = categories.Take(10).ToList();
            model.Categories = categories;
            model.Posts = posts;

            return View(model);
        }

        #region LoadMore
        [IgnoreAntiforgeryToken]
        [HttpGet]
        public async Task<IActionResult> LoadMore(string category = "", int pageIndex = 2)
        {
            var posts = await _mediator.Send(new LoadMorePostQuery(pageIndex, category));
            return View(posts);
        }
        #endregion
        #endregion

        #region Update
        [Authorize]

        public async Task<IActionResult> UpdatePost(int id)
        {
            var entity = await _mediator.Send(new GetPostByIdQuery(id));
            if (entity is null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"{id} numaralı paylaşım bulunamadı");
                return RedirectToAction("Posts");
            }
            ViewBag.Categories = await _mediator.Send(new GetCategoriesQuery());
            return View(entity);
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> UpdatePost(UpdatePostCommand model, IFormFile postImg)
        {
            ViewBag.Categories = await _mediator.Send(new GetCategoriesQuery());

            var validator = new UpdatePostCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                if (postImg != null)
                {
                    model.Image = await FileHelper.ReplaceFile(model.Image, postImg);

                }
                model.ReadingTime = ReadingTime.Calculate(model.Content);
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Güncelleme Başarılı");
                return RedirectToAction("Posts");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<JsonResult> InsertViewCount([FromBody] int id)
        {
            var post = await _uow.GetRepository<Post>().
                GetQuery()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (post != null)
            {
                post.ViewCount += 1;
                await _uow.SaveChangesAsync();
            }
            return Json(true);
        }
        #endregion

        #region Delete
        [IgnoreAntiforgeryToken]
        [Authorize]
        [HttpPost]
        public async Task<JsonResult> DeletePost(int id)
        {
            await _mediator.Send(new RemovePostCommand(id));
            return Json(true);
        }
        #endregion

        #endregion


        #region Category Region

        #region Create 


        [HttpGet]
        [Authorize]

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateCategory(CreateCategoryCommand model)
        {
            var validator = new CreateCategoryCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                await _mediator.Send(model);
                return RedirectToAction("Categories");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);

        }
        #endregion

        #region Read
        [Authorize]

        public async Task<IActionResult> Categories()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return View(result);
        }
        #endregion

        #region Update
        [HttpGet]
        [Authorize]

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var entity = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (entity is null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"{id} numaralı kategori bulunamadı");
                return RedirectToAction("categories");
            }
            return View(entity);
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand model)
        {
            var validator = new UpdateCategoryCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Güncelleme Başarılı");
                return RedirectToAction("Categories");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(_mapper.Map<GetCategoryByIdQueryResult>(model));
        }
        #endregion

        #region Delete
        [HttpPost]
        [Authorize]
        [IgnoreAntiforgeryToken]

        public async Task<JsonResult> DeleteCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return Json(true);
        }
        #endregion


        #endregion

        #region Comment Region
        [Authorize]

        public async Task<IActionResult> Comments()
        {
            var comments = await _mediator.Send(new GetCommentsQuery());
            return View(comments);
        }
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<JsonResult> CreateComment([FromBody] CreateCommentCommand model)
        {
            var validator = new CreateCommentCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                await _mediator.Send(model);
                return Json(true);
            }
            return Json(false);

        }
        [IgnoreAntiforgeryToken]
        [Authorize]
        [HttpPost]

        public async Task<JsonResult> DeleteComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Json(true);
        }
        #endregion

        #region Reply Region
        [Authorize]

        public async Task<IActionResult> Replies()
        {
            var replies = await _mediator.Send(new GetRepliesQuery());
            return View(replies);
        }
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<JsonResult> CreateReply([FromBody] CreateReplyCommand model)
        {
            var validator = new CreateReplyCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                await _mediator.Send(model);
                return Json(true);
            }
            return Json(false);

        }
        [Authorize]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<JsonResult> DeleteReply(int id)
        {
            await _mediator.Send(new RemoveReplyCommand(id));
            return Json(true);
        }
        #endregion

    }
}

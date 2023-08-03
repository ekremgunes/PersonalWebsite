using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Commands.EmailAddressCommands;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.Data.Validations.EmailAdressValidations;
using gunesekremcom.Tools;
using gunesekremcom.Tools.EmailService;
using gunesekremcom.Tools.Enums;
using gunesekremcom.Tools.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static gunesekremcom.Tools.Helpers.ValidationHelper;

namespace gunesekremcom.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEmailService _mailSender;

        public HomeController(IMediator _mediator, IEmailService mailSender)
        {
            this._mediator = _mediator;
            _mailSender = mailSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Education Pages
        public async Task<IActionResult> Educations()
        {
            var educations = await _mediator.Send(new GetEducationsQuery());
            return View(educations);
        }
        public async Task<IActionResult> Education([FromQuery] string slug)
        {
            var result = await _mediator.Send(new GetEducationBySlugQuery(slug));
            return View(result);
        }
        #endregion

        #region Project Pages
        public async Task<IActionResult> Projects()
        {

            var projects = await _mediator.Send(new GetProjectsQuery());
            return View(projects);
        }
        public async Task<IActionResult> Project(int id)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery(id));
            return View(project);
        }
        #endregion

        #region Categories Page
        public async Task<IActionResult> Categories()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return View(result);
        }
        #endregion

        #region Certificate
        public async Task<IActionResult> Certificate(int id)
        {
            var certificate = await _mediator.Send(new GetCertificateByIdQuery(id));
            return View(certificate);
        }
        #endregion

        #region Email Actions
        [HttpPost]
        public async Task<JsonResult> SubscribeToMailAddress([FromBody] string Email)
        {
            var validator = new CreateEmailAdressCommandValidator();
            var model = new CreateEmailAddressCommand { Email = Email };
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                var createResult = await _mediator.Send(model);
                if (createResult.isSubscriber)
                {
                    return Json("Daha önce abone olunmuş."); //example: you are already sub vs..
                }
                var mailHTML = $" <h3>Aramıza hoşgeldin! artık birlikteyiz 😍.</h3>" +
                    $"<p><a href='http://gunesekrem.com/Home/ConfirmEmail?ConfirmCode={createResult.ConfirmCode}'> <b>⭐Buraya⭐</b></a>" +
                    $" tıklayarak mail adresini onaylayabilirsin.</p><br><br><small> Unutma, mail adresini onaylamazsan ücretsiz mail aboneliğin geçersiz sayılacak.</small>";
                try
                {
                    await _mailSender.SendEmail(Email, " Hoşgeldin! Doğrulama Kodu", mailHTML);
                }
                catch (Exception e)
                {
                    LogHelper.Log($"E mail gönderme işlemi başarısız.Kullanıcı kaydı tamamlanamadı,kullanıcı mail: {Email}", null, null);
                    return Json("Mail sunucusu çok yoğun daha sonra tekrar deneyin.Bizimle iletişime geçerek kaydınızı tamamlayın .");
                }
                return Json(true);
            }
            return Json(result.Errors.First().ErrorMessage);
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string ConfirmCode = "")
        {
            if (string.IsNullOrEmpty(ConfirmCode))
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Error, "Doğrulama Başarısız :(  Kod hatalı");
                return RedirectToAction("Index", "Home");
            }
            var result = await _mediator.Send(new ConfirmEmailAddressCommand(ConfirmCode));

            if (result.isSucceeded == true)
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, "Email adresin başarıyla doğrulandı!");
            else
                TempData["alerts"] = Alert.ViewAlert(AlertType.Error, "Doğrulama Başarısız :( ");


            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Statistic Action
        [HttpPost]
        public async Task<JsonResult> IncreaseVisitor()
        {
            await _mediator.Send(new IncreaseVisitorCommand());
            return Json(true);
        }
        #endregion
    }
}
using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Commands.EmailAddressCommands;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Queries.EmailAddressQueries;
using gunesekremcom.CQRS.Queries.SettingsQueries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Validations.EmailAdressValidations;
using gunesekremcom.Data.Validations.SayingValidations;
using gunesekremcom.Data.Validations.SeoValidations;
using gunesekremcom.Data.Validations.SettingsValidations;
using gunesekremcom.Tools;
using gunesekremcom.Tools.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static gunesekremcom.Tools.Helpers.ValidationHelper;

namespace gunesekremcom.Controllers
{
    //saying,seo,settings
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SettingsController(IMediator _mediator, IMapper _mapper)
        {
            this._mediator = _mediator;
            this._mapper = _mapper;
        }
        public async Task<IActionResult> Index() //panel index 
        {
            var model = await _mediator.Send(new GetStatisticsQuery());
            return View(model);
        }

        public IActionResult Pages()
        {
            return View();
        }

        #region Seo Region
        public async Task<IActionResult> Seo()
        {
            var seo = await _mediator.Send(new GetSeoQuery());
            return View(seo);
        }
        [HttpPost]
        public async Task<IActionResult> Seo(UpdateSeoCommand model)
        {
            var validator = new UpdateSeoCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, "Güncelleme Başarılı");

                return View(_mapper.Map<GetSeoQueryResult>(model));
            }
            AddModelErrorsToModelState(ModelState, result);
            TempData["alerts"] = Alert.ViewAlert(AlertType.Error, "Bilgileri Eksiksiz şekilde girdiğinize emin olun");
            return View(_mapper.Map<GetSeoQueryResult>(model));
        }
        #endregion

        #region Saying Region

        #region Create
        [HttpGet]
        public IActionResult CreateSaying()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSaying(CreateSayingCommand model)
        {
            var validator = new CreateSayingCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, "Söz Başarıyla Eklendi");
                return RedirectToAction("Sayings");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);

        }
        #endregion

        #region Read
        public async Task<IActionResult> Sayings()
        {
            var sayings = await _mediator.Send(new GetSayingsQuery());
            return View(sayings);
        }
        #endregion

        #region Update
        public async Task<IActionResult> UpdateSaying(int id)
        {
            var saying = await _mediator.Send(new GetSayingByIdQuery(id));
            if (saying is null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"{id} numaralı söz bulunamadı");
                return RedirectToAction("Sayings");
            }
            return View(saying);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSaying(UpdateSayingCommand model)
        {
            var validator = new UpdateSayingCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, "Güncelleme Başarılı");
                return RedirectToAction("Sayings");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(_mapper.Map<GetSayingByIdQueryResult>(model));
        }
        #endregion

        #region Delete
        [HttpPost]
        [IgnoreAntiforgeryToken]

        public async Task<JsonResult> DeleteSaying(int id)
        {
            await _mediator.Send(new RemoveSayingCommand(id));
            return Json(true);
        }
        #endregion

        #endregion

        #region Settings Region
        public async Task<IActionResult> UpdateSettings()
        {
            var settings = await _mediator.Send(new GetSettingsQuery());
            return View(settings);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSettings(UpdateSettingsCommand model, IFormFile logoImg, IFormFile profilePhoto, IFormFile IconFile)
        {
            var validator = new UpdateSettingsCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                if (logoImg != null)
                {
                    if (model.LogoImage == "default.jpg")
                    {
                        var path = await FileHelper.CreateFile(logoImg);
                        model.LogoImage = path;
                    }
                    else
                    {
                        var path = await FileHelper.ReplaceFile(model.LogoImage, logoImg);
                        model.LogoImage = path;
                    }
                }
                if (profilePhoto != null)
                {
                    if (model.ProfilePhoto == "default.jpg")
                    {
                        var path = await FileHelper.CreateFile(profilePhoto);
                        model.ProfilePhoto = path;
                    }
                    else
                    {
                        var path = await FileHelper.ReplaceFile(model.ProfilePhoto, profilePhoto);
                        model.ProfilePhoto = path;
                    }
                }
                if (IconFile != null)
                {
                    var path = await FileHelper.ReplaceFile(model.Icon, IconFile);
                    model.Icon = path;
                }
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, "Güncelleme Başarılı");
                return RedirectToAction("UpdateSettings");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(_mapper.Map<GetSettingsQueryResult>(model));

        }
        #endregion

        #region Email Address Region
        [HttpPost]
        [IgnoreAntiforgeryToken]

        public async Task<JsonResult> DeleteEmailAddress([FromBody] int id)
        {
            if (id < 1)
            {
                return Json(false);
            }
            await _mediator.Send(new DeleteEmailAddressCommand(id));
            return Json(true);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]

        public async Task<JsonResult> DeleteEmailAddresses([FromBody] int[] selectedIds)
        {
            if (selectedIds.Length < 1)
            {
                return Json(false);
            }

            var u = User;

            await _mediator.Send(new DeleteEmailAddressesCommand(selectedIds));

            return Json(true);
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]

        public async Task<JsonResult> SendEmails([FromBody] SendEmailsCommand model)
        {
            var validator = new SendEmailsCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                await _mediator.Send(model);
                return Json(true);

            }
            return Json(result.Errors.First().ErrorMessage);
        }
        public async Task<IActionResult> SubscriberMails()
        {
            var mails = await _mediator.Send(new GetEMailAddressesQuery());
            return View(mails);
        }
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<JsonResult> ConfirmEmailAddress([FromBody] string ConfirmCode = "")
        {
            if (string.IsNullOrEmpty(ConfirmCode))
            {
                return Json(false);
            }
            var result = await _mediator.Send(new ConfirmEmailAddressCommand(ConfirmCode));

            if (result.isSucceeded == true)
                return Json(true);
            else
                return Json(false);
        }

        #endregion
    }
}

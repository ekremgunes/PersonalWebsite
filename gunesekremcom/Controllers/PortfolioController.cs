using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Commands.SocialMediaCommands;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using gunesekremcom.Data.Validations.CertificateValidations;
using gunesekremcom.Data.Validations.EducationValidations;
using gunesekremcom.Data.Validations.ProjectValidations;
using gunesekremcom.Data.Validations.SocialMediaValidations;
using gunesekremcom.Data.Validations.TechnologyValidations;
using gunesekremcom.Tools;
using gunesekremcom.Tools.Enums;
using gunesekremcom.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static gunesekremcom.Tools.Helpers.ValidationHelper;

namespace gunesekremcom.Controllers
{
    //education,socialmedia,tech,project,certificate
    [AutoValidateAntiforgeryToken]

    public class PortfolioController : Controller
    {
        private readonly IUow _uow;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PortfolioController(IMediator _mediator, IUow _uow, IMapper _mapper)
        {
            this._mediator = _mediator;
            this._uow = _uow;
            this._mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = new PortfolioViewModel
            {
                Settings = await _mediator.Send(new GetSettingsQuery()),
                Certifications = await _mediator.Send(new GetCertificationsQuery()),
                SocialMedias = await _mediator.Send(new GetSocialMediasQuery()),
                Technologies = await _mediator.Send(new GetTechnologiesQuery())
            };
            return View(model);
        }

        #region Education Region
        #region Create
        [Authorize]

        public IActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateEducation(CreateEducationCommand model, IFormFile educationImg)
        {
            if (educationImg == null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"Resim alanı zorunlu");
                ModelState.AddModelError("Image", "Resim yüklemek zorunlu");
                return View(model);
            }
            var validator = new CreateEducationCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                var path = await FileHelper.CreateFile(educationImg);
                model.Image = path;
                model.Slug = await SlugMaker.Make(model.Title);
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Eğitim başarıyla eklendi");
                return RedirectToAction("Educations");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);
        }
        #endregion

        #region Read
        [Authorize]
        public async Task<IActionResult> Educations()
        {
            var educations = await _mediator.Send(new GetEducationsQuery());
            return View(educations);
        }
        #endregion

        #region Update
        [Authorize]

        public async Task<IActionResult> UpdateEducation(int id)
        {
            var entity = await _mediator.Send(new GetEducationByIdQuery(id));
            return View(entity);
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> UpdateEducation(UpdateEducationCommand model, IFormFile educationImg)
        {

            var validator = new UpdateEducationCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                if (educationImg != null)
                {
                    model.Image = await FileHelper.ReplaceFile(model.Image, educationImg);

                }
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Güncelleme Başarılı");
                return RedirectToAction("Educations");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(_mapper.Map<GetEducationByIdQueryResult>(model));
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<JsonResult> InsertEducationViewCount([FromBody] int id)
        {
            var education = await _uow.GetRepository<Education>().GetByIdAsync(id);
            if (education != null)
            {
                education.ViewCount += 1;
                await _uow.SaveChangesAsync();
            }
            return Json(true);
        }
        #endregion

        #region Delete
        [Authorize]
        [IgnoreAntiforgeryToken]
        [Authorize]
        public async Task<JsonResult> DeleteEducation(int id)
        {
            await _mediator.Send(new RemoveEducationCommand(id));
            return Json(true);
        }
        #endregion

        #endregion

        #region Project Region
        #region Create
        [Authorize]

        public IActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateProject(CreateProjectCommand model, IFormFile projectImg)
        {
            if (projectImg == null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"Resim alanı zorunlu");
                ModelState.AddModelError("Image", "Resim yüklemek zorunlu");
                return View(model);
            }
            var validator = new CreateProjectCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                var path = await FileHelper.CreateFile(projectImg);
                model.Image = path;
                model.Slug = await SlugMaker.Make(model.Title);
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Proje başarıyla eklendi");

                return RedirectToAction("Projects");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);

        }
        #endregion

        #region Read
        [Authorize]

        public async Task<IActionResult> Projects()
        {
            var projects = await _mediator.Send(new GetProjectsQuery());
            return View(projects);
        }

        #endregion

        #region Update
        [Authorize]

        public async Task<IActionResult> UpdateProject(int id)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery(id));
            if (project is null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"{id} numaralı proje bulunamadı");

                return RedirectToAction("Projects");
            }
            return View(project);
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> UpdateProject(UpdateProjectCommand model, IFormFile projectImg)
        {

            var validator = new UpdateProjectCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                if (projectImg != null)
                {
                    model.Image = await FileHelper.ReplaceFile(model.Image, projectImg);
                }

                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Güncelleme Başarılı");

                return RedirectToAction("Projects");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(_mapper.Map<GetProjectByIdQueryResult>(model));

        }
        #endregion

        #region Delete
        [Authorize]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<JsonResult> DeleteProject(int id)
        {
            await _mediator.Send(new RemoveProjectCommand(id));
            return Json(true);
        }
        #endregion

        #endregion

        #region SocialMedia Region
        #region Create
        [Authorize]

        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand model, IFormFile IconFile)
        {
            if (IconFile == null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"Resim alanı zorunlu");
                ModelState.AddModelError("Image", "Resim yüklemek zorunlu");
                return View(model);
            }
            var validator = new CreateSocialMediaValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                var path = await FileHelper.CreateFile(IconFile);
                model.Icon = path;
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Sosyal Medya Hesabı Oluşturuldu");
                return RedirectToAction("SocialMedias");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);

        }
        #endregion

        #region Read
        [Authorize]

        public async Task<IActionResult> SocialMedias()
        {
            var socialMedias = await _mediator.Send(new GetSocialMediasQuery());
            return View(socialMedias);
        }
        #endregion

        #region Update
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<JsonResult> InsertClickCount([FromBody] int id)
        {
            await _mediator.Send(new InsertClickCountCommand(id));
            return Json(true);
        }
        [Authorize]

        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var entity = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            if (entity is null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"{id} numaralı hesap bulunamadı");
                return RedirectToAction("SocialMedias");
            }
            return View(entity);
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand model, IFormFile IconFile)
        {

            var validator = new UpdateSocialMediaValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                if (IconFile != null)
                {
                    var path = await FileHelper.ReplaceFile(model.Icon, IconFile);
                    model.Icon = path;
                }

                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Güncelleme Başarılı");
                return RedirectToAction("SocialMedias");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(_mapper.Map<GetSocialMediaByIdQueryResult>(model));

        }
        #endregion

        #region Delete
        [Authorize]
        [HttpPost]
        [IgnoreAntiforgeryToken]

        public async Task<JsonResult> DeleteSocialMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Json(true);
        }
        #endregion

        #endregion

        #region Technologies Region
        #region Create
        [Authorize]

        public IActionResult CreateTechnology()
        {
            return View();
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateTechnology(CreateTechnologyCommand model, IFormFile IconFile)
        {
            if (IconFile == null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"Resim alanı zorunlu");
                ModelState.AddModelError("Image", "Resim yüklemek zorunlu");
                return View(model);
            }
            var validator = new CreateTechnologyCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                var path = await FileHelper.CreateFile(IconFile);
                model.Icon = path;
                await _mediator.Send(model);

                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Teknoloji eklendi");
                return RedirectToAction("Technologies");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);

        }
        #endregion

        #region Read
        [Authorize]

        public async Task<IActionResult> Technologies()
        {
            var techs = await _mediator.Send(new GetTechnologiesQuery());
            return View(techs);
        }
        #endregion

        #region Update
        [Authorize]

        public async Task<IActionResult> UpdateTechnology(int id)
        {
            var entity = await _mediator.Send(new GetTechnologyByIdQuery(id));
            if (entity == null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"{id} numaralı teknoloji bulunamadı");
                return RedirectToAction("Technologies");
            }
            return View(entity);
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> UpdateTechnology(UpdateTechnologyCommand model, IFormFile IconFile)
        {

            var validator = new UpdateTechnologyCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                if (IconFile != null)
                {
                    var path = await FileHelper.ReplaceFile(model.Icon, IconFile);
                    model.Icon = path;
                }

                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Güncelleme Başarılı");
                return RedirectToAction("Technologies");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(_mapper.Map<GetTechnologyByIdQueryResult>(model));
        }
        #endregion

        #region Delete
        [Authorize]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<JsonResult> DeleteTechnology(int id)
        {
            await _mediator.Send(new RemoveTechnologyCommand(id));
            return Json(true);
        }
        #endregion



        #endregion

        #region Certificate Region
        #region Create
        [Authorize]
        public IActionResult CreateCertificate()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCertificate(CreateCertificateCommand model, IFormFile CertificateImg)
        {
            if (CertificateImg == null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"Resim alanı zorunlu");
                ModelState.AddModelError("Image", "Resim yüklemek zorunlu");
                return View(model);
            }
            var validator = new CreateCertificateCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                var imgPath = await FileHelper.CreateFile(CertificateImg);
                model.Image = imgPath;
                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Sertifika Eklendi");
                return RedirectToAction("Certifications");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);

        }
        #endregion

        #region Read
        [Authorize]
        public async Task<IActionResult> Certifications()
        {
            var certifications = await _mediator.Send(new GetCertificationsQuery());
            return View(certifications);
        }

        public async Task<IActionResult> Certificate(int id)
        {
            var certificate = await _mediator.Send(new GetCertificateByIdQuery(id));
            return View(certificate);
        }
        #endregion

        #region Update
        [Authorize]
        public async Task<IActionResult> UpdateCertificate(int id)
        {
            var entity = await _mediator.Send(new GetCertificateByIdQuery(id));
            if (entity is null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Warning, $"{id} numaralı sertifika bulunamadı");
                return RedirectToAction("Certifications");
            }
            return View(entity);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateCertificate(UpdateCertificateCommand model, IFormFile CertificateImg)
        {

            var validator = new UpdateCertificateCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                if (CertificateImg != null)
                {
                    var newImgPath = await FileHelper.ReplaceFile(model.Image, CertificateImg);
                    model.Image = newImgPath;
                }


                await _mediator.Send(model);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"Güncelleme Başarılı");

                return RedirectToAction("Certifications");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(_mapper.Map<GetCertificateByIdQueryResult>(model));
        }
        #endregion

        #region Delete
        [Authorize]
        [IgnoreAntiforgeryToken]

        public async Task<JsonResult> DeleteCertificate(int id)
        {
            await _mediator.Send(new RemoveCertificateCommand(id));
            return Json(true);
        }
        #endregion

        #endregion



    }
}

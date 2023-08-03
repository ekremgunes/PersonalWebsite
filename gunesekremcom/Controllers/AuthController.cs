using AutoMapper;
using FluentValidation;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results.UserResults;
using gunesekremcom.Data.Validations.UserValidations;
using gunesekremcom.Tools;
using gunesekremcom.Tools.EmailService;
using gunesekremcom.Tools.Enums;
using gunesekremcom.Tools.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static gunesekremcom.Tools.Helpers.ValidationHelper;



namespace gunesekremcom.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IEmailService _mailSender;
        private readonly IValidator<CheckUserQuery> _loginValidator;
        private readonly IConfiguration _configuration;
        public AuthController(IMediator _mediator, IValidator<CheckUserQuery> _loginValidator, IEmailService mailSender, IConfiguration configuration, IMapper mapper)
        {
            this._mediator = _mediator;
            this._loginValidator = _loginValidator;
            _mailSender = mailSender;
            _configuration = configuration;
            _mapper = mapper;
        }
        #region Login-logout

        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, "Hoşgeldin, Daha Öncesinde Giriş Yaptınız 😊");
                return RedirectToAction("Index", "Settings");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(CheckUserQuery model)
        {

            var result = _loginValidator.Validate(model);
            if (result.IsValid)
            {
                var user = new CheckUserQuery();
                user.Name = model.Name;
                user.Password = model.Password;

                var checkResponse = await _mediator.Send(user);
                if (checkResponse.IsExist)
                {
                    var tokenModel = JwtTokenGenerator.GenerateToken(checkResponse);

                    if (tokenModel != null)
                    {
                        JwtSecurityTokenHandler handler = new();
                        var token = handler.ReadJwtToken(tokenModel.Token);

                        var claims = token.Claims.ToList();

                        if (tokenModel.Token != null)
                            claims.Add(new Claim("accesToken", tokenModel.Token));

                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true,
                        };


                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        TempData["alerts"] = Alert.ViewAlert(AlertType.Success, "Hoşgeldin. Giriş Başarılı");

                        //send mail to admin for security
                        var remoteIP = HttpContext.Connection.RemoteIpAddress;
                        var browser = HttpContext.Request.Headers["User-Agent"];
                        //var targetEmail = _configuration["SmtpSettings:EmailAdress"];                        
                        var targetEmail = checkResponse.Email;

                        var mailHTML =
                            $"<h2>Panele Giriş Yapıldı .</h2>" +
                            $"<p>Eğer giriş işlemi bilginiz dahilinde ise bu maili göz ardı edebilirsiniz.</p><hr><br>" +
                            $"<p>Tarih :{DateTime.Now} </p>" +
                            $"<p>IP : {remoteIP} </p>" +
                            $"<p>Tarayıcı Bilgileri : ${browser} </p><br> "
                            ;
                        try
                        {
                            await _mailSender.SendEmail(targetEmail, "⚠️ Güvenlik Bildirimi ⚠️", mailHTML);
                        }
                        catch (Exception)
                        {
                            LogHelper.Log("E mail gönderme işlemi başarısız. ", null, null);
                        }


                        return RedirectToAction("Index", "Settings");
                    }
                }

            }
            TempData["alerts"] = Alert.ViewAlert(AlertType.Error, "Kullanıcı adı veya şifre yanlış");

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region ForgetPassword

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Error, "Kullanıcı adı eksik veya hatalı");
                return View();
            }
            var user = await _mediator.Send(new GetUserQuery(userName));
            if (user.Email == null)
            {
                TempData["alerts"] = Alert.ViewAlert(AlertType.Error, "Kullanıcı bulunamadı");
                return View();
            }
            var mailHTML =
                $"<h3>Sayın {user.Name}</h3>" +
                $"<p><b>{DateTime.Now}</b> tarihinde şifre bilgisi talebinde bulundunuz.<br><br>Şifre (Password) : {user.Password} </p>";
            try
            {
                await _mailSender.SendEmail(user.Email, "Şifremi Unuttum", mailHTML);
                var filteredMail = user.Email.Remove(0, 3);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Success, $"***{filteredMail} adresine bilgiler başarıyla gönderildi.Mailinizi kontrol edin");
            }
            catch (Exception)
            {
                LogHelper.Log("E mail gönderme işlemi başarısız. ", null, null);
                TempData["alerts"] = Alert.ViewAlert(AlertType.Error, $"Mail sunucusu çok yoğun , daha sonra tekrar deneyin.");

                return View();
            }

            return RedirectToAction("Login", "Auth");
        }
        #endregion

        #region UpdateAccount
        [Authorize]
        public async Task<IActionResult> UpdateAccount()
        {
            var activeUser = User.Identity as ClaimsIdentity;
            var model = await _mediator.Send(new GetUserQuery(activeUser!.FindFirst("Name")!.Value));
            return View(_mapper.Map<UpdateUserCommand>(model));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateAccount(UpdateUserCommand model)
        {
            var validator = new UpdateUserCommandValidator();
            var result = ValidateAndHandleErrors(model, validator);
            if (result.Status == ValidationStatus.Success)
            {
                await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);

                var status = await _mediator.Send(model);
                if (status)
                {
                    var tokenModel = JwtTokenGenerator.GenerateToken(_mapper.Map<CheckUserQueryResult>(model));

                    if (tokenModel != null)
                    {
                        JwtSecurityTokenHandler handler = new();
                        var token = handler.ReadJwtToken(tokenModel.Token);

                        var claims = token.Claims.ToList();

                        if (tokenModel.Token != null)
                            claims.Add(new Claim("accesToken", tokenModel.Token));

                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true,
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        TempData["alerts"] = Alert.ViewAlert(AlertType.Success, "Kullanıcı Bilgileri Güncellendi");

                        return RedirectToAction("Index", "Settings");
                    }
                    else
                    {
                        TempData["alerts"] = Alert.ViewAlert(AlertType.Success, "Kullanıcı Bilgileri Güncellendi");
                        return RedirectToAction("Login", "Auth");
                    }

                }
                TempData["alerts"] = Alert.ViewAlert(AlertType.Error, "Güncelleme Başarısız.Güvenlik İçin Çıkış Yapıldı");
                return RedirectToAction("Login", "Auth");
            }
            AddModelErrorsToModelState(ModelState, result);
            return View(model);
        }
        #endregion
    }
}

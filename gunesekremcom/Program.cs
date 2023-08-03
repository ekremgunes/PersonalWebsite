using AutoMapper;
using FluentValidation;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.Data.Context;
using gunesekremcom.Data.Iuow;
using gunesekremcom.Data.Uow;
using gunesekremcom.Data.Validations.UserValidations;
using gunesekremcom.Tools.DataSeed;
using gunesekremcom.Tools.EmailService;
using gunesekremcom.Tools.Helpers;
using gunesekremcom.Tools.Security;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//mediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddControllersWithViews();

//Database connection
builder.Services.AddDbContext<DatabaseContext>();

//_mapper
#region AutoMapper
var profiles = ProfileHelper.GetProfiles();
var configuration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(profiles);
});

var _mapper = configuration.CreateMapper();
builder.Services.AddSingleton(_mapper);
#endregion


//emailservice
builder.Services.AddScoped<IEmailService, EmailService>();

//jwt-cookie
#region JWT&COOKÝE
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Auth/Login";
        opt.LogoutPath = "/Auth/Logout";
        opt.AccessDeniedPath = "/Auth/AccessDenied";
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.Cookie.Name = "gunesekremcomjwt";
    });

#endregion

//fluent validations 
#region Validators
builder.Services.AddTransient<IValidator<CheckUserQuery>, LoginUserValidation>();
builder.Services.AddTransient<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();

#endregion


//hangfire for statisic
#region statistic hangfire

builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("Local"), new Hangfire.SqlServer.SqlServerStorageOptions
    {
        JobExpirationCheckInterval = TimeSpan.FromDays(7),
        DisableGlobalLocks = true
    });
});

builder.Services.AddHangfireServer();


#endregion


//Uow
builder.Services.AddScoped<IUow, Uow>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Error");
}
//app.UseHsts();
//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

#region Hangfire Midleware for Statistics
app.UseHangfireServer();
var Seed = new SeedStatisticData();
await Seed.Seed();

RecurringJob.AddOrUpdate(() => Seed.UpdateDates(), Cron.Daily, TimeZoneInfo.Local);

#endregion


MiddlewareExtensions.UseSecurityHeaders(app); //security middleware
app.UseStatusCodePagesWithReExecute("/Error/Error", "?code={0}"); // error status page

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "panel",
        pattern: "panel",
        defaults: new { controller = "Settings", action = "Index" }
    );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

});
app.Run();

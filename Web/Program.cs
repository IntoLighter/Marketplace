using System.Configuration;
using Domain;
using Infrastructure.Authentication;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Twilio;
using Microsoft.AspNetCore.Identity;
using Web.Areas.Identity.Pages.Account.Logic.VerifyCode.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IDbContext, AppDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddRazorPages();

builder.Services.Configure<TwilioVerificationCredentials>(options =>
{
    options.VerificationSId = builder.Configuration["TwilioVerificationSID"];
});

TwilioClient.Init(
    builder.Configuration["TwilioAccountSID"],
    builder.Configuration["TwilioAuthToken"]);

builder.Services
    .AddScoped<ISuccessCallbackContext, SuccessCallbackContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

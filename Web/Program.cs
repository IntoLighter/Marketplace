using System.Reflection;
using Application;
using Infrastructure;
using Infrastructure.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NuGet.Protocol;
using Twilio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddRazorPages();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers();
builder.Services.AddWebOptimizer();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    ContractResolver = new CamelCasePropertyNamesContractResolver()
};

builder.Services.Configure<TwilioVerificationCredentials>(options =>
{
    options.VerificationSId = builder.Configuration["TwilioVerificationSID"];
});

TwilioClient.Init(
    builder.Configuration["TwilioAccountSID"],
    builder.Configuration["TwilioAuthToken"]);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseWebOptimizer();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.Run();

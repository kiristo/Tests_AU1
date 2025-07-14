using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorFluentCMS;
using BlazorFluentCMS.Infrastructure;
using BlazorFluentCMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlazorFluentCMS;Trusted_Connection=True;MultipleActiveResultSets=true"));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = "YOUR_GOOGLE_CLIENT_ID";
        options.ClientSecret = "YOUR_GOOGLE_CLIENT_SECRET";
    })
    .AddFacebook(options =>
    {
        options.AppId = "YOUR_FACEBOOK_APP_ID";
        options.AppSecret = "YOUR_FACEBOOK_APP_SECRET";
    })
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = "YOUR_MICROSOFT_CLIENT_ID";
        options.ClientSecret = "YOUR_MICROSOFT_CLIENT_SECRET";
    });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

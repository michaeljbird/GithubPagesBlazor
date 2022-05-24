using GithubPagesBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;
using Microsoft.JSInterop;
using GithubPagesBlazor.Translation;
using Microsoft.Extensions.Localization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddSingleton<IStringLocalizerFactory, BlazorStringLocalizerFactory>();

var host = builder.Build();

CultureInfo culture;
IJSObjectReference? module;
var js = host.Services.GetRequiredService<IJSRuntime>();
module = await js.InvokeAsync<IJSObjectReference>("import", "./modules.js");

var result = await module.InvokeAsync<string>("getBlazorCulture");

if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("en-US");
    await module.InvokeVoidAsync("setBlazorCulture", "en-US");
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
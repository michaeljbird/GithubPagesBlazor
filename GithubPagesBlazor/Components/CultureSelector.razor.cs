using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace GithubPagesBlazor.Components
{
    public partial class CultureSelector
    {
        [Inject] IJSRuntime JSRuntime { get; set; }

        [Inject] NavigationManager Nav { get; set; }

        private IJSObjectReference? module;

        private CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    if (module is not null)
                    {
                        module.InvokeVoidAsync("setBlazorCulture", value.Name);
                    }

                    Nav.NavigateTo(Nav.Uri, forceLoad: true);
                }
            }
        }

        private CultureInfo[] supportedCultures = new[]
        {
            new CultureInfo("en-GB"),
            new CultureInfo("de-DE"),
            new CultureInfo("da-DK"),
        };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./modules.js");
            }
        }
    }
}

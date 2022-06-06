using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GithubPagesBlazor.Components
{
    public partial class ThemeSelector
    {
        [Parameter] public EventCallback<string> ApplyTheme { get; set; }
        [Inject] IJSRuntime JSRuntime { get; set; }

        private IJSObjectReference? module;
        private string _theme = "Light";
        private List<string> themeList = new List<string>() { "Light", "Dark" };

        private bool IsSelectedTheme(string theme)
        {
            return theme == _theme;
        }

        private async Task ChangeTheme(ChangeEventArgs args)
        {
            var selectedTheme = args.Value.ToString();
            await module.InvokeVoidAsync("setBlazorTheme", selectedTheme);
            _theme = selectedTheme;
            await ApplyTheme.InvokeAsync(_theme);
        }

        protected override async Task OnInitializedAsync()
        {
            module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/theme-module.js");
            var themeFromStorage = await module.InvokeAsync<string>("getBlazorTheme");

            if (!string.IsNullOrWhiteSpace(themeFromStorage))
            {
                _theme = themeFromStorage;
                await ApplyTheme.InvokeAsync(_theme);
            }
        }
    }
}

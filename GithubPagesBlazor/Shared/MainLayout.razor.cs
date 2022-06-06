using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GithubPagesBlazor.Shared
{
    public partial class MainLayout
    {
        private string _theme;

        private string ThemeClass
        {
            get { return _theme == "Light" ? string.Empty : "dark-mode"; }
        }

        void ApplyTheme(string theme)
        {
            _theme = theme;
        }

    }
}

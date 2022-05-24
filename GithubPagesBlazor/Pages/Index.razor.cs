using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace GithubPagesBlazor.Pages
{
    public partial class Index
    {

        [Inject] IStringLocalizerFactory _localizerFactory { get; set; }

        private IStringLocalizer _localizer => _localizerFactory.Create(typeof(Index));


        protected override async Task OnInitializedAsync()
        {

        }

    }
}

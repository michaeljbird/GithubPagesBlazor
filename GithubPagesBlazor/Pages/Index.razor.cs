using GithubPagesBlazor.Translation;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace GithubPagesBlazor.Pages
{
    public partial class Index
    {

        [Inject] IStringLocalizerFactoryFromCulture _localizerFactory { get; set; }

        private IStringLocalizer _localizer => _localizerFactory.Create();


        protected override async Task OnInitializedAsync()
        {

        }

    }
}

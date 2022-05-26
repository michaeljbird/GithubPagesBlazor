using Microsoft.Extensions.Localization;

namespace GithubPagesBlazor.Translation
{
    public interface IStringLocalizerFactoryFromCulture : IStringLocalizerFactory
    {
        IStringLocalizer Create();
    }
}

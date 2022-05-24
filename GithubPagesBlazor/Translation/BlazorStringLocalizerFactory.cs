using System;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace GithubPagesBlazor.Translation
{
    public class BlazorStringLocalizerFactory : IStringLocalizerFactory
    {
        private string ResourcesPath { get; }

        public BlazorStringLocalizerFactory(IOptions<LocalizationOptions> options)
        {
            ResourcesPath = options.Value.ResourcesPath;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            var resources = new EmbeddedFileProvider(resourceSource.Assembly);
            return new BlazorStringLocalizer(resources, ResourcesPath, resourceSource.Name);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            throw new NotImplementedException();
        }
    }
}

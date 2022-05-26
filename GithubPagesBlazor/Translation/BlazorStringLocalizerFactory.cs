using System;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Globalization;
using System.Reflection;

namespace GithubPagesBlazor.Translation
{
    public class BlazorStringLocalizerFactory : IStringLocalizerFactoryFromCulture
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
            var resources = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());

            return new BlazorStringLocalizer(resources, location, baseName);
        }

        public IStringLocalizer Create()
        {
            var cultureInfo = CultureInfo.CurrentUICulture;
            var cultureName = cultureInfo.TwoLetterISOLanguageName;
            var resources = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());

            return new BlazorStringLocalizer(resources, ResourcesPath, cultureName);
        }
    }
}

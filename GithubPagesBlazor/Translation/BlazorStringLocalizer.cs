using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Text.Json;

namespace GithubPagesBlazor.Translation
{
    public class BlazorStringLocalizer : IStringLocalizer
    {
        private IFileProvider FileProvider { get; }
        private string Name { get; }
        private string ResourcesPath { get; }

        public BlazorStringLocalizer(IFileProvider fileProvider, string resourcePath, string name)
        {
            FileProvider = fileProvider;
            Name = name;
            ResourcesPath = resourcePath;
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public LocalizedString this[string name]
        {
            get
            {
                var stringMap = LoadStringMap();

                return stringMap.ContainsKey(name) ? new LocalizedString(name, stringMap[name]) : new LocalizedString(name, name);

            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var stringMap = LoadStringMap();

                return new LocalizedString(name, string.Format(stringMap[name], arguments));
            }
        }

        private Dictionary<string, string> LoadStringMap()
        {
            var fileInfo = FileProvider.GetFileInfo(Path.Combine(ResourcesPath, $"{Name}.json"));

            using var stream = fileInfo.CreateReadStream();

            return JsonSerializer.DeserializeAsync<Dictionary<string, string>>(stream).Result;
        }
    }
}

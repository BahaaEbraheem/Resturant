using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Localization.Sources.Resource;
using Abp.Reflection.Extensions;
using Resturant.Localization.SourceFiles;

namespace Resturant.Localization
{
    public static class ResturantLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ResturantConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ResturantLocalizationConfigurer).GetAssembly(),
                        "Resturant.Localization.SourceFiles"
                    )
                )
            ); localizationConfiguration.Sources.Add(
              new ResourceFileLocalizationSource(
                  "Tokens",
                  Tokens.ResourceManager
                  )
          );

        }
    }
}

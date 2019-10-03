using System;
using System.Globalization;
using PluralizationService;
using PluralizationService.English;

namespace MongoDbProvider.Modules
{
    public static class Pluralizer
    {
        private static Lazy<IPluralizationApi> lazyPluralizer;
        private static readonly CultureInfo cultureInfo;
        
        private static IPluralizationApi pluralizer => lazyPluralizer.Value;
        
        /// <summary>
        /// Singleton creator of the Pluralization system
        /// </summary>
        static Pluralizer()
        {
            cultureInfo = new CultureInfo("en-US");

            lazyPluralizer = new Lazy<IPluralizationApi>(() => { 
                var builder = new PluralizationApiBuilder();
                builder.AddEnglishProvider();
                
                return builder.Build();
            });
        }
        
        /// <summary>
        /// Returns the plural version of the word, or the original word if the
        /// attempt returns null
        /// </summary>
        /// <param name="text">The word to pluralize</param>
        /// <returns>The plural version of the word</returns>
        public static string Pluralize(string text) =>
            pluralizer.Pluralize(text, cultureInfo) ?? text;
            
        /// <summary>
        /// The Singular word of the passed in plural value
        /// </summary>
        /// <param name="text">The word to singularize</param>
        /// <returns>The singular version of the word</returns>
        public static string Singularize(string text) =>
            pluralizer.Singularize(text, cultureInfo) ?? text;
    }
}
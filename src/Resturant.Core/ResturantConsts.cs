using Resturant.Debugging;

namespace Resturant
{
    public class ResturantConsts
    {
        public const string LocalizationSourceName = "Resturant";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "e4d90b7276d84f6a819590bba6a65388";
    }
}

namespace Core_BetterPenetration
{
    internal class Constants
    {
#if KK || KKS || EC
        public const string PluginVersion = "4.5.5.1";
#else
        public const string PluginVersion = "5.0.1.1";
#endif
    }
}
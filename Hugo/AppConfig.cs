using System;
using System.Configuration;


namespace Hugo
{
    public static class AppConfig
    {
        public static string? HugoRootDir { get; private set; }
        public static string? BlogRootDir { get; private set; }
        public static string? Port { get; private set; }
        public static string? ThemesDir { get; private set; }
        public static string? HugoRootDirNoPrefix { get; private set; }
        public static string? BlogRootDirNoPrefix { get; private set; }
        public static string? PortNoPrefix { get; private set; }
        public static string? ThemesDirNoPrefix { get; private set; }

        public static void Initialize()
        {
            HugoRootDirNoPrefix = ConfigurationManager.AppSettings["HugoRootDir"] ?? string.Empty;
            BlogRootDirNoPrefix = ConfigurationManager.AppSettings["BlogRootDir"] ?? string.Empty;
            PortNoPrefix = ConfigurationManager.AppSettings["Port"] ?? string.Empty;
            ThemesDirNoPrefix = ConfigurationManager.AppSettings["ThemesDir"] ?? string.Empty;

            HugoRootDir = AddPrefixIfNotEmpty(HugoRootDirNoPrefix, "-Path");
            BlogRootDir = AddPrefixIfNotEmpty(BlogRootDirNoPrefix, "--contentDir");
            Port = AddPrefixIfNotEmpty(PortNoPrefix, "--port");
            ThemesDir = AddPrefixIfNotEmpty(ThemesDirNoPrefix, "--themesDir");

        }

        static string AddPrefixIfNotEmpty(string input, string prefix)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            return $"{prefix} '{input}'";
        }
        
    }
}

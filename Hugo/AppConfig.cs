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

        public static void Initialize()
        {
            HugoRootDir = ConfigurationManager.AppSettings["HugoRootDir"] ?? string.Empty;
            BlogRootDir = ConfigurationManager.AppSettings["BlogRootDir"] ?? string.Empty;
            Port = ConfigurationManager.AppSettings["Port"] ?? string.Empty;
            ThemesDir = ConfigurationManager.AppSettings["ThemesDir"] ?? string.Empty;

            HugoRootDir = AddPrefixIfNotEmpty(HugoRootDir, "-Path");
            BlogRootDir = AddPrefixIfNotEmpty(BlogRootDir, "--contentDir");
            Port = AddPrefixIfNotEmpty(Port, "--port");
            ThemesDir = AddPrefixIfNotEmpty(ThemesDir, "--themesDir");

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

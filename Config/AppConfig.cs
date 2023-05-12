using System.Configuration;

namespace SelfServicePortal.Specs.Config
{
    public static class AppConfig
    {
        public static string BrowserType
        {
            get
            {
                var configFile = new ExeConfigurationFileMap { ExeConfigFilename = "C:\\Users\\frity\\source\\repos\\PlaywrightTests\\App.config" };
                var configuration = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
                var appSettings = configuration.AppSettings.Settings;
                //var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //var appSettings = configFile.AppSettings.Settings;
                if (appSettings["BrowserType"] == null)
                    throw new ConfigurationErrorsException("Missing BrowserType setting in App.config");
                return appSettings["BrowserType"].Value;
            }
        }
    }
}

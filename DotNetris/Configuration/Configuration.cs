namespace DotNetris.Configuration;

public static class Configuration
{
    public static string ConfigurationFile =
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/DotNetris/config";


    public static void Init()
    {
        if (!File.Exists(ConfigurationFile))
        {
            var parent = Directory.GetParent(ConfigurationFile);
            Directory.CreateDirectory(parent.FullName);
            File.Create(ConfigurationFile).Dispose();
        }
    }
}
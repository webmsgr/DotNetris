using System.Text.RegularExpressions;

namespace DotNetris.Configuration;

public class ConfigEntry
{

    private string _value;

    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            SaveToFile();
        }
    }

    public readonly string Key;
    
    public ConfigEntry(string key, string defaultValue)
    {
        Key = key;
        // oh boy!
        using (StreamReader f = File.OpenText(Configuration.ConfigurationFile))
        {
            string? line = f.ReadLine();
            while (line != null)
            {
                // something something key value
                var split = line.Split("|");
                var itemKey = split[0];
                var itemValue = (string?)split.GetValue(1) ?? string.Empty;
                if (Regex.Unescape(itemKey) == key)
                {
                    // we found it
                    _value = Regex.Unescape(itemValue);
                    return;
                }
                

                line = f.ReadLine();
            }
        }
        // we fall through
        _value = defaultValue;
        SaveToFile(); // write out the default value to the file
    }

    private void SaveToFile()
    {
        string FileContent = "";
        bool found = false;
        using (StreamReader f = File.OpenText(Configuration.ConfigurationFile))
        {
            
            string? line = f.ReadLine();
            while (line != null)
            {
                // something something key value
                if (line.Trim() == string.Empty || line.StartsWith('#'))
                {
                    line = f.ReadLine();
                    continue;
                }
                var split = line.Split("|");
                var itemKey = split[0];
                var itemValue = (string?)split.GetValue(1) ?? string.Empty;
                if (Regex.Unescape(itemKey) == Key)
                {
                    itemValue = Regex.Escape(_value);
                    found = true;
                }
                FileContent += itemKey + "|" + itemValue + "\n";
                line = f.ReadLine();
            }
        }

        if (!found)
        {
            FileContent += Regex.Escape(Key) + "|" + Regex.Escape(_value) + "\n"; 
        }
        File.WriteAllText(Configuration.ConfigurationFile, FileContent);
    }
}
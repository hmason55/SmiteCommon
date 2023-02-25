using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace SmiteCommon.Models.Api;

public class Configuration
{
    public const string ConfigurationPath = "Resources/configuration.json";
    public const bool DefaultWriteIndented = true;
    public const JsonIgnoreCondition DefaultIgnoreCondition = JsonIgnoreCondition.Never;

    public string Language { get; set; } = "1";
    public Session Session { get; set; } = new();

    public static JsonSerializerOptions JsonSerializerOptions { get; set; } = DefaultJsonSerializerOptions;

    public static JsonSerializerOptions DefaultJsonSerializerOptions => new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = DefaultWriteIndented,
        DefaultIgnoreCondition = DefaultIgnoreCondition
    };

    public static Configuration Load()
    {
        if (!File.Exists(ConfigurationPath))
        {
            Console.WriteLine($"Configuration file not found at: {ConfigurationPath}, using default.");
            return new();
        }

        try
        {
            string json = File.ReadAllText(ConfigurationPath);
            Configuration config = JsonSerializer.Deserialize<Configuration>(json, DefaultJsonSerializerOptions);
            Console.WriteLine($"Configuration loaded from: {ConfigurationPath}");
            return config;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine($"Using default configuration.");
        return new();
    }

    public bool Save()
    {
        try
        {
            File.WriteAllText(ConfigurationPath, JsonSerializer.Serialize(this, JsonSerializerOptions));
            Console.WriteLine($"Configuration saved to: {ConfigurationPath}");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return false;
    }
}

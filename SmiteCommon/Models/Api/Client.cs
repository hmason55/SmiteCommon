using System.Net;
using SmiteCommon.Models.Gods;
using SmiteCommon.Models.Items;
using SmiteCommon.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;
using SmiteCommon.Extensions;

namespace SmiteCommon.Models.Api;

public class Client : HttpClient
{
    public const string Endpoint = "https://api.smitegame.com/smiteapi.svc";
    public Developer Developer { get; set; }
    public Session Session { get; set; }
    public Configuration Configuration { get; set; }

    public Client(Developer developer, Session session = null) : base()
    {
        BaseAddress = new(Endpoint);
        Developer = developer;
        Session = session;
        DefaultRequestVersion = HttpVersion.Version30;
        DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower;
    }

    public new async Task<HttpResponseMessage> GetAsync(Uri uri)
    {
        try
        {
            return await base.GetAsync(uri);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return null;
    }

    public async Task<bool> CheckSession(Configuration configuration)
    {
        if (configuration.Session?.IsExpired() ?? true)
        {
            configuration.Session = await CreateSession();
            configuration.Save();
        }

        if (configuration.Session.Id.IsNullOrEmpty())
        {
            Console.WriteLine(configuration.Session.Result);
            return false;
        }

        Configuration = configuration;
        Session = configuration.Session;
        return true;
    }


    public async Task<Session> CreateSession()
    {
        Uri uri = ApiUtils.CreateSessionUri(Developer, Endpoint);

        Console.WriteLine($"CreateSession: {uri}");
        HttpResponseMessage response = await GetAsync(uri);

        if (response == null)
        {
            return new();
        }

        string content = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"CreateSession: {(int)response.StatusCode} {response.ReasonPhrase}");
        Console.WriteLine(content);

        return JsonSerializer.Deserialize<Session>(content, Configuration.DefaultJsonSerializerOptions);
    }

    public async Task<bool> TestSession()
    {
        Uri uri = ApiUtils.TestSessionUri(Developer, Session, Endpoint);

        Console.WriteLine($"TestSession: {uri}");
        HttpResponseMessage response = await GetAsync(uri);

        if (response == null)
        {
            return false;
        }

        string content = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"TestSession: {(int)response.StatusCode} {response.ReasonPhrase}");
        Console.WriteLine(content);

        if (content == null)
        {
            return false;
        }

        return content.Contains("This was a successful test");
    }


    public async Task<object> GetDataUsed()
    {
        Uri uri = ApiUtils.GetDataUsedUri(Developer, Session, Endpoint);

        Console.WriteLine($"GetDataUsed: {uri}");
        HttpResponseMessage response = await GetAsync(uri);

        if (response == null)
        {
            return new();
        }

        string content = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"GetDataUsed: {(int)response.StatusCode} {response.ReasonPhrase}");
        Console.WriteLine(content);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        return JsonSerializer.Deserialize<object>(content, Configuration.JsonSerializerOptions);
    }

    public async Task<List<God>> GetGods(string language)
    {
        Uri uri = ApiUtils.GetGodsUri(Developer, Session, Endpoint, language);

        Console.WriteLine($"GetGods: {uri}");
        HttpResponseMessage response = await GetAsync(uri);

        if(response == null)
        {
            return new();
        }

        string content = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"GetGods: {(int)response.StatusCode} {response.ReasonPhrase}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new();
        }

        return JsonSerializer.Deserialize<List<God>>(content, Configuration.JsonSerializerOptions);
    }

    public async Task<List<Item>> GetItems(string language)
    {
        Uri uri = ApiUtils.GetItemsUri(Developer, Session, Endpoint, language);

        Console.WriteLine($"GetItems: {uri}");
        HttpResponseMessage response = await GetAsync(uri);

        if (response == null)
        {
            return new();
        }

        string content = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"GetItems: {(int)response.StatusCode} {response.ReasonPhrase}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new();
        }

        List<Item> items = JsonSerializer.Deserialize<List<Item>>(content, Configuration.JsonSerializerOptions);

        foreach (Item item in items)
        {
            item.Parse();
        }

        return items;
    }
}

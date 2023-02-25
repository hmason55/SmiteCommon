using SmiteCommon.Extensions;
using SmiteCommon.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteCommon.Utils;

public class ApiUtils
{
    public const string DefaultLanguage = "1";
    public const string DefaultFormat = "Json";
    public static Uri BuildUri(string basePath, params string[] paths) => new($"{basePath}/{paths.Join("/")}");

    public static Uri CreateSessionUri(Developer developer, string endpoint, string format = DefaultFormat)
    {
        Signature signature = new(developer, Paths.CreateSession);
        return BuildUri
        (
            endpoint,
            $"{signature.Method}{format}",
            developer.Id,
            signature.Generate(),
            signature.Timestamp
        );
    }


    public static Uri TestSessionUri(Developer developer, Session session, string endpoint, string format = DefaultFormat)
    {
        Signature signature = new(developer, Paths.TestSession);
        return BuildUri
        (
            endpoint,
            $"{signature.Method}{format}",
            developer.Id,
            signature.Generate(),
            session.Id,
            signature.Timestamp
        );
    }

    public static Uri GetDataUsedUri(Developer developer, Session session, string endpoint, string format = DefaultFormat)
    {
        Signature signature = new(developer, Paths.GetDataUsed);
        return BuildUri
        (
            endpoint,
            $"{signature.Method}{format}",
            developer.Id,
            signature.Generate(),
            session.Id,
            signature.Timestamp
        );
    }

    public static Uri GetGodsUri(Developer developer, Session session, string endpoint, string language = DefaultLanguage, string format = DefaultFormat)
    {
        Signature signature = new(developer, Paths.GetGods);
        return BuildUri
        (
            endpoint,
            $"{signature.Method}{format}",
            developer.Id,
            signature.Generate(),
            session.Id,
            signature.Timestamp,
            language
        );
    }

    public static Uri GetItemsUri(Developer developer, Session session, string endpoint, string language = DefaultLanguage, string format = DefaultFormat)
    {
        Signature signature = new(developer, Paths.GetItems);
        return BuildUri
        (
            endpoint,
            $"{signature.Method}{format}",
            developer.Id,
            signature.Generate(),
            session.Id,
            signature.Timestamp,
            language
        );
    }
}

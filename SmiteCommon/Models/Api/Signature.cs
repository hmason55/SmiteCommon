using System.Security.Cryptography;
using System.Text;

namespace SmiteCommon.Models.Api;

public class Signature
{
    private Developer _dev;
    public string Method { get; set; }
    public string Timestamp { get; set; }
    
    public Signature(Developer dev, string method)
    {
        _dev = dev;
        Method = method;
        Timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
    }

    public string Generate()
    {
        byte[] bytes = MD5.HashData(Encoding.UTF8.GetBytes($"{_dev.Id}{Method}{_dev.AuthKey}{Timestamp}"));

        StringBuilder builder = new();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2").ToLower());
        }
        return builder.ToString();
    }
}

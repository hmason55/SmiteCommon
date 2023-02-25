using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteCommon.Models;

public class Stat
{
    public enum StatUsage
    {
        Offense,
        Defense,
        Utility
    }

    public bool IsInteger { get; set; }
    public string Name { get; set; }
    public float Value { get; set; }
    public StatUsage Usage { get; set; }

    public Stat(string name, float value, StatUsage usage)
    {
        Name = name;
        Value = value;
        Usage = usage;
    }

    public Stat(string name, int value, StatUsage usage)
    {
        Name = name;
        Value = value;
        Usage = usage;
        IsInteger = true;
    }
}

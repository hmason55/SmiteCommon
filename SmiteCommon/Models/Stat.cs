using SmiteCommon.Models.Items;
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
    public float Maximum { get; set; } = 1;
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

    public static List<Stat> GetItemStats(List<Item> items)
    {
        Dictionary<string, Stat> stats = new();
        foreach (Item item in items)
        {
            foreach (KeyValuePair<string, Stat> pair in item.GetStats())
            {
                if (stats.TryGetValue(pair.Key, out Stat stat))
                {
                    stat.Value += pair.Value.Value;
                }
                else
                {
                    stats.Add(pair.Key, pair.Value);
                }
            }
        }
        return stats.Values.Where(stat => stat.Value != 0).ToList();
    }
}

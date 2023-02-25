using System.Text.Json.Serialization;

namespace SmiteCommon.Models.Items;

public class Item
{
    public const int MAGIC_ACORN_ID = 18703;
    public const int KATANA_ID = 12671;
    public const int SHORT_BOW_ID = 10662;
    public const int PROTECTORS_MASK_ID = 23048;
    public const int FIGHTERS_MASK_ID = 16397;
    public const int MYSTICAL_EARRING_ID = 23147;
    public const int GLEAMING_EAR_CUFFS_ID = 23148;
    public const int WARDING_SIGIL_ID = 19751;
    public const int MANIKIN_HIDDEN_BLADE_ID = 19641;
    public const int DEATHS_TEMPER_ID = 19587;
    public const int BLUESTONE_BROOCH_ID = 23859;
    public const int SANDS_OF_TIME_ID = 14090;
    public const int VAMPIRIC_SHROUD_ID = 19511;
    public const int CONDUIT_GEM_ID = 19677;

    // Metadata

    [JsonPropertyName("DeviceName")]
    public string Name { get; set; }

    public string ActiveFlag { get; set; }
    public int ChildItemId { get; set; }
    public int IconId { get; set; }
    [JsonPropertyName("itemIcon_URL")]
    public string IconUrl { get; set; }
    public ItemDescription ItemDescription { get; set; }
    public int ItemId { get; set; }
    public int ItemTier { get; set; }
    public int Price { get; set; }
    public string RestrictedRoles { get; set; }
    public int RootItemId { get; set; }
    public string ShortDesc { get; set; }
    public bool StartingItem { get; set; }
    public string Type { get; set; }


    // Stats

    public float AttackSpeed { get; set; }
    public float CooldownReduction { get; set; }
    public float CriticalStrikeChance { get; set; }
    public float CrowdControlReduction { get; set; }
    public int Health { get; set; }
    public int HP5 { get; set; }
    public float MagicalLifesteal { get; set; }
    public int MagicalPenetration { get; set; }
    public float MagicalPenetrationPercent { get; set; }
    public int MagicalPower { get; set; }
    public int MagicalProtection { get; set; }
    public int Mana { get; set; }
    public float MovementSpeed { get; set; }
    public int MP5 { get; set; }
    public float PhysicalLifesteal { get; set; }
    public int PhysicalPenetration { get; set; }
    public float PhysicalPenetrationPercent { get; set; }
    public int PhysicalPower { get; set; }
    public int PhysicalProtection { get; set; }


    public Dictionary<string, Stat> GetStats()
    {
        return new()
        {
            {
                nameof(MagicalPower),
                new("Magical Power", MagicalPower, Stat.StatUsage.Offense)
            },
            {
                nameof(MagicalPenetration),
                new("Magical Penetration", MagicalPenetration, Stat.StatUsage.Offense)
            },
            {
                nameof(MagicalPenetrationPercent),
                new("Magical Penetration Percent", MagicalPenetrationPercent, Stat.StatUsage.Offense)
            },
            {
                nameof(MagicalLifesteal),
                new("Magical Lifesteal", MagicalLifesteal, Stat.StatUsage.Offense)
            },
            {
                nameof(PhysicalPower),
                new("Physical Power", PhysicalPower, Stat.StatUsage.Offense)
            },
            {
                nameof(PhysicalPenetration),
                new("Movement Speed", PhysicalPenetration, Stat.StatUsage.Offense)
            },
            {
                nameof(PhysicalPenetrationPercent),
                new("Physical Penetration Percent", PhysicalPenetrationPercent, Stat.StatUsage.Offense)
            },
            {
                nameof(PhysicalLifesteal),
                new("Physical Lifesteal", PhysicalLifesteal, Stat.StatUsage.Offense)
            },
            {
                nameof(AttackSpeed),
                new("Attack Speed", AttackSpeed, Stat.StatUsage.Offense)
            },
            {
                nameof(CriticalStrikeChance),
                new("Critical Strike Chance", CriticalStrikeChance, Stat.StatUsage.Offense)
            },
            {
                nameof(MagicalProtection),
                new("Magical Protection", MagicalProtection, Stat.StatUsage.Defense)
            },
            {
                nameof(PhysicalProtection),
                new("Physical Protection", PhysicalProtection, Stat.StatUsage.Defense)
            },
            {
                nameof(Health),
                new("Health", Health, Stat.StatUsage.Defense)
            },
            {
                nameof(HP5),
                new("HP5", HP5, Stat.StatUsage.Defense)
            },
            {
                nameof(CrowdControlReduction),
                new("Crowd Control Reduction", CrowdControlReduction, Stat.StatUsage.Defense)
            },
            {
                nameof(CooldownReduction),
                new("Cooldown Reduction", CooldownReduction, Stat.StatUsage.Utility)
            },
            {
                nameof(MovementSpeed),
                new("Movement Speed", MovementSpeed, Stat.StatUsage.Utility)
            },
            {
                nameof(Mana),
                new("Mana", Mana, Stat.StatUsage.Utility)
            },
            {
                nameof(MP5),
                new("MP5", MP5, Stat.StatUsage.Utility)
            }
        };
    }

    public bool IsPhysicalOnly => !(StartingItem || RootItemId == MYSTICAL_EARRING_ID) && PhysicalPower > 0;
    public bool IsMagicalOnly => !(StartingItem || RootItemId == MYSTICAL_EARRING_ID) && MagicalPower > 0;

    public bool ActivelyStacks => ItemTier == 4 && Type == "Item" && Price == 1;
    public bool IsEvolved => ItemTier == 4 && Type == "Item" && Price <= 1;
    public bool IsGlyph => ItemTier == 4 && Type == "Item" && Price > 1;

    public override string ToString() => Name;


    public void BindFloatValue(string name, string value)
    {
        float valueAsFloat = ParsePercentAsFloat(value);

        switch (name)
        {
            case "AttackSpeed":
                AttackSpeed = valueAsFloat;
                return;

            case "CooldownReduction":
                CooldownReduction = valueAsFloat;
                return;

            case "CriticalStrikeChance":
                CriticalStrikeChance = valueAsFloat;
                return;

            case "CrowdControlReduction":
                CrowdControlReduction = valueAsFloat;
                return;

            case "MagicalLifesteal":
                MagicalLifesteal = valueAsFloat;
                return;

            case "MagicalPenetrationPercent":
                MagicalPenetrationPercent = valueAsFloat;
                return;

            case "MovementSpeed":
                MovementSpeed = valueAsFloat;
                return;

            case "PhysicalLifesteal":
                PhysicalLifesteal = valueAsFloat;
                return;

            case "PhysicalPenetrationPercent":
                PhysicalPenetrationPercent = valueAsFloat;
                return;

            default:
                break;
        }
    }

    public void BindIntValue(string name, string value)
    {
        int valueAsInt = int.Parse(value);

        switch (name)
        {
            case "Health":
                Health = valueAsInt;
                return;

            case "HP5":
                HP5 = valueAsInt;
                return;

            case "MagicalPower":
                MagicalPower = valueAsInt;
                return;

            case "MagicalPenetration":
                MagicalPenetration = valueAsInt;
                return;

            case "MagicalProtection":
                MagicalProtection = valueAsInt;
                return;

            case "Mana":
                Mana = valueAsInt;
                return;

            case "MP5":
                MP5 = valueAsInt;
                return;

            case "PhysicalPenetration":
                PhysicalPenetration = valueAsInt;
                return;

            case "PhysicalPower":
                PhysicalPower = valueAsInt;
                return;

            case "PhysicalProtection":
                PhysicalProtection = valueAsInt;
                return;

            default:
                break;
        }
    }

    public static string ConvertName(string value)
    {
        return value switch
        {
            "MagicalPenetration" => "MagicalPenetrationPercent",
            "PhysicalPenetration" => "PhysicalPenetrationPercent",
            _ => value,
        };
    }

    public static string NormalizeName(string value) => value.Replace(" ", "").Trim();

    public static string NormalizeValue(string value) => value.Replace("+", "").Trim();

    public void Parse()
    {
        foreach (MenuItem stat in ItemDescription.MenuItems)
        {
            string name = stat.Description;
            string value = stat.Value;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value)) continue;

            name = NormalizeName(name);
            value = NormalizeValue(value);

            if (value.Contains('%'))
            {
                BindFloatValue(ConvertName(name), value);
            }
            else
            {
                BindIntValue(name, value);
            }
        }
    }

    public static float ParsePercentAsFloat(string value)
    {
        value = value.Replace("%", "");
        return MathF.Round(float.Parse(value) * 0.01f, 2);
    }

}
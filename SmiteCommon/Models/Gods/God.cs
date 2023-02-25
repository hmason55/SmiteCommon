using System.Text.Json.Serialization;
using SmiteCommon.Models.Gods.Abilities;
using SmiteCommon.Models.Items;

namespace SmiteCommon.Models.Gods;

public class God
{
    public const int RATATOSKR_ID = 2063;

    public string Ability1 { get; set; }
    public string Ability2 { get; set; }
    public string Ability3 { get; set; }
    public string Ability4 { get; set; }
    public string Ability5 { get; set; }
    public int AbilityId1 { get; set; }
    public int AbilityId2 { get; set; }
    public int AbilityId3 { get; set; }
    public int AbilityId4 { get; set; }
    public int AbilityId5 { get; set; }
    public Ability Ability_1 { get; set; }
    public Ability Ability_2 { get; set; }
    public Ability Ability_3 { get; set; }
    public Ability Ability_4 { get; set; }
    public Ability Ability_5 { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackSpeedPerLevel { get; set; }
    public string AutoBanned { get; set; }
    public string Cons { get; set; }
    public int Health { get; set; }
    public float HealthPerFive { get; set; }
    public int HealthPerLevel { get; set; }
    public float HP5PerLevel { get; set; }

    [JsonPropertyName("godIcon_URL")]
    public string IconUrl { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; } = -1;
    public string Lore { get; set; }
    public int MagicalPower { get; set; }
    public float MagicalPowerPerLevel { get; set; }

    [JsonPropertyName("MagicProtection")]
    public float MagicalProtection { get; set; }

    [JsonPropertyName("MagicProtectionPerLevel")]
    public float MagicalProtectionPerLevel { get; set; }

    public int Mana { get; set; }
    public float ManaPerFive { get; set; }
    public int ManaPerLevel { get; set; }
    public float MP5PerLevel { get; set; }
    public string Name { get; set; }
    public string OnFreeRotation { get; set; }
    public string Pantheon { get; set; }
    public int PhysicalPower { get; set; }
    public float PhysicalPowerPerLevel { get; set; }
    public float PhysicalProtection { get; set; }
    public float PhysicalProtectionPerLevel { get; set; }
    public string Pros { get; set; }
    public string Roles { get; set; }
    public int Speed { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }

    [JsonPropertyName("basicAttack")]
    public Abilities.ItemDescription BasicAttack { get; set; }

    [JsonPropertyName("godAbility1_URL")]
    public string GodAbility1Url { get; set; }

    [JsonPropertyName("godAbility2_URL")]
    public string GodAbility2Url { get; set; }

    [JsonPropertyName("godAbility3_URL")]
    public string GodAbility3Url { get; set; }

    [JsonPropertyName("godAbility4_URL")]
    public string GodAbility4Url { get; set; }

    [JsonPropertyName("godAbility5_URL")]
    public string GodAbility5Url { get; set; }

    [JsonPropertyName("godCard_URL")]
    public string GodCardUrl { get; set; }

    [JsonPropertyName("latestGod")]
    public string LatestGod { get; set; }

    public bool IsAssassin => Roles is "Assassin";
    public bool IsGuardian => Roles is "Guardian";
    public bool IsHunter => Roles is "Hunter";
    public bool IsMage => Roles is "Mage";
    public bool IsWarrior => Roles is "Warrior";
    public bool IsMagical => Roles is "Guardian" or "Mage";
    public bool IsPhysical => !IsMagical;
    public bool IsRatatoskr => Id == RATATOSKR_ID;

    public bool CanPurchaseItem(Item item)
    {
        // Omit based root items.
        switch (item.RootItemId)
        {
            case Item.WARDING_SIGIL_ID when IsMagical:
                return false;

            case Item.KATANA_ID when !(IsWarrior || IsAssassin):
                return false;

            case Item.MAGIC_ACORN_ID when !IsRatatoskr:
                return false;

            case Item.SHORT_BOW_ID when !IsHunter:
                return false;

            case Item.PROTECTORS_MASK_ID when IsWarrior || IsGuardian:
                return false;

            case Item.FIGHTERS_MASK_ID when !(IsWarrior || IsGuardian):
                return false;

            case Item.VAMPIRIC_SHROUD_ID when IsPhysical:
                return false;

            case Item.SANDS_OF_TIME_ID when IsPhysical:
                return false;

            case Item.CONDUIT_GEM_ID when IsPhysical:
                return false;
        }

        // Omit based on child items.
        switch (item.ChildItemId)
        {
            // Griffonwing earrings
            case Item.GLEAMING_EAR_CUFFS_ID when !(IsHunter || IsMage):
                return false;
        }

        // Omit based on items.
        switch (item.ItemId)
        {
            case Item.GLEAMING_EAR_CUFFS_ID when !(IsHunter || IsMage):
                return false;

            case Item.MANIKIN_HIDDEN_BLADE_ID when IsMagical:
                return false;

            case Item.DEATHS_TEMPER_ID when IsMagical:
                return false;

            case Item.BLUESTONE_BROOCH_ID when IsMagical:
                return false;
        }

        // Power-restricted items.
        if (IsMagical && item.IsPhysicalOnly || IsPhysical && item.IsMagicalOnly)
        {
            return false;
        }

        return true;
    }
}
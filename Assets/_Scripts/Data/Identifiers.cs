public enum AbilityID : int
{
    Strength = 0,
    Dexterity = 1,
    Constitution = 2,
    Intelligence = 3,
    Wisdom = 4,
    Charisma = 5
}

public enum DefenceID : int
{
    ArmorClass = 0,
    Fortitude = 1,
    Reflex = 2,
    Will = 3
}

public enum RaceID : int
{
    Human = 0,
    Dwarf = 1, 
    Elf = 2,
    Dragonborn = 3,
    Eladrin = 4,
    HalfElf = 5,
    Halfling = 6,
    Tiefling = 7
}

public enum KeywordID : int
{
    NONE = 0,

    MARTIAL = 1,
    ARCANE = 2,
    DIVINE = 3,

    WEAPON = 5,
    IMPLEMENT = 6,
    ACCESORY = 7,

    ACID = 10,
    COLD = 11, 
    FIRE = 12, 
    FORCE = 13,
    LIGHTNING = 14,
    NECROTIC = 15,
    POISON = 16,
    PSYCHIC = 17,
    RADIANT = 18,
    THUNDER = 19,

    CHARM = 20,
    CONJURATION = 21,
    FEAR = 22,
    HEALING = 23,
    ILLUSION = 24,
    POLYMORPH = 25,
    RELIABLE = 26,
    SLEEP = 27,
    STANCE = 28,
    TELEPORTATION = 29,
    ZONE = 30,
}

public enum AttTypeID : int
{
    NONE = 0,
    MELEE = 1,      // Range 1
    RANGED = 2,     // Range X
    AREA = 3,       // AoE, hits all enemies, if multiple
    CLOSE = 4       // NOT USED, USE AREA
}

public enum SkillID : int
{
    // 0 is reserved for Perception and 1 for Insight, both are WIS based
    Perception = 0,
    Insight = 1,

    //STR
    Athletics = 2,
    //DEX
    Acrobatics = 3,
    Stealth = 4,
    Thievery = 5,
    //CON
    Endurance = 6,
    //INT
    Arcana = 7,
    History = 8,
    Religion = 9,
    //WIS
    Dungeoneering = 10,
    Heal = 11,
    Nature = 12,
    //CHA
    Bluff = 13,
    Diplomacy = 14,
    Intimidate = 15,
    Streetwise = 16
}

public enum SkillCheckType : int
{
    AUTOFAIL = -1,
    AUTOSUCCESS = 0,
    ABILITYCHECK = 1,
    SKILLCHECK = 2
}

public enum ChallengeType : int
{
    NONE = -1,
    DC = 0,
    NPCSKILL = 1,
    NPCDEFENCE = 2
}

public enum ResultType : int
{
    ENDENCOUNTER = -1,
    NEXTENCOUNTER = 0,
    MESSAGE = 1,
    EXPERIENCE = 2,
    GOLD = 3,
    DAMAGE = 4,
    HEAL = 5
}
public enum AbilityID : int		// If "skillCheck" is "1", these are used as "skillCheckID" (skill used by the player)
{
    Strength = 0,
    Dexterity = 1,
    Constitution = 2,
    Intelligence = 3,
    Wisdom = 4,
    Charisma = 5
}

public enum DefenceID : int		// If "challenge" is "2", these are used as "skillCheckTargetID" (skill used by the opponent)
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

public enum SkillID : int	// If "skillCheck" is "2", these are used as "skillCheckID" (skill used by the player) and if "challenge" is "1", these are used as "skillCheckTargetID" (skill used by the opponent)
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

public enum SkillCheckType : int  // These are all different types of skill checks. Used as "skillCheck" value
{
    AUTOFAIL = -1,		// No shit
    AUTOSUCCESS = 0,	// No shit
    ABILITYCHECK = 1,	// Use an abilityscore for a check
    SKILLCHECK = 2		// Use a skillbonus for a check
}

public enum ChallengeType : int   // Used as "challenge" value
{
    NONE = -1,			// On Autofail or -success use this as a challengeType
    DC = 0,				// If you use DC, you can decide the Difficulty Check yourself
    NPCSKILL = 1,		// Use the opposing NPC's skill (SkillID) for a DC check
    NPCDEFENCE = 2		// Use the opposing NPC's defence (DefenceID) for a DC check
}

public enum ResultType : int      // Used as "ResultID" value
{
    COMBATENCOUNTER = -2,	// Starts a combat encounter! Uses separate JSON template for combat rewards (maybe? i don't know)
    ENDENCOUNTER = -1,	    // Ends encounter group (Value: 0)
    NEXTENCOUNTER = 0,	    // Next encounter will be a specific encounter (Value: Encounter ID)

    // You should have either -1 or 0 as a part of results

    MESSAGE = 1,		    // Show an additional message before next encounter
    EXPERIENCE = 2,		    // Modify the PC experience (Value: Positive or negative integer, stands for experience amount)
    GOLD = 3,			    // Modify the PC gold amount (Value: Positive or negative integer, stands for gold amount)
    DAMAGE = 4,			    // Modify the PC health (Value: Positive integer, stands for amount of damage)
    HEAL = 5			    // Modify the PC health (Value: Positive integer, stands for healed HP amount)
}
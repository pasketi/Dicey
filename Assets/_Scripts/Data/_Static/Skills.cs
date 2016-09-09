using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skills : MonoBehaviour {
    
    public static Dictionary<SkillID, AbilityID> skillDict = new Dictionary<SkillID, AbilityID>() {

        { SkillID.Athletics, AbilityID.Strength },

        { SkillID.Acrobatics, AbilityID.Dexterity },
        { SkillID.Stealth, AbilityID.Dexterity },
        { SkillID.Thievery, AbilityID.Dexterity },

        { SkillID.Endurance, AbilityID.Constitution },

        { SkillID.Arcana, AbilityID.Intelligence },
        { SkillID.History, AbilityID.Intelligence },
        { SkillID.Religion, AbilityID.Intelligence },

        { SkillID.Dungeoneering, AbilityID.Wisdom },
        { SkillID.Heal, AbilityID.Wisdom },
        { SkillID.Insight, AbilityID.Wisdom },
        { SkillID.Nature, AbilityID.Wisdom },
        { SkillID.Perception, AbilityID.Wisdom },

        { SkillID.Bluff, AbilityID.Charisma },
        { SkillID.Diplomacy, AbilityID.Charisma },
        { SkillID.Intimidate, AbilityID.Charisma },
        { SkillID.Streetwise, AbilityID.Charisma }

    };

}

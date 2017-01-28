using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCharacter : MonoBehaviour {

    public string _characterName = "John Doe";
    public RaceID _characterRace = RaceID.Human;

    [SerializeField]
    protected int _level = 1;
    [SerializeField]
    protected int[] _abilityScores = new int[6];
    [SerializeField]
    protected int[] _defences = new int[4];
    [SerializeField]
    protected bool[] _trainedSkills = new bool[17];
    [SerializeField]
    protected int _maxHealth = 0;
    [SerializeField]
    protected int _experience = 0;                    // On player stands for experience gathered. On NPC, stands for XP gain

    protected int _currentHealth = 0;

    protected virtual void Init ()
    {
        //Ability scores
        CreateCharacter(_characterRace);
    }

    void Awake ()
    {
        Init();
    }

    public virtual void CreateCharacter(RaceID race)
    {
        UpdateDefence(DefenceID.ArmorClass);
        UpdateDefence(DefenceID.Fortitude);
        UpdateDefence(DefenceID.Reflex);
        UpdateDefence(DefenceID.Will);
        UpdateMaxHealth();
        _currentHealth = _maxHealth;

        return;
    }

    public int GetCurrentHealth ()
    {
        return _currentHealth;
    }

    public int GetMaxHealth ()
    {
        return _maxHealth;
    }

    protected void UpdateDefence(DefenceID defence)
    {
        // Base Defence
        _defences[(int)defence] = 10;
        // Add half a level
        _defences[(int)defence] += GetHalfLevel();

        switch (defence)
        {
            case DefenceID.ArmorClass:
                

                break;

            case DefenceID.Fortitude:
                // Add higher of SRT/CON
                _defences[(int)defence] += GetAbilityScore(AbilityID.Strength) > GetAbilityScore(AbilityID.Constitution) ? GetModifier(AbilityID.Strength) : GetModifier(AbilityID.Constitution);
                break;

            case DefenceID.Reflex:
                // Add higher of DEX/INT
                _defences[(int)defence] += GetAbilityScore(AbilityID.Dexterity) > GetAbilityScore(AbilityID.Intelligence) ? GetModifier(AbilityID.Dexterity) : GetModifier(AbilityID.Intelligence);
                break;

            case DefenceID.Will:
                // Add higher of WIS/CHA
                _defences[(int)defence] += GetAbilityScore(AbilityID.Wisdom) > GetAbilityScore(AbilityID.Charisma) ? GetModifier(AbilityID.Wisdom) : GetModifier(AbilityID.Charisma);
                break;
        }
    }

    private void UpdateMaxHealth ()
    {
        _maxHealth = 15 + (_level * 5) + _abilityScores[(int)AbilityID.Constitution];
    }

    public int GetDefence (DefenceID defence)
    {
        UpdateDefence(defence);
        return _defences[(int)defence];
    }

    protected void SetAbilityScore(AbilityID attribute, int value)
    {
        _abilityScores[(int)attribute] = value;
    }

    public int GetAbilityScore(AbilityID ability)
    {
        return _abilityScores[(int)ability];
    }

    public int GetModifier(AbilityID ability)
    {
        float total;

        if (GetAbilityScore(ability) % 2 != 0)
        {
            total = ((GetAbilityScore(ability) - 1f) / 2) - 5;
        }
        else
        {
            total = (GetAbilityScore(ability) / 2) - 5;
        }

        return (int)total;
    }


    public int GetSkill(SkillID skill)
    {
        return GetHalfLevel() + (GetTrainedSkill(skill) ? 5 : 0) + GetModifier(Skills.skillDict[skill]);
    }

    public int GetHalfLevel ()
    {
        return _level % 2 == 0 ? ( _level / 2 ) : ( ( _level - 1 ) / 2 );
    }

    public bool GetTrainedSkill (SkillID skill)
    {
        return _trainedSkills[(int)skill];
    }
}

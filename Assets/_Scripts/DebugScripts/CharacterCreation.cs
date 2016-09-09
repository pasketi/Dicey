using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterCreation : MonoBehaviour {

    public BaseCharacter character;
    public Text 
        tSTR, 
        tDEX, 
        tCON, 
        tINT, 
        tWIS, 
        tCHA;
    public Text 
        tATH, 
        tACR, 
        tSTE, 
        tTHI, 
        tEND, 
        tARC,
        tHIS, 
        tREL, 
        tDUN, 
        tHEA, 
        tINS, 
        tNAT, 
        tPER, 
        tBLU, 
        tDIP, 
        tINTI, 
        tSTRE;
    public Text
        tAC,
        tFO,
        tRE,
        tWI;
    public Text cName, race, HP;
    private int 
        ATH, 
        ACR, 
        STE, 
        THI, 
        END, 
        ARC, 
        HIS, 
        REL, 
        DUN, 
        HEA, 
        INS, 
        NAT, 
        PER, 
        BLU, 
        DIP, 
        INTI,
        STRE;
    private int STR, DEX, CON, INT, WIS, CHA;

	// Use this for initialization
	void Start () {
        cName.text = character._characterName;
        race.text = character._characterRace.ToString();
        HP.text = "" + character.GetCurrentHealth() + " / " + character.GetMaxHealth();

        STR = character.GetAbilityScore(AbilityID.Strength);
        DEX = character.GetAbilityScore(AbilityID.Dexterity);
        CON = character.GetAbilityScore(AbilityID.Constitution);
        INT = character.GetAbilityScore(AbilityID.Intelligence);
        WIS = character.GetAbilityScore(AbilityID.Wisdom);
        CHA = character.GetAbilityScore(AbilityID.Charisma);

        ATH = character.GetSkill(SkillID.Athletics);
        ACR = character.GetSkill(SkillID.Acrobatics);
        STE = character.GetSkill(SkillID.Stealth);
        THI = character.GetSkill(SkillID.Thievery);
        END = character.GetSkill(SkillID.Endurance);
        ARC = character.GetSkill(SkillID.Arcana);
        HIS = character.GetSkill(SkillID.History);
        REL = character.GetSkill(SkillID.Religion);
        DUN = character.GetSkill(SkillID.Dungeoneering);
        HEA = character.GetSkill(SkillID.Heal);
        INS = character.GetSkill(SkillID.Insight);
        NAT = character.GetSkill(SkillID.Nature);
        PER = character.GetSkill(SkillID.Perception);
        BLU = character.GetSkill(SkillID.Bluff);
        DIP = character.GetSkill(SkillID.Diplomacy);
        INTI = character.GetSkill(SkillID.Intimidate);
        STRE = character.GetSkill(SkillID.Streetwise);

        tSTR.text = STR + "  +" + character.GetModifier(AbilityID.Strength);
        tDEX.text = DEX + "  +" + character.GetModifier(AbilityID.Dexterity);
        tCON.text = CON + "  +" + character.GetModifier(AbilityID.Constitution);
        tINT.text = INT + "  +" + character.GetModifier(AbilityID.Intelligence);
        tWIS.text = WIS + "  +" + character.GetModifier(AbilityID.Wisdom);
        tCHA.text = CHA + "  +" + character.GetModifier(AbilityID.Charisma);

        tAC.text = character.GetDefence(DefenceID.ArmorClass).ToString();
        tFO.text = character.GetDefence(DefenceID.Fortitude).ToString();
        tRE.text = character.GetDefence(DefenceID.Reflex).ToString();
        tWI.text = character.GetDefence(DefenceID.Will).ToString();

        tATH.text = ATH.ToString();
        tACR.text = ACR.ToString();
        tSTE.text = STE.ToString();
        tTHI.text = THI.ToString();
        tEND.text = END.ToString();
        tARC.text = ARC.ToString();
        tHIS.text = HIS.ToString();
        tREL.text = REL.ToString();
        tDUN.text = DUN.ToString();
        tHEA.text = HEA.ToString();
        tINS.text = INS.ToString();
        tNAT.text = NAT.ToString();
        tPER.text = PER.ToString();
        tBLU.text = BLU.ToString();
        tDIP.text = DIP.ToString();
        tINTI.text = INTI.ToString();
        tSTRE.text = STRE.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

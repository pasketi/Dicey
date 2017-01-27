using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class EncounterController : MonoBehaviour {

    // Pseudo
    // Check if NPC is different than current NPC
    //     then change NPC sprite (Animation drag out and drag back in after changing sprite) and NPC stats (if any)
    // Change intro text
    // Set Action texts
    // Set Opponent

    public Text StoryText;
    public BoxCollider2D StoryCollider;
    public List<BaseAction> actions;
    public int CurrentEncounter;

    void Awake ()
    {
    }

    public bool InitEncounter(int encounterID, bool showIntroText = true)
    {
        CurrentEncounter = encounterID;
        SetActions();
        if (showIntroText)
            ShowMessage(GameManager.Instance.data.json.GetEncounter(CurrentEncounter).introText);
        return true;
    }

    public void showActions ()
    {
        HideMessage();
        GameManager.Instance.gameState = GameManager.State.choise;
        foreach (BaseAction action in actions)
        {
            action.cardAnimator.SetBool("Show", true);
            action.cardAnimator.SetBool("Hide", false);

        }
    }

    public void hideActions ()
    {
        foreach (BaseAction action in actions)
        {
            action.cardAnimator.SetBool("Show", false);
            action.cardAnimator.SetBool("Hide", true);
        }
    }

    public void ShowMessage(string message)
    {
        StoryText.text = message;
        StoryText.enabled = true;
        StoryCollider.enabled = true;
    }

    public void HideMessage ()
    {
        StoryText.text = "";
        StoryText.enabled = false;
        StoryCollider.enabled = false;
    }

    public void SetActions()
    {
        for (int i = 0; i < 3; i++)
        {
            actions[i].SetAction(GameManager.Instance.data.json.GetEncounterActions(CurrentEncounter)[i]);
        }
    }

    public void useAction(int actionID)
    {
        ActionData action;
        action = GameManager.Instance.data.json.GetEncounterActions(CurrentEncounter)[actionID];
        string dice = "";
        int target = 0;
        int result = 0;
        hideActions();
        int dieRoll = 0;
        switch (action.skillCheckType)
        {
            case SkillCheckType.AUTOSUCCESS:
                result = 1;
                break;
            case SkillCheckType.AUTOFAIL:
                result = -1;
                break;
            case SkillCheckType.ABILITYCHECK:
                dice = "1D20+" + GameManager.Instance.player.GetModifier((AbilityID)action.skillCheckID).ToString();
                break;
            case SkillCheckType.SKILLCHECK:
                dice = "1D20+" + GameManager.Instance.player.GetSkill((SkillID)action.skillCheckID).ToString();
                break;
            default:
                Debug.LogError("BAD HAPPEN IN SKILLCHECK SWITCH");
                break;
        }
        if (result == 0)
        {
            switch (action.challengeType)
            {
                case ChallengeType.NONE:
                    break;
                case ChallengeType.DC:
                    target = action.challengeTargetID;
                    break;
                case ChallengeType.NPCDEFENCE:
                    target = GameManager.Instance.NPC.GetDefence((DefenceID)action.challengeTargetID);
                    break;
                case ChallengeType.NPCSKILL:
                    target = GameManager.Instance.NPC.GetSkill((SkillID)action.challengeTargetID);
                    break;
                default:
                    Debug.LogError("BAD HAPPEN IN CHALLENGE SWITCH");
                    break;
            }
            dieRoll = Dice.Roll(dice);
            Debug.Log("Dieroll: " + dieRoll);
            result = (dieRoll >= target ? 1 : -1);
        }

        switch (result)
        {
            case 1:
                parseResult(action.Success);
                Debug.Log("Action #" + action.ID + " - Success");
                //Debug.Log("DEGUB: " + dice + " " + dieRoll + " > " + target + " " + action.skillCheckType.ToString() + " " + action.challengeType.ToString() + " " + result);
                break;
            case -1:
                parseResult(action.Failure);
                Debug.Log("Action #" + action.ID + " - Failure");
                //Debug.Log("DEGUB: " + dice + " " + dieRoll + " < " + target + " " + action.skillCheckType.ToString() + " " + action.challengeType.ToString() + " " + result);
                break;
            default:
                Debug.LogError("BAD HAPPEN IN RESULT SWITCH");
                break;
        }
    }

    public void parseResult(List<ActionResultData> results)
    {
        int nextEncounter = -2;
        bool msgShown = false;
        foreach (ActionResultData result in results)
        {
            Debug.Log("ResultID: " + result.resultID + " -- Value: " + result.resultValue);
            switch (result.resultID)
            {
                case -1:
                    Debug.Log("End Encounter");
                    nextEncounter = -1;
                    break;
                case 0:
                    nextEncounter = int.Parse(result.resultValue);
                    Debug.Log("Next Encounter: " + nextEncounter);
                    break;
                case 1:
                    ShowMessage(result.resultValue);
                    msgShown = true;
                    break;
                case 2:
                    // GIVE XP
                    Debug.Log("Kotl, giff XP");
                    break;
                case 3:
                    // GIVE GOLD
                    Debug.Log("Kotl, giff coin");
                    break;
                case 4:
                    // GIVE DAMAGE
                    Debug.Log("Kotl, giff DMG");
                    break;
                case 5:
                    // GIVE HP
                    Debug.Log("Kotl, giff MANA");
                    break;
                default:
                    Debug.LogError("BAD HAPPEN IN PARSERESULT SWITCH");
                    break;
            }
        }

        if (nextEncounter >= 0)
        {
            Debug.Log("Next encounter: #" + nextEncounter + " - EncounterName: " + GameManager.Instance.data.json.GetEncounter(nextEncounter).eName);
            InitEncounter(nextEncounter, !msgShown);
            GameManager.Instance.gameState = GameManager.State.intro;
        }
        else if (nextEncounter == -1)
        {
            Debug.Log("Encountergroup ended");
            GameManager.Instance.gameState = GameManager.State.outro;
            if (!msgShown)
                GameManager.Instance.InitRandomEncounterGroup();
            // TODO: Finish this!
        }
        else
        {
            Debug.LogError("Shieet wait what?");
            GameManager.Instance.InitRandomEncounterGroup();
        }
    }

}

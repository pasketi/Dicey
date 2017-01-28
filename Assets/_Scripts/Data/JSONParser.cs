using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JSON {

    private Dictionary<int, Encounter> encounters;
    private Dictionary<int, EncounterGroup> encounterGroups;

    public void LoadEncounters (DataController.EncounterData data)
    {
        encounters = new Dictionary<int, Encounter>();

        for (int i = 0; i < data.Encounter.Count; i++)
        {
            Encounter _encounter = new Encounter();

            _encounter.eName = data.Encounter[i].eName;
            _encounter.NPCPath = data.Encounter[i].NPCPath;
            _encounter.StagePath = data.Encounter[i].StagePath;
            _encounter.introText = data.Encounter[i].introText;
            _encounter.Actions = new List<ActionData>();

            for (int j = 0; j < data.Encounter[i].Actions.Count; j++)
            {
                ActionData _action = new ActionData();

                _action.ID = data.Encounter[i].Actions[j].ID;
                _action.title = data.Encounter[i].Actions[j].title;
                _action.description = data.Encounter[i].Actions[j].description;
                _action.skillCheck = data.Encounter[i].Actions[j].skillCheck;
                _action.skillCheckID = data.Encounter[i].Actions[j].skillCheckID;
                _action.challenge = data.Encounter[i].Actions[j].challenge;
                _action.challengeTargetID = data.Encounter[i].Actions[j].challengeTargetID;
                _action.Success = new List<ActionResultData>();

                for (int k = 0; k < data.Encounter[i].Actions[j].Success.Count; k++)
                {
                    ActionResultData _result = new ActionResultData();

                    _result.resultID = data.Encounter[i].Actions[j].Success[k].resultID;
                    _result.resultValue = data.Encounter[i].Actions[j].Success[k].resultValue;

                    _action.Success.Add(_result);
                }

                _action.Failure = new List<ActionResultData>();

                for (int k = 0; k < data.Encounter[i].Actions[j].Failure.Count; k++)
                {
                    ActionResultData _result = new ActionResultData();

                    _result.resultID = data.Encounter[i].Actions[j].Failure[k].resultID;
                    _result.resultValue = data.Encounter[i].Actions[j].Failure[k].resultValue;

                    _action.Failure.Add(_result);
                }

                _encounter.Actions.Add(_action);
            }

            encounters.Add(data.Encounter[i].ID, _encounter);
        }
    }
    
    public void LoadEncounterGroups (DataController.EncounterGroupData data)
    {
        encounterGroups = new Dictionary<int, EncounterGroup>();

        for (int i = 0; i < data.EncounterGroup.Count; i++)
        {
            EncounterGroup _encounterGroup = new EncounterGroup();

            _encounterGroup.GroupName = data.EncounterGroup[i].GroupName;
            _encounterGroup.startEncounter = data.EncounterGroup[i].startEncounter;
            _encounterGroup.Active = data.EncounterGroup[i].Active;

            encounterGroups.Add(data.EncounterGroup[i].GroupID, _encounterGroup);
        }
    }

    public Encounter GetEncounter(int ID)
    {
        return encounters[ID];
    }

    public int CountEncounterGroups()
    {
        return encounterGroups.Count;
    }

    public EncounterGroup GetEncounterGroup(int ID)
    {
        return encounterGroups[ID];
    }
	
    public List<ActionData> GetEncounterActions(int ID)
    {
        return encounters[ID].Actions;
    }

}

[System.Serializable]
public class Encounter
{
    public int ID;
    public string eName;
    public string NPCPath;
    public string StagePath;
    public string introText;
    public List<ActionData> Actions;
}

[System.Serializable]
public class ActionData
{
    public int ID;
    public string title;
    public string description;

    public int skillCheck;
    public int skillCheckID;

    public int challenge;
    public int challengeTargetID;

    public List<ActionResultData> Success;
    public List<ActionResultData> Failure;

    public ChallengeType challengeType
    {
        get { return (ChallengeType)challenge; }
    }
    public SkillCheckType skillCheckType
    {
        get { return (SkillCheckType)skillCheck; }
    }
}

[System.Serializable]
public class ActionResultData
{
    public int resultID;
    public string resultValue;

    public ResultType result
    {
        get { return (ResultType)resultID; }
    }
}

[System.Serializable]
public class EncounterGroup
{
    public int GroupID;
    public string GroupName;
    public int startEncounter;
    public bool Active;
}
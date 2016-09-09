using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataController {

    private JSON _json;
    public JSON json { get { return _json; } }
    private bool _initialized = false;

    [System.Serializable]
    public class EncounterData
    {
        public List<Encounter> Encounter;
    }

    [System.Serializable]
    public class EncounterGroupData
    {
        public List<EncounterGroup> EncounterGroup;
    }

    public DataController()
    {
        Init();
    }

    private void Init()
    {
        _json = new JSON();
        try
        {
            TextAsset encounters = Resources.Load<TextAsset>("Data/Encounters");
            TextAsset encounterGroups = Resources.Load<TextAsset>("Data/EncounterGroups");
            _json.LoadEncounters(JsonUtility.FromJson<EncounterData>(encounters.text));
            _json.LoadEncounterGroups(JsonUtility.FromJson<EncounterGroupData>(encounterGroups.text));

            _initialized = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load config -- " + e.ToString());
            _initialized = false;
        }
    }

}

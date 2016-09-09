using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null && !_quitting)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    Debug.LogError("Add GameController to the scene!");
                }
                else
                {
                    _instance.Init();
                }
            }
            return _instance;
        }
    }

    private static bool _quitting;
    #endregion

    public DataController data;
    public EncounterGroup currentEncounterGroup;
    public GameObject StoryText;
    public List<BaseAction> actions;

    internal bool Initialized;

    void Awake()
    {
        if (_instance == null)
        {
            Initialized = false;
            _instance = this;
            Init();
        }
        else if (_instance != this)
        {
            Destroy(this);
        }

        _quitting = false;
    }

    public void Init()
    {
        if (data == null)
        {
            data = new DataController();
        }

        InitEncounter(0);

        Initialized = true;
        Debug.Log("GC Init " + Initialized);

    }

    public void InitEncounter(int ID)
    {
        for (int i = 0; i < 3; i++)
        {
            actions[i].SetActionTexts(data.json.GetEncounterActions(ID)[i]);
        }
    }

    public GraphicsHandler InspectedCard { get; private set; }

    public void InspectCard(GraphicsHandler Card)
    {
        if (InspectedCard != null)
        {
            InspectedCard.ToggleInspection();

        }
        InspectedCard = Card;
    }

    public void ClearInspectedCard ()
    {
        InspectedCard = null;
    }
}

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

    public enum State : int
    {
        intro = 0,
        choise = 1,
        outro = 2
    }

    public State gameState;
    public DataController data;
    public EncounterGroup currentEncounterGroup;
    public EncounterController encounter;
    public PlayerCharacter player;
    public BaseCharacter NPC;

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
        gameState = State.intro;
        InitRandomEncounterGroup();
        _quitting = false;
    }

    public void Init()
    {
        if (data == null)
        {
            data = new DataController();
        }

        if (encounter == null)
        {
            encounter = GetComponent<EncounterController>();
        }

        if (player == null)
        {
            player = GetComponent<PlayerCharacter>();
        }

        Initialized = true;
        Debug.Log("GC Init " + Initialized);

    }

    public void InitRandomEncounterGroup()
    {
        gameState = State.intro;
        currentEncounterGroup = data.json.GetEncounterGroup(Random.Range((int)0, data.json.CountEncounterGroups()));
        encounter.InitEncounter(currentEncounterGroup.startEncounter);
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
